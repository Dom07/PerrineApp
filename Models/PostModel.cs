namespace PerrineApp.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string Picture { get; set; } = string.Empty;
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
