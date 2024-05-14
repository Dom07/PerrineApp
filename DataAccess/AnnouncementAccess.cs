using Dapper;
using PerrineApp.Models;
using System.Data;

namespace PerrineApp.DataAccess
{
    public class AnnouncementAccess : IAnnouncementAccess
    {
        private IDataAccess _dataAccess;

        public AnnouncementAccess(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public List<AnnouncementModel> GetAnnouncements()
        {
            using IDbConnection cnn = _dataAccess.CreateConnection();
            var output = cnn.Query<AnnouncementModel>("Select A.Message, B.Picture from Announcements as A join User as B on A.UserId = B.Id ORDER by A.Id DESC LIMIT 5;", new DynamicParameters());
            return output.ToList();
        }

        public async Task<bool> NewAnnouncement(AnnouncementModel Model)
        {
            using IDbConnection cnn = _dataAccess.CreateConnection();
            var output = await cnn.ExecuteAsync("Insert into Announcements (Message, UserId, Date) values (@Message, @UserId, @Date)", Model);
            
            if(output > 0)
                return true;

            return false;
        }
    }
}
