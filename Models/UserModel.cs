namespace PerrineApp.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get => FirstName; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
