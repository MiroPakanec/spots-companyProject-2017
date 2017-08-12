using System;
using MongoDB.Bson;

namespace spots.Models.Business.Extensions
{
    public static class BusinessExtensions
    {
        public static Business WithId(this Business business, ObjectId id)
        {
            business.Id = id;
            business.MongoId = id.ToString();
            return business;
        }

        public static Business WithMongoId(this Business business, string id)
        {
            business.Id = ObjectId.Parse(id);
            business.MongoId = id;
            return business;
        }

        public static Business WithName(this Business business, string name)
        {
            business.Name = name;
            return business;
        }

        public static int RoundOff(this int i)
        {
            var rounded = ((int)Math.Round(i / 10.0)) * 10;

            return rounded == 0 ? 10 : rounded;
        }

        public static string RoundOffMessage(this int amount)
        {
            return amount > amount.RoundOff() ?
                $"More than {amount.RoundOff()}" : $"Around {amount.RoundOff()}";
        }
    }
}