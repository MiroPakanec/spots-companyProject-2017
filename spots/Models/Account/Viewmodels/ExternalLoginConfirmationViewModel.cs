using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Castle.Core.Internal;
using spots.Models.User;
using spots.Models.User.Interfaces;

namespace spots.Models.Account.Viewmodels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

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
                    MyEvents = new List<UserEvent>()
                };
            }
        }
    }
}