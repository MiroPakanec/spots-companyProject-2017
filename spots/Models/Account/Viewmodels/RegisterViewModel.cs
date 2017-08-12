using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Castle.Core.Internal;
using MongoDB.Bson;
using spots.Models.Account.Interfaces;
using spots.Models.Group.Interfaces;
using spots.Models.User;
using spots.Models.User.Interfaces;

namespace spots.Models.Account.Viewmodels
{
    public class RegisterViewModel : IRegister
    {
        [Required]
        [EmailAddress(ErrorMessage = "Email Address is invalid (e.g. john.smith@email.com)")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [RegularExpression("[A-Z]{1,1}[a-z]*$", ErrorMessage = "First name is invalid (e.g. John)")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [RegularExpression("[A-Z]{1,1}[a-z]*$", ErrorMessage = "Last name is invalid (e.g. Smith)")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^(?=.*[A-Za-z])[A-Za-z\d\s.,0-9@#$%*():;""""'/?!+=_-]{6,}$", ErrorMessage = "Password is invalid (e.g. p@ssw0rD_")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public ISpotUser GetSpotUser
        {
            get
            {
                if (Email.IsNullOrEmpty() || FirstName.IsNullOrEmpty() || LastName.IsNullOrEmpty())
                {
                    throw new NullReferenceException();
                }

                return new SpotUser
                {
                    Email = Email,
                    FirstName = FirstName,
                    LastName = LastName,
                    MyBusinesses = new List<UserBusiness>(),
                    MyEvents = new List<UserEvent>(),
                    MyGroups = new List<UserGroup>()
                };
            }
        }
    }
}