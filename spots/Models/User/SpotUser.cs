using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using spots.DAL.Mongo.Context.Interfaces;
using spots.DAL.Queries.Repositories.SpotUser;
using spots.Models.Business.Interfaces;
using spots.Models.Event.Interfaces;
using spots.Models.Group.Interfaces;
using spots.Models.Location.Interfaces;
using spots.Models.User.Interfaces;
using spots.Services.DateService;

namespace spots.Models.User
{
    public class SpotUser : ISpotUser
    {
        private readonly IMongoContextGeneric<SpotUser> _context;

        public virtual string City { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public ObjectId Id { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string MongoId
        {
            get { return Id.ToString(); }
            set { Id = ObjectId.Parse(value); }
        }

        public string Phone { get; set; }

        public IList<UserBusiness> MyBusinesses { get; set; }

        public IList<UserEvent> MyEvents { get; set; }

        public IEnumerable<UserGroup> MyGroups { get; set; }

        public SpotUser() { }

        public SpotUser(IMongoContextGeneric<SpotUser> context)
        {
            _context = context;
        }

        public ISpotUserRepository Repository => new SpotUserRepository(_context);

        public IUserEvent UserEvent(IEvent uEvent)
        {
            return new UserEvent
            {
                EventId = uEvent.Id,
                StartDateTime = uEvent.StartDateTime,
                Joined = DateService.ToBson(DateTime.Now)
            };
        }

        public IUserBusiness UserBusiness(IBusiness business, ILocation location)
        {
            return new UserBusiness
            {
                Id = business.Id,
                Name = business.Name,
                Location = $"{location.Address} {location.City} {location.Country}",
                StartDate = BsonDateTime.Create(DateTime.Now)
            };
        }
    }
}