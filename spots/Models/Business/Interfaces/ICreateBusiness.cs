using MongoDB.Bson;
using spots.Models.Location.Interfaces;

namespace spots.Models.Business.Interfaces
{
    public interface ICreateBusiness
    {
        ObjectId BusinessId { get; set; }
        ObjectId LocationId { get; set; }

        string Name { get; set; }
        string TaxNumber { get; set; }
        string PhoneNumber { get; set; }
        string CreatedBy { get; set; }

        string Address { get; set; }
        string Zip { get; set; }
        string City { get; set; }
        string Country { get; set; }

        IBusiness GetBusinessFromViewModel { get; }
        ILocation GetLocationFromViewModel { get; }
    }
}
