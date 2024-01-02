using dotNetDigest.Web.Data;
using dotNetDigest.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace dotNetDigest.Web.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly dotNetDigestDbContext dotNetDigestDbContext;

        public BlogPostRepository(dotNetDigestDbContext DotNetDigestDbContext)
        {
            dotNetDigestDbContext = DotNetDigestDbContext;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync(string tagName)
        {
            return await (dotNetDigestDbContext.BlogPosts.Include(nameof(BlogPost.Tags))
                .Where(x => x.Tags.Any(x => x.Name == tagName)))
                .ToListAsync();
        }

        public async Task<BlogPost> GetAsync(string urlHandle)
        {
            return await dotNetDigestDbContext.BlogPosts.Include(nameof(BlogPost.Tags))
                .FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
        }

        async Task<BlogPost> IBlogPostRepository.AddAsync(BlogPost blogPost)
        {
            await dotNetDigestDbContext.BlogPosts.AddAsync(blogPost);
            await dotNetDigestDbContext.SaveChangesAsync();
            return blogPost;
        }

        async Task<bool> IBlogPostRepository.DeleteAsync(Guid id)
        {
            var existingBlog = await dotNetDigestDbContext.BlogPosts.FindAsync(id);

            if (existingBlog != null)
            {
                dotNetDigestDbContext.BlogPosts.Remove(existingBlog);
                await dotNetDigestDbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        async Task<IEnumerable<BlogPost>> IBlogPostRepository.GetAllAsync()
        {
            return await dotNetDigestDbContext.BlogPosts.Include(nameof(BlogPost.Tags)).ToListAsync();
        }

        async Task<BlogPost> IBlogPostRepository.GetAsync(Guid id)
        {
            return await dotNetDigestDbContext.BlogPosts.Include(nameof(BlogPost.Tags))
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        async Task<BlogPost> IBlogPostRepository.UpdateAsync(BlogPost blogPost)
        {
            var existingBlogPost = await dotNetDigestDbContext.BlogPosts.Include(nameof(BlogPost.Tags))
                .FirstOrDefaultAsync(x => x.Id == blogPost.Id);

            if (existingBlogPost != null)
            {
                existingBlogPost.Heading = blogPost.Heading;
                existingBlogPost.PageTitle = blogPost.PageTitle;
                existingBlogPost.Content = blogPost.Content;
                existingBlogPost.ShortDescription = blogPost.ShortDescription;
                existingBlogPost.FeatutedImageUrl = blogPost.FeatutedImageUrl;
                existingBlogPost.UrlHandle = blogPost.UrlHandle;
                existingBlogPost.PublishedDate = blogPost.PublishedDate;
                existingBlogPost.Author = blogPost.Author;
                existingBlogPost.Visible = blogPost.Visible;

                
                if (blogPost.Tags != null && blogPost.Tags.Any())
                {
                    // Delete the existing tags
                    dotNetDigestDbContext.Tags.RemoveRange(existingBlogPost.Tags);

                    // Add new tags
                    blogPost.Tags.ToList().ForEach(x => x.BlogPostId = existingBlogPost.Id);
                    await dotNetDigestDbContext.Tags.AddRangeAsync(blogPost.Tags);

                }


            }

            await dotNetDigestDbContext.SaveChangesAsync();
            return existingBlogPost;
        }
    }
}
