using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace spots.Models.User.Interfaces
{
    public interface IUserGroup
    {
        ObjectId Id { get; set; }
        string MongoId { get; set; }
        string Name { get; set; }
        string Role { get; set; }
    }
}
