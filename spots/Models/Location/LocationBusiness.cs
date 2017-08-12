using MongoDB.Bson;

namespace spots.Models.Location
{
    public class LocationBusiness
    {
        public string Name { get; set; }
        public ObjectId Id { get; set; }
        public string MongoId { get; set; }
        public bool Selected { get; set; }
    }
}