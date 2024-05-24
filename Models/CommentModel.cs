namespace PerrineApp.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Comment { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string Picture { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
