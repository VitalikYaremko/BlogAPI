using AutoMapper;
using BlogAPI.Data.Entities;
using BlogAPI.Domain.Interfaces.Repositeries;
using BlogAPI.Domain.Interfaces.Services;
using BlogAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Domain.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        public BlogService(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public async Task<PostModel> CreatePost(PostModel postModel)
        { 
            if (postModel.UserName == null)
                postModel.UserName = "Guest";

            var postEntity = await _blogRepository.CreatePost(_mapper.Map<PostEntity>(postModel));

            return _mapper.Map<PostModel>(postEntity);
        }

        public async Task<CommentModel> CreateComment(Guid postId,CommentModel commentModel)
        {
            if (commentModel.UserName == null)
                commentModel.UserName = "Guest";
            if(postId != Guid.Empty)
            {
                commentModel.PostId = postId;
            }
            else
            {
                throw new Exception("PostId cannot be empty !");
            }

            var commentEntity = await _blogRepository.CreateComment(_mapper.Map<CommentEntity>(commentModel));
            return _mapper.Map<CommentModel>(commentEntity);
        }

        public async Task<List<CommentModel>> GetCommentsRelatedPost(Guid postId)
        {
            var commentsEntity = await _blogRepository.GetCommentsRelatedPost(postId);
            return _mapper.Map<List<CommentModel>>(commentsEntity);
        }

        public async Task<List<PostModel>> GetAllPosts()
        {
            var postsEntity = await _blogRepository.GetAllPosts();
            return _mapper.Map<List<PostModel>>(postsEntity);
        }

        public async Task DeleteComment(Guid commentId)
        {
            await _blogRepository.DeleteComment(commentId);
        }
    }
}
