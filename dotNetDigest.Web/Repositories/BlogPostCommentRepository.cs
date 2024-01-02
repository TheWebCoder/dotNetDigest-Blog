using dotNetDigest.Web.Data;
using dotNetDigest.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace dotNetDigest.Web.Repositories
{
    public class BlogPostCommentRepository : IBlogPostCommentRepository
    {
        private readonly dotNetDigestDbContext dotNetDigestDbContext;

        public BlogPostCommentRepository(dotNetDigestDbContext DotNetDigestDbContext)
        {
            dotNetDigestDbContext = DotNetDigestDbContext;
        }
        public async Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment)
        {
            await dotNetDigestDbContext.BlogPostComment.AddAsync(blogPostComment);
            await dotNetDigestDbContext.SaveChangesAsync();
            return blogPostComment;
        }

        public async Task<IEnumerable<BlogPostComment>> GetAllAsync(Guid blogPostId)
        {
            return await dotNetDigestDbContext.BlogPostComment.Where(x => x.BlogPostId == blogPostId)
                .ToListAsync();
        }
    }
}
