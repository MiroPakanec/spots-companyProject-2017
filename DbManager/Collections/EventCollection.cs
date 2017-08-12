using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using spots.Models.Business;
using spots.Models.Event;

namespace DbManager.Collections
{
    internal static class EventCollection
    {
        public static string EID1 = "58c80f7cb7e8ed65d04ece31";
        public static string EID2 = "58c80f7cb7e8ed65d04ece32";
        public static string EID3 = "58c80f7cb7e8ed65d04ece33";
        public static string EID4 = "58c80f7cb7e8ed65d04ece34";
        public static string EID5 = "58c80f7cb7e8ed65d04ece35";
        public static string EID6 = "58c80f7cb7e8ed65d04ece36";
        public static string EID7 = "58c80f7cb7e8ed65d04ece3b";
        public static string EID8 = "58c80f7cb7e8ed65d04ece38";
        public static string EID9 = "58c80f7cb7e8ed65d04ece39";
        public static string EID10 = "58c80f7cb7e8ed65d04ece3a";



        internal static IEnumerable<Event> Events => new List<Event>
        {
            new Event
            {
                Id = ObjectId.Parse(EID1),
                BusinessId = ObjectId.Parse(BusinessCollection.BID1),
                Title = "Computer Science lecture 1",
                Description = "Not specified",
                Availability = false,
                Visibility = false,
                City = "Aalborg",
                SpotId = ObjectId.Parse(SpotsCollection.SID1),
                StartDateTime = DateTime.Now.AddHours(1),
                EndDateTime = DateTime.Now.AddHours(2).AddMinutes(30),
                Invited = new List<string>
                {
                    UserCollection.UID1,
                    UserCollection.UID2
                }
            },
            new Event
            {
                Id = ObjectId.Parse(EID3),
                BusinessId = ObjectId.Parse(BusinessCollection.BID1),
                Title = "Computer Science lecture 2",
                Description = "Not specified",
                Availability = false,
                Visibility = true,
                City = "Aalborg",
                SpotId = ObjectId.Parse(SpotsCollection.SID1),
                StartDateTime = DateTime.Now.AddDays(1).AddHours(5),
                EndDateTime = DateTime.Now.AddDays(1).AddHours(7).AddMinutes(30),
                Invited = new List<string>
                {
                    UserCollection.UID1,
                    UserCollection.UID2
                }
            },
            new Event
            {
                Id = ObjectId.Parse(EID4),
                BusinessId = ObjectId.Parse(BusinessCollection.BID1),
                Title = "Computer Science lecture 3",
                Description = "Not specified",
                Availability = false,
                Visibility = true,
                City = "Aalborg",
                SpotId = ObjectId.Parse(SpotsCollection.SID4),
                StartDateTime = DateTime.Now.AddDays(2).AddHours(5),
                EndDateTime = DateTime.Now.AddDays(2).AddHours(7).AddMinutes(30),
                Invited = new List<string>
                {
                    UserCollection.UID1,
                    UserCollection.UID2
                }
            },
            new Event
            {
                Id = ObjectId.Parse(EID5),
                BusinessId = ObjectId.Parse(BusinessCollection.BID1),
                Title = "Computer Science lecture 4",
                Description = "Not specified",
                Availability = false,
                Visibility = true,
                City = "Aalborg",
                SpotId = ObjectId.Parse(SpotsCollection.SID5),
                StartDateTime = DateTime.Now.AddDays(3).AddHours(5),
                EndDateTime = DateTime.Now.AddDays(3).AddHours(7).AddMinutes(30),
                Invited = new List<string>
                {
                    UserCollection.UID1,
                    UserCollection.UID2
                }
            },
            new Event
            {
                Id = ObjectId.Parse(EID2),
                BusinessId = ObjectId.Parse(BusinessCollection.BID2),
                Title = "Meeting at restaurant",
                Description = "Not specified",
                Availability = false,
                Visibility = true,
                City = "Aalborg",
                SpotId = ObjectId.Parse(SpotsCollection.SID14),
                StartDateTime = DateTime.Now.AddHours(5),
                EndDateTime = DateTime.Now.AddHours(7).AddMinutes(30),
                Invited = new List<string>
                {
                    UserCollection.UID3,
                    UserCollection.UID1
                }
            },
            new Event
            {
                Id = ObjectId.Parse(EID6),
                BusinessId = ObjectId.Parse(BusinessCollection.BID2),
                Title = "Lunch",
                Description = "Not specified",
                Availability = false,
                Visibility = true,
                City = "Aalborg",
                SpotId = ObjectId.Parse(SpotsCollection.SID8),
                StartDateTime = DateTime.Now.AddDays(1).AddHours(5),
                EndDateTime = DateTime.Now.AddDays(1).AddHours(7).AddMinutes(30),
                Invited = new List<string>
                {
                    UserCollection.UID2,
                    UserCollection.UID1
                }
            },
            new Event
            {
                Id = ObjectId.Parse(EID7),
                BusinessId = ObjectId.Parse(BusinessCollection.BID2),
                Title = "Business meeting",
                Description = "Not specified",
                Availability = false,
                Visibility = true,
                City = "Aalborg",
                SpotId = ObjectId.Parse(SpotsCollection.SID7),
                StartDateTime = DateTime.Now.AddDays(-2).AddHours(5),
                EndDateTime = DateTime.Now.AddDays(-2).AddHours(7).AddMinutes(30),
                Invited = new List<string>
                {
                    UserCollection.UID2,
                    UserCollection.UID3
                }
            },
            new Event
            {
                Id = ObjectId.Parse(EID9),
                BusinessId = ObjectId.Parse(BusinessCollection.BID2),
                Title = "Marketing final exam",
                Description = "Not specified",
                Availability = false,
                Visibility = true,
                City = "Aalborg",
                SpotId = ObjectId.Parse(SpotsCollection.SID6),
                StartDateTime = DateTime.Now.AddDays(-5).AddHours(2),
                EndDateTime = DateTime.Now.AddDays(-5).AddHours(2).AddMinutes(45),
                Invited = new List<string>
                {
                    UserCollection.UID2,
                    UserCollection.UID1
                }
            },
            new Event
            {
                Id = ObjectId.Parse(EID8),
                BusinessId = ObjectId.Parse(BusinessCollection.BID2),
                Title = "Birthday party",
                Description = "Not specified",
                Availability = false,
                Visibility = true,
                City = "Aalborg",
                SpotId = ObjectId.Parse(SpotsCollection.SID6),
                StartDateTime = DateTime.Now.AddDays(5).AddHours(2),
                EndDateTime = DateTime.Now.AddDays(5).AddHours(5).AddMinutes(30),
                Invited = new List<string>
                {
                    UserCollection.UID1,
                    UserCollection.UID2,
                    UserCollection.UID3
                }
            },
        };

    }
}

