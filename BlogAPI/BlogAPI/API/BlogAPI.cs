using BlogAPI.Domain.Interfaces.Services;
using BlogAPI.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.API
{
    [ApiController]
    public class BlogAPI : Controller
    {
        private readonly IBlogService _blogService;
        public BlogAPI(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpPost,Route("~/api/blog/post")]
        public async Task<IActionResult> CreatePost([FromBody] PostModel postModel)
        {
            var post = await _blogService.CreatePost(postModel);
            return Ok(post);
        }
         
        [HttpPost, Route("~/api/blog/post/{postId}/comment")]
        public async Task<IActionResult> CreateComment(Guid postId, [FromBody] CommentModel commentModel)
        {
            var comment = await _blogService.CreateComment(postId,commentModel);
            return Ok(comment);
        }
        [HttpGet, Route("~/api/blog/post/{postId}/comments")]
        public async Task<IActionResult> GetCommentsRelatedPost(Guid postId)
        {
            var comments = await _blogService.GetCommentsRelatedPost(postId);
            return Ok(comments);
        }
        
        [HttpGet, Route("~/api/blog/posts")]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await _blogService.GetAllPosts();
            return Ok(posts);
        }

        [HttpDelete,Route("~/api/blog/post/{postId}/comment/{commentId}")]//postId -- для нормального вигляду маршуту 
        public async Task<IActionResult> DeleteComment(Guid commentId)
        {
            await _blogService.DeleteComment(commentId);
            return Ok();
        }
    }
}
