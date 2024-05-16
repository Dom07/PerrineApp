using PerrineApp.Models;

namespace PerrineApp.DataAccess
{
    public interface IUserAccess
    {
        public UserModel GetUserById(int Id);
        public UserModel LoginUser(string username, string password);
    }
}
