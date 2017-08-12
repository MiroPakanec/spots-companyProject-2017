using MongoDB.Bson;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace spots.Models.Spot.ViewModels
{
    public class CreateSpotViewModel
    {
        public ObjectId Id { get; set; }
        public string MongoId { get; set; }

        [Required]
        [DisplayName("Business")]
        public string BusinessId { get; set; }
        [Required]
        [DisplayName("Location")]
        public string LocationId { get; set; }


        [Required]
        [DataType(DataType.Text)]
        [StringLength(30, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 3)]
        [RegularExpression(@"^(?!\s)(?!.*\s$)(?=.*[a-zA-Z0-9])[a-zA-Z0-9\s.'~?!]{3,}$", ErrorMessage = "Spot name is invalid (e.g. My Spot)")]
        [DisplayName("Spot name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Capacity")]
        [Range(1, 5000, ErrorMessage = "The {0} must be between {1} and {2} characters long.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Capacity must be a number.")]
        public int Capacity { get; set; }
        public bool Visible { get; set; }
    }
}