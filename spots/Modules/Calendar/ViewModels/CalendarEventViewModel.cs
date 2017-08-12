using MongoDB.Bson;
using spots.Services.Calendar;
using spots.Services.DateService;

namespace spots.Modules.Calendar.ViewModels
{
    public class CalendarEventViewModel
    {
        public string MongoId { get; set; }
        public string Time { get; set; }
        public string Title { get; set; }

        public void TimeFromBson(BsonDateTime datetime)
        {
            Time = datetime.ToLocalTime().ToString(CalendarHelper.TimeFormat);
        }
    }
}