using System.ComponentModel.DataAnnotations;

namespace spots.Models.Account.Viewmodels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}