using System.ComponentModel.DataAnnotations;

namespace PerrineApp.Models
{
    public class LoginModel
    {
        public string Username { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
