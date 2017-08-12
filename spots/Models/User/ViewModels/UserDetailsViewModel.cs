using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using spots.Models.User.Interfaces;

namespace spots.Models.User.ViewModels
{
    public class UserDetailsViewModel
    {
        public UserDetailsViewModel(ISpotUser model)
        {
            Id = model.Id;
            Email = model.Email;

            FirstName = model.FirstName;
            MiddleName = model.MiddleName;
            LastName = model.LastName;

            City = model.City;
            Age = model.Age;
            Phone = model.Phone;
        }

        public UserDetailsViewModel() { }

        [Required]
        public ObjectId Id { get; set; }

        public string MongoId
        {
            get { return Id.ToString(); }
            set { Id = ObjectId.Parse(value); }
        }

        [BsonIgnoreIfNull]
        [DisplayName("City")]
        [StringLength(30, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 3)]
        [RegularExpression(@"[A-Z]{1,1}[a-zA-Z\s-._,]*[a-z]$", ErrorMessage = "City name is invalid (e.g. Aalborg)")]
        public string City { get; set; }

        [DisplayName("Age")]
        [DefaultValue(18)]
        [Range(18, 100, ErrorMessage = "Age is invalid (e.g. 25)")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Age must be a number.")]
        public int Age { get; set; }

        [DisplayName("Email address")]
        [Required]
        [EmailAddress(ErrorMessage = "Email address is invalid.")]
        [DataType(DataType.EmailAddress)]
        [StringLength(40, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 8)]
        public string Email { get; set; }

        [DisplayName("First name")]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(30, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 3)]
        [RegularExpression("[A-Z]{1,1}[a-z]*$", ErrorMessage = "First name is invalid (e.g. John)")]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Last name")]
        [StringLength(30, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 3)]
        [RegularExpression("[A-Z]{1,1}[a-z]*$", ErrorMessage = "Last name is invalid (e.g. Smith)")]
        public string LastName { get; set; }

        [BsonIgnoreIfNull]
        [DataType(DataType.Text)]
        [DisplayName("Middle name")]
        [StringLength(30, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 3)]
        [RegularExpression("[A-Z]{1,1}[a-z]*$", ErrorMessage = "Middle name is invalid (e.g. Muriel)")]
        public string MiddleName { get; set; }

        [BsonIgnoreIfNull]
        [DisplayName("Phone number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(30, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 8)]
        [RegularExpression(@"[+]{1,1}[0-9\s-]*[0-9]$", ErrorMessage = "Phone number is invalid (e.g. +45123456)")]
        public string Phone { get; set; }
    }
}