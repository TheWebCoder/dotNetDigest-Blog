using dotNetDigest.Web.Models.Domain;

namespace dotNetDigest.Web.Repositories
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetAllAsync();
    }
}
