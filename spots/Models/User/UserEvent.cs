using System;
using MongoDB.Bson;
using MongoDB.Driver;
using spots.DAL.Mongo.Context.Interfaces;
using spots.Models.Event.Interfaces;
using spots.Models.User.Interfaces;
using spots.Services.DateService;

namespace spots.Models.User
{
    public class UserEvent : IUserEvent
    {
        private readonly IMongoContext _mongoContext;

        public ObjectId EventId { get; set; }
        public BsonDateTime StartDateTime { get; set; }
        public BsonDateTime Joined { get; set; }

        public UserEvent() { }

        public UserEvent(IMongoContext mongoContext)
        {
            _mongoContext = mongoContext;
        }

        public IUserEvent InitializeFromEvent(IEvent myEvent)
        {
            EventId = myEvent.Id;
            StartDateTime = myEvent.StartDateTime;
            Joined = DateService.ToBson(DateTime.Now);

            return this;
        }

        public IUserEvent GetUserEvent(ObjectId eventId, ObjectId userId)
        {
            var user =_mongoContext.SpotUsers.Find(u => u.Id == userId).First();

            foreach (var userEvent in user.MyEvents)
            {
                if (userEvent.EventId == eventId)
                {
                    return userEvent;
                }
            }

            throw new Exception("User event could not be found");
        }
    }
}