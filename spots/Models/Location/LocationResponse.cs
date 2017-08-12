using spots.Models.Location.Interfaces;

namespace spots.Models.Location
{
    public class LocationResponse :Response.Response, ILocationResponse
    {
       

        public override string GetResponseDescription()
        {
            return "Location response.";
        }

       
    }
}