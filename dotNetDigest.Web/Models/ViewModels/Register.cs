using System.ComponentModel.DataAnnotations;

namespace dotNetDigest.Web.Models.ViewModels
{
    public class Register
    {
        [Required]
        public string Usermame { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
