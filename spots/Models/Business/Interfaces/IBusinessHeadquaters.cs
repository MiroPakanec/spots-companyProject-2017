using MongoDB.Bson;

namespace spots.Models.Business.Interfaces
{
    public interface IBusinessHeadquaters
    {
        ObjectId Id { get; set; }
        string MongoId { get; set; }
        string City { get; set; }
    }
}
