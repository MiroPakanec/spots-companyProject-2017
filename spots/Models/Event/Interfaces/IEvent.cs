    using System.Collections.Generic;
using MongoDB.Bson;
using spots.DAL.Queries.Repositories.Event;

namespace spots.Models.Event.Interfaces
{
    public interface IEvent
    {
        ObjectId Id { get; set; }
        string MongoId { get; set; }

        string Title { get; set; }
        string Description { get; set; }

        string City { get; set; }
        ObjectId SpotId { get; set; }
        ObjectId BusinessId { get; set; }

        bool Availability { get; set; }
        bool Visibility { get; set; }

        BsonDateTime StartDateTime { get; set; }
        BsonDateTime EndDateTime { get; set; }

        List<string> Invited { get; set; }

        IEventRepository Repository { get; }
    }
}
