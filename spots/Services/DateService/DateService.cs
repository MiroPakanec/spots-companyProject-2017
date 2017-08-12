using System;
using MongoDB.Bson;
using spots.Services.Calendar;

namespace spots.Services.DateService
{
    public static class DateService
    {
        public static BsonDateTime ToBson(string date)
        {           
            return new BsonDateTime(DateTime.Parse(date));
        }

        public static BsonDateTime ToBson(DateTime date)
        {
            return new BsonDateTime(date);
        }

        public static BsonDateTime GetCurrentBson => ToBson(DateTime.Now);

        public static string GetBasicDateTimeFormat => "yyyy-MM-dd HH:mm";
        public static string GetBasicDateFormat => "dd-MM-yyyy";
        public static string GetBasicTimeFormat => "hh:mm";

        public static bool IsValid(string date)
        {
            DateTime datetime;

            if (DateTime.TryParse(date, out datetime) == false)
            {
                return false;
            }

            datetime = DateTime.Parse(date);
            return new BsonDateTime(datetime).IsValidDateTime;
        }

        public static string TimeFromBson(BsonDateTime datetime)
        {
            return datetime.ToLocalTime().ToString(GetBasicTimeFormat);
        }

        public static string GetRelativeSpan(string date)
        {
            const int second = 1;
            const int minute = 60 * second;
            const int hour = 60 * minute;
            const int day = 24 * hour;
            const int month = 30 * day;

            var ts = new TimeSpan(DateTime.UtcNow.Ticks - DateTime.Parse(date).Ticks);
            var delta = Math.Abs(ts.TotalSeconds);

            if (delta < 1 * minute)
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";

            if (delta < 2 * minute)
                return "a minute ago";

            if (delta < 45 * minute)
                return ts.Minutes + " minutes ago";

            if (delta < 90 * minute)
                return "an hour ago";

            if (delta < 24 * hour)
                return ts.Hours + " hours ago";

            if (delta < 48 * hour)
                return "yesterday";

            if (delta < 30 * day)
                return ts.Days + " days ago";

            if (delta < 12 * month)
            {
                var months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }

            var years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
            return years <= 1 ? "one year ago" : years + " years ago";
        }
    }
}