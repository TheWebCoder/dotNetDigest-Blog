using dotNetDigest.Web.Data;
using dotNetDigest.Web.Models.Domain;
using dotNetDigest.Web.Models.ViewModels;
using dotNetDigest.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace dotNetDigest.Web.Pages.Admin.Blogs
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;

        [BindProperty]

        public BlogPost BlogPost { get; set; }

        [BindProperty]
        public IFormFile FeaturedImage { get; set; }

        [BindProperty]
        public string Tags { get; set; }

        public EditModel(IBlogPostRepository blogPostRepository)
        {
           
            this.blogPostRepository = blogPostRepository;
        }
        public async Task OnGet(Guid id)
        {
            BlogPost = await blogPostRepository.GetAsync(id);

            if (BlogPost != null && BlogPost.Tags != null) 
            {
                Tags = string.Join(',', BlogPost.Tags.Select(x => x.Name));
            }

           
        }

        public async Task<IActionResult> OnPostEdit()
        {

            try
            {
                BlogPost.Tags = new List<Tag>( Tags.Split(',').Select(x => new Tag() { Name = x.Trim()}));

                await blogPostRepository.UpdateAsync(BlogPost);

                ViewData["Notification"] = new Notification
                {
                    Message = "Post updated successfully!",
                    Type = Enums.NotificationType.Success
                };
            }
            catch (Exception ex)
            {
                ViewData["Notification"] = new Notification
                {
                    Message = "Something went wrong!",
                    Type = Enums.NotificationType.Error
                };
                
            }

            return Page();

        }

        public async Task<IActionResult> OnPostDelete()
        {

            var deleted = await blogPostRepository.DeleteAsync(BlogPost.Id);
            if (deleted)
            {
                var notification = new Notification
                {
                    Type = Enums.NotificationType.Success,
                    Message = "Blog was deleted successfully!"
                };

                TempData["Notification"] = JsonSerializer.Serialize(notification);

                return RedirectToPage("/Admin/Blogs/List");
            }
                
            return Page();
        }
    }
}
