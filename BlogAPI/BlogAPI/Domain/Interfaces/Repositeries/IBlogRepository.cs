using BlogAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Domain.Interfaces.Repositeries
{
    public interface IBlogRepository
    {
        /// <summary>
        /// POST
        /// </summary>
        /// <param name="postEntity"></param>
        /// <returns></returns>
        Task<PostEntity> CreatePost(PostEntity postEntity);//1. Create new post

        //Task<PostEntity> GetPostById(Guid postId);
        //Task<List<PostEntity>> GetPosts(int startPos, int numOfItems, string filter);
        Task<List<PostEntity>> GetAllPosts();//2. See all the posts

        //Task<PostEntity> UpdatePost(PostEntity postEntity);

        //Task DeletePost(Guid postId);

        /// <summary>
        /// COMMENT
        /// </summary>
        /// <param name="commentEntity"></param>
        /// <returns></returns>
        Task<CommentEntity> CreateComment(CommentEntity commentEntity); //3. Add a comment for a post

       // Task<CommentEntity> GetCommentById(Guid commentId);
        Task<List<CommentEntity>> GetCommentsRelatedPost(Guid postId); //5. See all the comments related to the specific post

       // Task<CommentEntity> UpdateComment(CommentEntity commentEntity);
        
        Task DeleteComment(Guid commentId); //4. Delete a comment from a post
    }
}
