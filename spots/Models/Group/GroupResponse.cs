using spots.Models.Group.Interfaces;

namespace spots.Models.Group
{
    public class GroupResponse :Response.Response, IGroupResponse
    {
     
        public override string GetResponseDescription()
        {
            return "Group response.";
        }
    }
}