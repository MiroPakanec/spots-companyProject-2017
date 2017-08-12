using System.Collections.Generic;
using MongoDB.Bson;
using spots.Models.Event.Interfaces;
using spots.Models.User;

namespace spots.Models.Event.ViewModels
{
    public class EventDetailsViewModel : IEventDetails
    {
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string StartDatetime { get; set; }
        public string EndDatetime { get; set; }

        public string Location { get; set; }
        public ObjectId SpotId { get; set; }
        public ObjectId BusinessId { get; set; }
        public string SpotName { get; set; }
        public string BusinessName { get; set; }

        //TODO: can be replaced with smaller view model
        public List<SpotUser> Invited { get; set; }
    }
}