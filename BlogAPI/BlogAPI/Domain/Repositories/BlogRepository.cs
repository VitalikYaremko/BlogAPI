using BlogAPI.Data.Context;
using BlogAPI.Data.Entities;
using BlogAPI.Domain.Interfaces.Repositeries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Domain.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly IDesignTimeDbContextFactory<BlogContext> _blogContextFactory;
        public BlogRepository(IDesignTimeDbContextFactory<BlogContext> blogContextFactory)
        {
            _blogContextFactory = blogContextFactory;
        }

        public async Task<PostEntity> CreatePost(PostEntity postEntity)
        {
            using (var context = _blogContextFactory.CreateDbContext(null))
            {
                postEntity.Id = Guid.NewGuid();
                postEntity.CreatedOn = DateTime.Now;

                await context.Posts.AddAsync(postEntity).ConfigureAwait(false);
                await context.SaveChangesAsync();

                return postEntity;
            }
        }
        public async Task<CommentEntity> CreateComment(CommentEntity commentEntity)
        {
            using (var context = _blogContextFactory.CreateDbContext(null))
            {
                var post = await context.Posts.FirstOrDefaultAsync(x => x.Id == commentEntity.PostId && x.IsActive == true).ConfigureAwait(false);
                if (post == null)
                    throw new Exception($"Post with id: {commentEntity.PostId} was not found");
                commentEntity.Id = Guid.NewGuid();
                commentEntity.CreatedOn = DateTime.Now;

                await context.Comments.AddAsync(commentEntity);
                await context.SaveChangesAsync();
                return commentEntity;
            }
        }

        public async Task<List<CommentEntity>> GetCommentsRelatedPost(Guid postId)
        {
            using (var context = _blogContextFactory.CreateDbContext(null))
            {
                var comments = await context.Comments.Where(x => x.PostId == postId && x.IsActive == true).OrderBy(x => x.CreatedOn).ToListAsync().ConfigureAwait(false);
                return comments;
            }
        }
        public async Task<List<PostEntity>> GetAllPosts()
        {
            using (var context = _blogContextFactory.CreateDbContext(null))
            {
                var posts = await context.Posts.Where(x => x.IsActive == true).OrderBy(x => x.CreatedOn).ToListAsync().ConfigureAwait(false);
                if (posts.Count > 0)
                {
                    foreach(var post in posts)
                    {
                        var comments = await context.Comments.Where(x => x.PostId == post.Id && x.IsActive == true).OrderBy(x => x.CreatedOn).ToListAsync().ConfigureAwait(false);
                        post.Comments = comments;
                    }
                }
                return posts;
            }
        }

        public async Task DeleteComment(Guid commentId)
        {
            using (var context = _blogContextFactory.CreateDbContext(null))
            {
                var comment = await context.Comments.FirstOrDefaultAsync(x => x.Id == commentId).ConfigureAwait(false);
                if (comment != null)
                {
                    comment.IsActive = false;
                }
                else
                {
                    throw new Exception($"Comment whith id:{commentId} was not found");
                }
                await context.SaveChangesAsync();
            }
        }
    }
}
