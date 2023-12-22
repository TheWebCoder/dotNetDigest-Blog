using dotNetDigest.Web.Data;
using dotNetDigest.Web.Models.Domain;
using dotNetDigest.Web.Models.ViewModels;
using dotNetDigest.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace dotNetDigest.Web.Pages.Admin.Blogs
{
    public class AddModel : PageModel
    {
        
        private readonly IBlogPostRepository blogPostRepository;

        [BindProperty]
        public AddBlogPost AddBlogPostRequest { get; set; }

        [BindProperty]
        public IFormFile FeaturedImage { get; set; }

        public AddModel(IBlogPostRepository blogPostRepository)
        {
            
            this.blogPostRepository = blogPostRepository;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost() 
        {
            var blogPost = new BlogPost()
            {
                Heading = AddBlogPostRequest.Heading,
                PageTitle = AddBlogPostRequest.PageTitle,
                Content = AddBlogPostRequest.Content,
                ShortDescription = AddBlogPostRequest.ShortDescription,
                FeatutedImageUrl = AddBlogPostRequest.FeatutedImageUrl,
                UrlHandle = AddBlogPostRequest.UrlHandle,
                PublishedDate = AddBlogPostRequest.PublishedDate,
                Author = AddBlogPostRequest.Author,
                Visible = AddBlogPostRequest.Visible

            };

            await blogPostRepository.AddAsync(blogPost);

            var notification = new Notification
            {
                Type = Enums.NotificationType.Success,
                Message = "New blog created!"
            };

            TempData["Notification"] = JsonSerializer.Serialize(notification);

            return RedirectToPage("/Admin/Blogs/List");
        }
    }
}
