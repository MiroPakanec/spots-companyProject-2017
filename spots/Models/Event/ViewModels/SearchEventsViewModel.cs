using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using spots.Services.DateService;

namespace spots.Models.Event.ViewModels
{
    public class SearchEventsViewModel
    {
        [Required(ErrorMessage = "Please enter a city")]
        [DisplayName("City")]
        [StringLength(20, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 3)]
        [RegularExpression(@"[A-Z]{1,1}[a-zA-Z\s-._,]*[a-z]$", ErrorMessage = "City name is invalid (e.g. Aalborg)")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please select a date")]
        [DisplayName("Date")]
        public string Date { get; set; }

        public bool HasValidDate => DateService.IsValid(Date);
    }
}