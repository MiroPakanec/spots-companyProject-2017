using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using spots.Models.Business;

namespace DbManager.Collections
{
    internal class BusinessCollection
    {
        public static string BID1 = "58e4c79fb7e8eb4cd082b72b";
        public static string BID2 = "58e4c79fb7e8eb4cd082b71c";

        internal static IEnumerable<Business> Businesses => new List<Business>
        {
            new Business
            {
                Id = ObjectId.Parse(BID1),
                Name = "Ucn",
                TaxNumber = "123456123",
                PhoneNumber = "+4564546666",
                Occupation = "Education",
                Description = "Not specified.",
                CreatedBy = UserCollection.UEmail1,
                Members = new HashSet<string>
                {
                    UserCollection.UEmail1,
                    UserCollection.UEmail2
                },
                Headquarters = new HashSet<BusinessHeadquaters>
                {
                    new BusinessHeadquaters
                    {
                        Id = ObjectId.Parse(LocationCollection.LID1),
                        City = "Aalborg"
                    },
                    new BusinessHeadquaters
                    {
                        Id = ObjectId.Parse(LocationCollection.LID2),
                        City = "Aarhus"
                    }
                },
                Group = ObjectId.Parse(GroupCollection.GID1)
            },
                        new Business
            {
                Id = ObjectId.Parse(BID2),
                Name = "My Restaurant",
                TaxNumber = "123456124",
                PhoneNumber = "+4564546667",
                Occupation = "Hospitality",
                Description = "Not specified.",
                CreatedBy = UserCollection.UEmail3,
                Members = new HashSet<string>
                {
                    UserCollection.UEmail2,
                    UserCollection.UEmail3
                },
                Headquarters = new HashSet<BusinessHeadquaters>
                {
                    new BusinessHeadquaters
                    {
                        Id = ObjectId.Parse(LocationCollection.LID3),
                        City = "Aalborg"
                    }
                },
                Group = ObjectId.Parse(GroupCollection.GID2)
            }
        };
    }
}
