using Dapper;
using PerrineApp.Models;
using System.Data;

namespace PerrineApp.DataAccess
{
    public class UserAccess : IUserAccess
    {
        private IDataAccess _dataAccess;

        public UserAccess(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public List<UserModel> LoadUsers()
        {
            using IDbConnection cnn = _dataAccess.CreateConnection();
            var output = cnn.Query<UserModel>("select * from User", new DynamicParameters());
            return output.ToList();

        }

        public UserModel LoginUser(string username, string password)
        {
            using IDbConnection cnn = _dataAccess.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("username", username);
            parameters.Add("password", password);

            return cnn.Query<UserModel>("Select * from User where FirstName=@username and password=@password", parameters).FirstOrDefault()!;
        }
    }
}
