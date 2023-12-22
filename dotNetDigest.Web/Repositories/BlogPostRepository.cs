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
            return await dotNetDigestDbContext.BlogPosts.ToListAsync();
        }

        async Task<BlogPost> IBlogPostRepository.GetAsync(Guid id)
        {
            return await dotNetDigestDbContext.BlogPosts.FindAsync(id);
        }

        async Task<BlogPost> IBlogPostRepository.UpdateAsync(BlogPost blogPost)
        {
            var existingBlogPost = await dotNetDigestDbContext.BlogPosts.FindAsync(blogPost.Id);

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
            }

            await dotNetDigestDbContext.SaveChangesAsync();
            return existingBlogPost;
        }
    }
}
