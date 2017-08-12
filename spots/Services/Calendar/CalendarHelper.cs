using System;
using System.Globalization;
using Castle.Core.Internal;

namespace spots.Services.Calendar
{
    public class CalendarHelper
    {
        public static string MonthYearFormat => "MMMM yyyy";
        public static string TimeFormat => "hh:mm";

        public static string CurrentMonthYearDate => DateTime.Now.ToString(MonthYearFormat, new CultureInfo("en-US"));

        public static string MonthYearDate(DateTime date)
        {
            return date.ToString(MonthYearFormat, new CultureInfo("en-US"));
        }

        public static string MonthYearDate(string month, string year, int increment)
        {
            try
            {
                if (month.IsNullOrEmpty() || year.IsNullOrEmpty())
                {
                    return CurrentMonthYearDate;
                }

                var date = DateTime.Parse(month + " " + year).AddMonths(increment);
                return MonthYearDate(date);
            }
            catch (Exception)
            {
                return CurrentMonthYearDate;
            }

        }
    }
}