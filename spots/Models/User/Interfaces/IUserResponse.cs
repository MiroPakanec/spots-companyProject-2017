using MongoDB.Driver;
using spots.Models.Response.Interfaces;

namespace spots.Models.User.Interfaces
{
    public interface IUserResponse : IResponse
    {
        ReplaceOneResult Result { get; set; }
       

        void IdentifyUpdateResult(ReplaceOneResult result);
    }
}
