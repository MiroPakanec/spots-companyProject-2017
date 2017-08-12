using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using spots.Models.User.Interfaces;

namespace spots.Models.Location.ViewModels
{
    public class CreateLocationViewModel
    {
        public IList<LocationBusiness> Businesses { get; set; }

        public ObjectId LocationId { get; set; }

        [BsonIgnore]
        public string MongoLocationId
        {
            get { return LocationId.ToString(); }
            set { LocationId = ObjectId.Parse(value); }
        }

        [Required(ErrorMessage = "You have to select a business")]
        public ObjectId BusinessId { get; set; }

        [BsonIgnore]
        public string MongoBusinessId
        {
            get { return BusinessId.ToString(); }
            set { BusinessId = ObjectId.Parse(value); }
        }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(30, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 3)]
        [RegularExpression(@"^(?!\s)(?!.*\s$)(?=.*[a-zA-Z0-9])[a-zA-Z0-9\s.'~?!]{3,}$", ErrorMessage = "Location name is invalid (e.g. My Location)")]
        [DisplayName("Location name")]
        public string LocationName { get; set; }

        [DisplayName("Address")]
        [Required(ErrorMessage = "Please enter the Address")]
        [StringLength(50, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 8)]
        [RegularExpression(@"[A-Z]{1,1}[a-zA-Z\s-._,\d]*[A-Za-z0-9]$", ErrorMessage = "Address is invalid (e.g. Somestreet 25A)")]
        public string Address { get; set; }

        [Required]
        [DisplayName("City")]
        [StringLength(20, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 3)]
        [RegularExpression(@"[A-Z]{1,1}[a-zA-Z\s-._,]*[a-z]$", ErrorMessage = "City name is invalid (e.g. Aalborg)")]
        public string City { get; set; }

        [Required]
        [DisplayName("Zip code")]
        [StringLength(10, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 3)]
        [RegularExpression(@"[0-9]{1,}[0-9-\s]*[0-9]", ErrorMessage = "Zip code is invalid (e.g. 1234, 123-456, 123 456)")]
        public string Zip { get; set; }

        [Required]
        [DisplayName("Country")]
        [StringLength(20, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 3)]
        [RegularExpression(@"[A-Z]{1,1}[a-z\s]*[a-z]$", ErrorMessage = "Country is invalid (e.g. Denmark)")]
        public string Country { get; set; }

        public CreateLocationViewModel(){}

        public CreateLocationViewModel(IEnumerable<IUserBusiness> userBusinesses, string selectedBusinessId)
        {
            if (selectedBusinessId == null)
            {
                selectedBusinessId = "";
            }

            CreateBusinesses(userBusinesses, selectedBusinessId);
        }

        private void CreateBusinesses(IEnumerable<IUserBusiness> userBusinesses, string selectedBusinessId)
        {
            var businesses = new List<LocationBusiness>();

            foreach (var userBusiness in userBusinesses)
            {
                var selected = userBusiness.Id.ToString().Equals(selectedBusinessId);
                var locationBusiness = CreateBusiness(userBusiness, selected);
                businesses.Add(locationBusiness);
            }

            if (businesses.Count <= 0)
            {
                throw new Exception("User businesses are empty.");

            }

            Businesses = businesses;
        }

        private static LocationBusiness CreateBusiness(IUserBusiness business, bool isSelected)
        {
            return new LocationBusiness
            {
                Id = business.Id,
                Name = business.Name,
                Selected = isSelected
            };
        }
       
    }
}