using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using spots.DAL.Mongo.Context.Interfaces;
using spots.DAL.Queries.Repositories.Business;
using spots.Models.Business.Interfaces;

namespace spots.Models.Business
{
    public class Business : IBusiness
    {
        private readonly IMongoContextGeneric<Business> _context;

        public ObjectId Id { get; set; }

        [BsonIgnore]
        public string MongoId
        {
            get { return Id.ToString(); }
            set { Id = ObjectId.Parse(value); }
        }

        public string Name { get; set; }

        public string TaxNumber { get; set; }

        public string PhoneNumber { get; set; }
        public string Occupation { get; set; }
        public string Description { get; set; }

        public string CreatedBy { get; set; }
            
        public ISet<string> Members { get; set; }
        public ISet<BusinessHeadquaters> Headquarters { get; set; }
        public ObjectId Group { get; set; }

        public IBusinessRepository Repository => new BusinessRepository(_context);

        public Business(){}

        public Business(IMongoContextGeneric<Business> context)
        {
            _context = context;
        }

        public void AddMemeberToList(string userEmail)
        {
            if (Members == null)
            {
                Members = new HashSet<string>();
            }

            if (!string.IsNullOrEmpty(userEmail))
            {
                Members.Add(userEmail);
            }
        }

        public void AddHeadquarterToList(ObjectId id, string city)
        {
            if (Headquarters == null)
            {
                Headquarters = new SortedSet<BusinessHeadquaters>();
            }
            var headquater = new BusinessHeadquaters
            {
                Id = id,
                City = city
            };

            Headquarters.Add(headquater);
        }

        public IBusinessHeadquaters CreateHeadquaters(ObjectId locationId, string city)
        {   
            return new BusinessHeadquaters
            {
                Id = locationId,
                City = city
            };
        }
    }
}