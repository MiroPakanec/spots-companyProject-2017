using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using spots.Models.Business.Interfaces;
using spots.Models.Location.Interfaces;

namespace spots.Models.Business.ViewModels
{
    public class CreateBusinessViewModel : ICreateBusiness
    {
        public ObjectId BusinessId { get; set; }
        public ObjectId LocationId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(30, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 3)]
        [RegularExpression(@"^(?!\s)(?!.*\s$)(?=.*[a-zA-Z0-9])[a-zA-Z0-9\s.'~?!]{3,}$", ErrorMessage = "Business name is invalid (e.g. My Business s.r.o.")]
        [DisplayName("Business name")]
        public string Name { get; set; }

        [Required]
        [RegularExpression("[0-9]*", ErrorMessage = "Tax number is invalid (e.g. 123456)")]
        [StringLength(20, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 6)]
        [DisplayName("Tax number")]
        public string TaxNumber { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(30, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 8)]
        [RegularExpression(@"[+]{1,1}[0-9\s-]*[0-9]$", ErrorMessage = "Phone number is invalid (e.g. +45123456)")]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }

        public string CreatedBy { get; set; }

        [Required]
        [DisplayName("Address")]
        [StringLength(50, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 8)]
        [RegularExpression(@"[A-Z]{1,1}[a-zA-Z\s-._,\d]*[A-Za-z0-9]$", ErrorMessage = "Address is invalid (e.g. Somestreet 25A)")]
        public string Address { get; set; }

        [Required]
        [DisplayName("Zip code")]
        [StringLength(10, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 3)]
        [RegularExpression(@"[0-9]{1,}[0-9-\s]*[0-9]", ErrorMessage = "Zip code is invalid (e.g. 1234, 123-456, 123 456)")]
        public string Zip { get; set; }

        [Required]
        [DisplayName("City")]
        [StringLength(20, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 3)]
        [RegularExpression(@"[A-Z]{1,1}[a-zA-Z\s-._,]*[a-z]$", ErrorMessage = "City name is invalid (e.g. Aalborg)")]
        public string City { get; set; }

        [Required]
        [DisplayName("Country")]
        [StringLength(20, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 3)]
        [RegularExpression(@"[A-Z]{1,1}[a-z\s]*[a-z]$", ErrorMessage = "Country is invalid (e.g. Denmark)")]
        public string Country { get; set; }

        public IBusiness GetBusinessFromViewModel
        {
            get
            {
                if (BusinessId == ObjectId.Empty)
                {
                    BusinessId = ObjectId.GenerateNewId();
                }

                if (LocationId == ObjectId.Empty)
                {
                    LocationId = ObjectId.GenerateNewId();
                }

                var business = new Business
                {
                    Id = BusinessId,
                    Name = Name,
                    TaxNumber = TaxNumber,
                    PhoneNumber = PhoneNumber,
                    CreatedBy = CreatedBy,
                };

                business.AddMemeberToList(CreatedBy);

                business.AddHeadquarterToList(LocationId, City);

                return business;
            }
        }

        public ILocation GetLocationFromViewModel
        {
            get
            {
                if (BusinessId == ObjectId.Empty)
                {
                    BusinessId = ObjectId.GenerateNewId();
                }

                if (LocationId == ObjectId.Empty)
                {
                    LocationId = ObjectId.GenerateNewId();
                }

                var location = new Location.Location
                {
                    Id = LocationId,
                    BusinessId = BusinessId,
                    Address = Address,
                    City = City,
                    Zip = Zip,
                    Country = Country
                };

                return location;
            }
        }
    }
}