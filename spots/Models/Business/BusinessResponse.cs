using spots.Models.Business.Interfaces;

namespace spots.Models.Business
{
    public class BusinessResponse :Response.Response, IBusinessResponse
    {
 
        public override string GetResponseDescription()
        {
            return "Business response.";
        }
    }
}