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
            var output = cnn.Query<PostModel>("Select p.Title, p.Content, p.CreateTime, u.FirstName, u.Picture From Posts as p join User as u on p.UserId = u.Id order by p.CreateTime;");
            return output.ToList();
        }

        public PostModel GetPostById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> NewPost(PostModel Model)
        {
            using IDbConnection cnn = _dataAccess.CreateConnection();
            var output = await cnn.ExecuteAsync("Insert into Posts (Title, Content, CreateTime, UserId) values (@Title, @Content, @CreateTime, @UserId)", Model);

            if (output > 0)
                return true;

            return false;
        }
    }
}
