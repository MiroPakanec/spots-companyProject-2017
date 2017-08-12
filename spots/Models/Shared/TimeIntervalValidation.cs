using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace spots.Models.Shared
{
    public static class TimeIntervalValidation
    {
        public static bool HasValidDaylyTimeIntervals(IDictionary<string, IEnumerable<TimeInterval>>daylyIntervals)
        {
            return daylyIntervals
                .Select(i => i.Value)
                .All(HasValidIntervals);
        }

        public static bool HasValidIntervals(IEnumerable<TimeInterval> intervals)
        {
            var upperLimit = DateTime.MinValue;

            foreach (var timeInterval in intervals)
            {
                if (timeInterval.IsValid == false)
                {
                    return false;
                }

                if (timeInterval.From < upperLimit)
                {
                    return false;
                }

                upperLimit = timeInterval.To;
            }

            return true;
        }

        
    }
}