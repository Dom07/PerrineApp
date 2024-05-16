using Dapper;
using PerrineApp.Models;
using System.Data;

namespace PerrineApp.DataAccess
{
    public class PostAccess : IPostAccess
    {
        private IDataAccess _dataAccess;
        public PostAccess(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public List<PostModel> GetAllPosts()
        {
            using IDbConnection cnn = _dataAccess.CreateConnection();
            var output = cnn.Query<PostModel>("Select * from posts order by Id limit 10;");
            return output.ToList();
        }

        public PostModel GetPostById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
