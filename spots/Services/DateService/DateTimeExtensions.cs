using System;

namespace spots.Services.DateService
{
    public static class DateTimeExtensions
    {
        public static int GetDayPosition(this DateTime dateTime)
        {
            return (int)(dateTime.DayOfWeek + 6) % 7;
        }
       
    }
}