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
            var output = _connection.Query<PostModel>("Select p.Id, p.Title, p.Content, p.CreateTime, u.FirstName, u.Picture, coalesce(pc.Count, 0) AS CommentCount From Posts as p join User as u on p.UserId = u.Id left join (Select PostId, Count(*) as Count FROM PostComments GROUP BY PostId) as pc on p.Id = pc.PostId order by p.CreateTime;");
            return output.ToList();
        }

        public PostModel GetPostById(int id)
        {
            var output = _connection.QuerySingle<PostModel>("Select p.Title, p.Content, p.CreateTime, u.FirstName, u.Picture from Posts as p join User as u on p.UserId = u.Id where p.id=@id", new { id });
            output.Comments = GetAllComments(id).Result;
            return output;
        }

        public async Task<bool> NewPost(PostModel Model)
        {
            var output = await _connection.ExecuteAsync("Insert into Posts (Title, Content, CreateTime, UserId) values (@Title, @Content, @CreateTime, @UserId)", Model);

            if (output > 0)
                return true;

            return false;
        }

        public async Task<(bool, List<CommentModel>)> AddComment(CommentModel Model)
        {
            var output = await _connection.ExecuteAsync("Insert into PostComments (PostId, Comment, UserId, CreateTime) values (@PostId, @Comment, @UserId, @CreateTime)", Model);

            if (output > 0)
                return (true, GetAllComments(Model.PostId).Result);
               
            return (false, new List<CommentModel>());
        }

        public async Task<List<CommentModel>> GetAllComments(int Id)
        {
            return _connection.Query<CommentModel>("Select u.FirstName, u.Picture, c.Comment, c.CreateTime from PostComments as c join User as u on c.UserId = u.Id where PostId=@Id", new { Id }).ToList();
        }
    }
}
