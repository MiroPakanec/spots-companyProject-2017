using MongoDB.Driver;
using spots.Models.Business;
using spots.Models.Event;
using spots.Models.Location;
using spots.Models.Spot;
using spots.Models.User;

namespace spots.DAL.Mongo.Context.Interfaces
{
    public interface IMongoContext
    {
        IMongoDatabase Database { get; }

        IMongoCollection<SpotUser> SpotUsers { get; }
        IMongoCollection<Business> Businesses { get; }
        IMongoCollection<Location> Locations { get; }
        IMongoCollection<Spot> Spots { get; }
        IMongoCollection<Event> Events { get; }
    }
}
