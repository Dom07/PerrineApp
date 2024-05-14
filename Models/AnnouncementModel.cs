namespace PerrineApp.Models
{
    public class AnnouncementModel
    {
        public string Message { get; set; } = string.Empty;
        public int UserId { get; set; }  
        public string Picture { get; set; } = string.Empty;
        public string Date { get; set;} = string.Empty;
    }
}
