using PerrineApp.Models;

namespace PerrineApp.DataAccess
{
    public interface IPostAccess
    {
        public List<PostModel> GetAllPosts();
        public PostModel GetPostById(int id);
        public Task<bool> NewPost(PostModel Model);
        public Task<(bool, List<CommentModel>)> AddComment(CommentModel Model);
    }
}
