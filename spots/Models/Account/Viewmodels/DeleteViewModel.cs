using System;
using System.ComponentModel.DataAnnotations;
using spots.Models.Account.Interfaces;

namespace spots.Models.Account.Viewmodels
{
    public class DeleteViewModel : IDelete
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [RegularExpression("([a-zA-Z0-9\\s.,0-9@#$%*():;\"\"\'/?!+=_-]+)", ErrorMessage = "The password is invalid")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [StringLength(4, ErrorMessage = "The {0} must be exactly {1} characters long", MinimumLength = 4)]
        [DataType(DataType.Text)]
        [RegularExpression("([0-9]+)", ErrorMessage = "The code is invalid")]
        [Display(Name = "Code")]
        public string Code { get; set; }

        public string GeneratedCode { get; set; }

        public void GenerateCode(int length)
        {
            var rnd = new Random();
            var code = "";

            for (var i = 0; i < length; i++)
            {
                var number = rnd.Next(1, 10);
                code += number.ToString();
            }

            GeneratedCode = code;
        }
    }
}