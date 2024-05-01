using PerrineApp.Models;

namespace PerrineApp.DataAccess
{
    public interface IAnnouncementAccess
    {
        public List<AnnouncementModel> GetAnnouncements();

        public Task<bool> NewAnnouncement(AnnouncementModel Model);
    }
}
