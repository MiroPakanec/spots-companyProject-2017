using MongoDB.Bson;
using spots.Models.User.Interfaces;
using spots.Services.DateService;

namespace spots.Models.User
{
    public class UserBusiness : IUserBusiness
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }

        public BsonDateTime StartDate { get; set; }
        public string StartDateFormated => StartDate.ToLocalTime().ToString(DateService.GetBasicDateTimeFormat);

        public BsonDateTime EndDate { get; set; }
        public string EndDateFormated => EndDate?.ToLocalTime().ToString(DateService.GetBasicDateTimeFormat) ?? "present";

        public string Location { get; set; }
    }
}