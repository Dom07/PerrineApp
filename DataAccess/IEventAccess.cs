using PerrineApp.Models;

namespace PerrineApp.DataAccess
{
    public interface IEventAccess
    {
        public List<EventModel> GetEvents();
        public Task<bool> NewEvent(EventModel Model);
        public List<EventCategoryModel> GetEventCategories();
    }
}
