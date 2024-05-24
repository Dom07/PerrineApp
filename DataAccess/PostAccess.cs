using Dapper;
using PerrineApp.Models;
using System.Data;

namespace PerrineApp.DataAccess
{
    public class PostAccess : IPostAccess
    {
        private IDataAccess _dataAccess;
        private IDbConnection _connection;
        public PostAccess(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            _connection = _dataAccess.CreateConnection();
        }

        public List<PostModel> GetAllPosts()
        {
            //using IDbConnection cnn = _dataAccess.CreateConnection();
            var output = _connection.Query<PostModel>("Select p.Title, p.Content, p.CreateTime, u.FirstName, u.Picture From Posts as p join User as u on p.UserId = u.Id order by p.CreateTime;");
            return output.ToList();
        }

        public PostModel GetPostById(int id)
        {
            //using IDbConnection cnn = _dataAccess.CreateConnection();
            var output = _connection.QuerySingle<PostModel>("Select p.Title, p.Content, p.CreateTime, u.FirstName, u.Picture from Posts as p join User as u on p.UserId = u.Id where p.id=@id", new { id });
            output.Comments = _connection.Query<CommentModel>("Select u.FirstName, u.Picture, c.Comment, c.CreateTime from PostComments as c join User as u on c.UserId = u.Id where PostId=@id", new {id}).ToList();
            return output;
        }

        public async Task<bool> NewPost(PostModel Model)
        {
            //using IDbConnection cnn = _dataAccess.CreateConnection();
            var output = await _connection.ExecuteAsync("Insert into Posts (Title, Content, CreateTime, UserId) values (@Title, @Content, @CreateTime, @UserId)", Model);

            if (output > 0)
                return true;

            return false;
        }
    }
}
