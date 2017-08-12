using System.Collections.Generic;
using MongoDB.Bson;
using spots.Models.User;

namespace spots.Models.Event.Interfaces
{
    public interface IEventDetails
    {
        ObjectId Id { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        string StartDatetime { get; set; }
        string EndDatetime { get; set; }
        
        string Location { get; set; }
        ObjectId SpotId { get; set; }
        ObjectId BusinessId { get; set; }
        string SpotName { get; set; }
        string BusinessName { get; set; }
        List<SpotUser> Invited { get; set; }
    }
}
