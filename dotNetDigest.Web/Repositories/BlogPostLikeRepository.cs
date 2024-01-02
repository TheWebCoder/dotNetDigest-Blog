
using dotNetDigest.Web.Data;
using dotNetDigest.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace dotNetDigest.Web.Repositories
{
    public class BlogPostLikeRepository : IBlogPostLikeRepository
    {
        private readonly dotNetDigestDbContext dotNetDigestDbContext;

        public BlogPostLikeRepository(dotNetDigestDbContext DotNetDigestDbContext)
        {
            dotNetDigestDbContext = DotNetDigestDbContext;
        }

        public async Task AddLikeForBlog(Guid blogPostId, Guid userId)
        {
            var like = new BlogPostLike
            {
                Id = Guid.NewGuid(),
                BlogPostId = blogPostId,
                UserId = userId
            };

            await dotNetDigestDbContext.BlogPostLike.AddAsync(like);
            await dotNetDigestDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogPostId)
        {
           return await dotNetDigestDbContext.BlogPostLike.Where(x => x.BlogPostId == blogPostId)
                .ToListAsync();
        }

        public async Task<int> GetTotalLikesForBlog(Guid blogPostId)
        {
            return await dotNetDigestDbContext.BlogPostLike
                .CountAsync(x => x.BlogPostId == blogPostId);
        }
    }
}
