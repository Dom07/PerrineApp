using Dapper;
using PerrineApp.Models;
using System.Data;
using System.Reflection.Metadata;

namespace PerrineApp.DataAccess
{
    public class UserAccess : IUserAccess
    {
        private IDataAccess _dataAccess;

        public UserAccess(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public UserModel GetUserById(int Id)
        {
            using IDbConnection cnn = _dataAccess.CreateConnection();
            var param = new { Id };
            var output = cnn.Query<UserModel>("select * from User where Id = @Id limit 1", param).FirstOrDefault();
            return output;

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
