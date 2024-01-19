using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotNetDigest.Web.Models.Domain; // Assuming Tag is here
using dotNetDigest.Web.Repositories;

public class TagViewComponent : ViewComponent
{
    private readonly ITagRepository _tagRepository;

    public TagViewComponent(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var tags = await _tagRepository.GetAllAsync();
        return View(tags); // Make sure 'Tag' is recognized as a type here
    }
}