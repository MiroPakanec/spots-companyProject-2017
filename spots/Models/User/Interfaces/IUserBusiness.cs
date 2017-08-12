using MongoDB.Bson;

namespace spots.Models.User.Interfaces
{
    public interface IUserBusiness
    {
        ObjectId Id { get; set; }
        string Name { get; set; }
        string Position { get; set; }

        BsonDateTime StartDate { get; set; }
        string StartDateFormated { get; }

        BsonDateTime EndDate { get; set; }
        string EndDateFormated { get; }

        string Location { get; set; }
    }
}
