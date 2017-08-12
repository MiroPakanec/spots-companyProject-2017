using System.Collections.Generic;
using MongoDB.Bson;
using spots.DAL.Queries.Repositories.Business;

namespace spots.Models.Business.Interfaces
{
    public interface IBusiness
    {
        ObjectId Id { get; set; }
        string MongoId { get; set; }

        string Name { get; set; }
        string TaxNumber { get; set; }
        string PhoneNumber { get; set; }

        string Occupation { get; set; }
        string Description { get; set; }
        
        string CreatedBy { get; set; }

        ISet<string> Members { get; set; }
        ISet<BusinessHeadquaters> Headquarters { get; set; }
        ObjectId Group { get; set; }

        IBusinessHeadquaters CreateHeadquaters(ObjectId locationId, string city);
        IBusinessRepository Repository { get; }

        void AddMemeberToList(string userEmail);
        void AddHeadquarterToList(ObjectId id, string city);
    }
}
