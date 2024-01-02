using dotNetDigest.Web.Data;
using dotNetDigest.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace dotNetDigest.Web.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly dotNetDigestDbContext dotNetDbContext;

        public TagRepository(dotNetDigestDbContext DotNetDbContext)
        {
            dotNetDbContext = DotNetDbContext;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            var tags = await dotNetDbContext.Tags.ToListAsync();

            return tags.DistinctBy(x => x.Name.ToLower());
        }
    }
}
