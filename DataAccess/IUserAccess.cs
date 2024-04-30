using PerrineApp.Models;

namespace PerrineApp.DataAccess
{
    public interface IUserAccess
    {
        public UserModel LoginUser(string username, string password);
    }
}
