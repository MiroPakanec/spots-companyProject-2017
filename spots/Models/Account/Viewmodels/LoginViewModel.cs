using System.ComponentModel.DataAnnotations;
using spots.Models.Account.Interfaces;

namespace spots.Models.Account.Viewmodels
{
    public class LoginViewModel : ILogin
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Email Address is invalid (e.g. john.smith@email.com)")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}