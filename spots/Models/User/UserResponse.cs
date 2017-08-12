using MongoDB.Driver;
using spots.Models.User.Interfaces;

namespace spots.Models.User
{
    public class UserResponse :Response.Response, IUserResponse
    {
        public ReplaceOneResult Result { get; set; }
        
        public void IdentifyUpdateResult(ReplaceOneResult result)
        {
            Result = result;
            Success = Result != null && Result.ModifiedCount > 0;

            if (Result == null)
            {
                ResponseText = "Update has failed. Please try again later.";
            }
            else if (Result.MatchedCount <= 0)
            {
                ResponseText = "Update has failed, because user could not be found. Please try again later.";
            }
            else if (Result.ModifiedCount <= 0)
            {
                ResponseText = "Update has failed, because user could not be modified. Please try again later.";
            }
            else
            {
                ResponseText = "Update successfull";
            }
        }

        public override string GetResponseDescription()
        {
            return "User response.";
        }
    }
}