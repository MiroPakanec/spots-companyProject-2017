using MongoDB.Bson;
using spots.Services.Calendar;

namespace spots.Modules.Calendar.ViewModels
{
    public class CalendarFeatureEventViewModel
    {
        public string MongoId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Title { get; set; }

        public string TimeFromBson(BsonDateTime datetime)
        {
            return datetime.ToLocalTime().ToString(CalendarHelper.TimeFormat);
        }
    }
}