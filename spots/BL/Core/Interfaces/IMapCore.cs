using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using spots.Modules.Map.Models;

namespace spots.BL.Core.Interfaces
{
    public interface IMapCore
    {
        IEnumerable<ObjectId> GetEventSpots(string city, DateTime startDateTime, DateTime endDateTime);
        IEnumerable<string> GetAddressesFromSpots(IEnumerable<ObjectId> spotIds);
        IEnumerable<MapLocation> GetGeoLocations(IEnumerable<string> addresses);
        MapLocation GetGeoLocation(string address);
        string GetCurentLocation();

        string GetCityFilter(string city);
    }
}
