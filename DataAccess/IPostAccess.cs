﻿using PerrineApp.Models;

namespace PerrineApp.DataAccess
{
    public interface IPostAccess
    {
        public List<PostModel> GetAllPosts();
        public PostModel GetPostById(int id);
    }
}