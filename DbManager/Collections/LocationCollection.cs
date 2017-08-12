using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using spots.Models.Location;

namespace DbManager.Collections
{
    internal static class LocationCollection
    {
        public static string LID1 = "58e4c79fb7e8eb4cd082a71c";
        public static string LID2 = "58e4d61bb7e8ed76fc04fbc8";
        public static string LID3 = "58e4d61bb7e8ed76fc04fbc9";

        public static IEnumerable<Location> Locations => new List<Location>
        {
            new Location
            {
                Id = ObjectId.Parse(LID1),
                BusinessId = ObjectId.Parse(BusinessCollection.BID1),
                Address = "Jernbanegade 12A",
                City = "Aalborg",
                Country = "Denmark",
                Zip = "9000",
                Spots = new List<ObjectId>
                {
                    ObjectId.Parse(SpotsCollection.SID1),
                    ObjectId.Parse(SpotsCollection.SID2)
                }
            },
            new Location
            {
                Id = ObjectId.Parse(LID2),
                BusinessId = ObjectId.Parse(BusinessCollection.BID1),
                Address = "Hobrovej 20",
                City = "Aalborg",
                Country = "Denmark",
                Zip = "9000",
                Spots = new List<ObjectId>
                {
                    ObjectId.Parse(SpotsCollection.SID3),
                    ObjectId.Parse(SpotsCollection.SID4),
                    ObjectId.Parse(SpotsCollection.SID5)
                }
            },
            new Location
            {
                Id = ObjectId.Parse(LID3),
                BusinessId = ObjectId.Parse(BusinessCollection.BID2),
                Address = "Vestebro 10",
                City = "Aalborg",
                Country = "Denmark",
                Zip = "9000",
                Spots = new List<ObjectId>
                {
                    ObjectId.Parse(SpotsCollection.SID6),
                    ObjectId.Parse(SpotsCollection.SID7),
                    ObjectId.Parse(SpotsCollection.SID8),
                    ObjectId.Parse(SpotsCollection.SID9),
                    ObjectId.Parse(SpotsCollection.SID10),
                    ObjectId.Parse(SpotsCollection.SID11),
                    ObjectId.Parse(SpotsCollection.SID12),
                    ObjectId.Parse(SpotsCollection.SID13),
                    ObjectId.Parse(SpotsCollection.SID14)
                }
            }
        };
    }
}
