using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using spots.Models.Business.Interfaces;

namespace spots.Models.Business
{
    public class BusinessHeadquaters : IBusinessHeadquaters
    {
        public ObjectId Id { get; set; }

        [BsonIgnore]
        public string MongoId
        {
            get { return Id.ToString(); }
            set { Id = ObjectId.Parse(value); }
        }
        public string City { get; set; }
    }
}