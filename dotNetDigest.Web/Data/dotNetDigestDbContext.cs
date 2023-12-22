using dotNetDigest.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace dotNetDigest.Web.Data
{
    public class dotNetDigestDbContext : DbContext
    {
        public dotNetDigestDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
