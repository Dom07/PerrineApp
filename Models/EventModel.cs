using System.ComponentModel.DataAnnotations;

namespace PerrineApp.Models
{
    public class EventModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string FontAwesomeClass { get; set; }
        [Required]
        public DateTime Date { get;set; } = DateTime.Now;
        public int UserId { get; set; }
    }

    public class EventCategoryModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
