using spots.Models.Event.Interfaces;

namespace spots.Models.Event
{
    public class EventResponse :Response.Response, IEventResponse
    {
       

        public override string GetResponseDescription()
        {
            return "Event response";
        }
    }
}