using Dapper;
using PerrineApp.Models;
using System.Data;

namespace PerrineApp.DataAccess
{
    public class EventAccess : IEventAccess
    {
        private IDataAccess _dataAccess;

        public EventAccess(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public List<EventCategoryModel> GetEventCategories()
        {
            using IDbConnection cnn = _dataAccess.CreateConnection();
            var output = cnn.Query<EventCategoryModel>("Select Id, CategoryName from EventCategories", new DynamicParameters());
            return output.ToList();
        }

        public List<EventModel> GetEvents()
        {
            using IDbConnection cnn = _dataAccess.CreateConnection();
            var dateNow = DateTime.Today;
            var output = cnn.Query<EventModel>("Select e.Name, e.Date, ec.FontAwesomeClass from Events as e join EventCategories as ec on e.CategoryId = ec.Id where e.Date >= @dateNow ORDER BY e.Date", new {dateNow});
            return output.ToList();
        }

        public async Task<bool> NewEvent(EventModel Model)
        {
            using IDbConnection cnn = _dataAccess.CreateConnection();
            var output = await cnn.ExecuteAsync("Insert into Events (Name, CategoryId, Date, UserId) values (@Name, @CategoryId, @Date, @UserId)", Model);

            if (output > 0)
                return true;

            return false;
        }
    }
}
