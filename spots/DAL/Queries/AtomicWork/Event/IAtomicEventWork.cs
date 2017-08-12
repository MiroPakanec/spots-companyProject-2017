using System.Collections.Generic;
using MongoDB.Bson;
using spots.Models.Event.Interfaces;
using spots.Models.Event.ViewModels;
using spots.Models.User.Interfaces;

namespace spots.DAL.Queries.AtomicWork.Event
{
    public interface IAtomicEventWork : IAtomicWork
    {
        IEventDetails GetEventDetails(ObjectId eventId);
        IEventDetails GetEventDetails(string eventId);

        IEnumerable<EventDetailsViewModel> SearchEvents(string city, BsonDateTime date, int skip, string orderBy);

        void Add(IEvent anEvent, IUserEvent userEvent);
    }
}
