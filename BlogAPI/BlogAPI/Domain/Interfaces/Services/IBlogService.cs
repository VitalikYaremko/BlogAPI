using BlogAPI.Data.Entities;
using BlogAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Domain.Interfaces.Services
{
    public interface IBlogService
    {
        Task<PostModel> CreatePost(PostModel postModel);

        Task<List<PostModel>> GetAllPosts();



        Task<CommentModel> CreateComment(Guid postId, CommentModel commentModel);

        Task<List<CommentModel>> GetCommentsRelatedPost(Guid postId);
        Task DeleteComment(Guid commentId);
    }
}
