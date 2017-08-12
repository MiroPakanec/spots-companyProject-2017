using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using spots.Models.User;

namespace DbManager.Collections
{
    internal static class UserCollection
    {
        public static string UID1 = "58edfdd5b7e8ea2bc80a17a1";
        public static string UID2 = "58edfdd5b7e8ea2bc80a17a2";
        public static string UID3 = "58edfdd5b7e8ea2bc80a17a3";

        public static string UEmail1 = "user1@spots.com";
        public static string UEmail2 = "user2@spots.com";
        public static string UEmail3 = "user3@spots.com";

        internal static IEnumerable<SpotUser> Users => new List<SpotUser>
        {
            new SpotUser
            {
                Id = ObjectId.Parse(UID1),
                Email = UEmail1,
                FirstName = "User",
                MiddleName = "User",
                LastName = "User",
                Age = 20,
                City = "Aalborg",
                MyBusinesses = new List<UserBusiness>
                {
                    new UserBusiness
                    {
                        Id = ObjectId.Parse(BusinessCollection.BID1),
                        Name = "Ucn",
                        Position = "Owner",
                        StartDate = DateTime.Now,
                        EndDate = null,
                        Location = "Aalborg"
                    }
                },
                MyEvents = new List<UserEvent>
                {
                    new UserEvent
                    {
                        EventId = ObjectId.Parse(EventCollection.EID1),
                        Joined = DateTime.Now,
                        StartDateTime = DateTime.Now.AddHours(1)
                    },
                    new UserEvent
                    {
                        EventId = ObjectId.Parse(EventCollection.EID2),
                        Joined = DateTime.Now,
                        StartDateTime = DateTime.Now.AddHours(5)
                    },
                    new UserEvent
                    {
                        EventId = ObjectId.Parse(EventCollection.EID3),
                        Joined = DateTime.Now,
                        StartDateTime = DateTime.Now.AddDays(1).AddHours(5),
                    },
                    new UserEvent
                    {
                        EventId = ObjectId.Parse(EventCollection.EID4),
                        Joined = DateTime.Now,
                        StartDateTime = DateTime.Now.AddDays(2).AddHours(5),
                    },
                    new UserEvent
                    {
                        EventId = ObjectId.Parse(EventCollection.EID5),
                        Joined = DateTime.Now,
                        StartDateTime = DateTime.Now.AddDays(3).AddHours(5),
                    },
                    new UserEvent
                    {
                        EventId = ObjectId.Parse(EventCollection.EID6),
                        Joined = DateTime.Now,
                        StartDateTime = DateTime.Now.AddDays(1).AddHours(5),
                    },
                    new UserEvent
                    {
                        EventId = ObjectId.Parse(EventCollection.EID9),
                        Joined = DateTime.Now.AddDays(-6),
                        StartDateTime = DateTime.Now.AddDays(-5).AddHours(2),
                    },
                    new UserEvent
                    {
                        EventId = ObjectId.Parse(EventCollection.EID8),
                        Joined = DateTime.Now.AddDays(1),
                        StartDateTime = DateTime.Now.AddDays(5).AddHours(2),
                    },
                },
                MyGroups = new List<UserGroup>
                {
                    new UserGroup
                    {
                        Id = ObjectId.Parse(GroupCollection.GID1),
                        Name = "Ucn group",
                        Role = "Admin"
                    },
                    new UserGroup
                    {
                        Id = ObjectId.Parse(GroupCollection.GID3),
                        Name = "friends",
                        Role = "Admin"
                    }
                }
            },
            new SpotUser
            {
                Id = ObjectId.Parse(UID2),
                Email = UEmail2,
                FirstName = "User2",
                MiddleName = "User2",
                LastName = "User2",
                Age = 22,
                City = "Aalborg",
                MyBusinesses = new List<UserBusiness>
                {
                    new UserBusiness
                    {
                        Id = ObjectId.Parse(BusinessCollection.BID1),
                        Name = "Ucn",
                        Position = "Member",
                        StartDate = DateTime.Now,
                        EndDate = null,
                        Location = "Aalborg"
                    },
                    new UserBusiness
                    {
                        Id = ObjectId.Parse(BusinessCollection.BID2),
                        Name = "Ucn",
                        Position = "Member",
                        StartDate = DateTime.Now,
                        EndDate = null,
                        Location = "Aalborg"
                    }
                },
                MyEvents = new List<UserEvent>
                {
                    new UserEvent
                    {
                        EventId = ObjectId.Parse(EventCollection.EID1),
                        Joined = DateTime.Now,
                        StartDateTime = DateTime.Now.AddHours(1)
                    },
                    new UserEvent
                    {
                        EventId = ObjectId.Parse(EventCollection.EID3),
                        Joined = DateTime.Now,
                        StartDateTime = DateTime.Now.AddDays(1).AddHours(5),
                    },
                    new UserEvent
                    {
                        EventId = ObjectId.Parse(EventCollection.EID4),
                        Joined = DateTime.Now,
                        StartDateTime = DateTime.Now.AddDays(2).AddHours(5),
                    },
                    new UserEvent
                    {
                        EventId = ObjectId.Parse(EventCollection.EID5),
                        Joined = DateTime.Now,
                        StartDateTime = DateTime.Now.AddDays(3).AddHours(5),
                    },
                    new UserEvent
                    {
                        EventId = ObjectId.Parse(EventCollection.EID6),
                        Joined = DateTime.Now,
                        StartDateTime = DateTime.Now.AddDays(1).AddHours(5),
                    },
                    new UserEvent
                    {
                        EventId = ObjectId.Parse(EventCollection.EID7),
                        Joined = DateTime.Now.AddDays(-3),
                        StartDateTime = DateTime.Now.AddDays(-2).AddHours(5),
                    },
                    new UserEvent
                    {
                        EventId = ObjectId.Parse(EventCollection.EID9),
                        Joined = DateTime.Now.AddDays(-6),
                        StartDateTime = DateTime.Now.AddDays(-5).AddHours(2),
                    },
                    new UserEvent
                    {
                        EventId = ObjectId.Parse(EventCollection.EID8),
                        Joined = DateTime.Now.AddDays(1),
                        StartDateTime = DateTime.Now.AddDays(5).AddHours(2),
                    }
                },
                MyGroups = new List<UserGroup>
                {
                    new UserGroup
                    {
                        Id = ObjectId.Parse(GroupCollection.GID1),
                        Name = "Ucn group",
                        Role = "Member"
                    },
                    new UserGroup
                    {
                        Id = ObjectId.Parse(GroupCollection.GID2),
                        Name = "My restaurant group",
                        Role = "Member"
                    },
                    new UserGroup
                    {
                        Id = ObjectId.Parse(GroupCollection.GID4),
                        Name = "friends",
                        Role = "Admin"
                    }
                }
            },
            new SpotUser
            {
                Id = ObjectId.Parse(UID3),
                Email = UEmail3,
                FirstName = "User3",
                MiddleName = "User3",
                LastName = "User3",
                Age = 20,
                City = "Aalborg",
                MyBusinesses = new List<UserBusiness>
                {
                    new UserBusiness
                    {
                        Id = ObjectId.Parse(BusinessCollection.BID2),
                        Name = "My Restaurant",
                        Position = "Owner",
                        StartDate = DateTime.Now,
                        EndDate = null,
                        Location = "Aalborg"
                    }
                },
                MyEvents = new List<UserEvent>
                {
                    new UserEvent
                    {
                        EventId = ObjectId.Parse(EventCollection.EID2),
                        Joined = DateTime.Now,
                        StartDateTime = DateTime.Now.AddHours(5)
                    },
                    new UserEvent
                    {
                        EventId = ObjectId.Parse(EventCollection.EID7),
                        Joined = DateTime.Now.AddDays(-3),
                        StartDateTime = DateTime.Now.AddDays(-2).AddHours(5),
                    },
                    new UserEvent
                    {
                        EventId = ObjectId.Parse(EventCollection.EID8),
                        Joined = DateTime.Now.AddDays(1),
                        StartDateTime = DateTime.Now.AddDays(5).AddHours(2),
                    }
                },
                MyGroups = new List<UserGroup>
                {
                    new UserGroup
                    {
                        Id = ObjectId.Parse(GroupCollection.GID2),
                        Name = "My restaurant group",
                        Role = "Admin"
                    },
                    new UserGroup
                    {
                        Id = ObjectId.Parse(GroupCollection.GID5),
                        Name = "friends",
                        Role = "Admin"
                    }
                }
            }
        };
    }
}
