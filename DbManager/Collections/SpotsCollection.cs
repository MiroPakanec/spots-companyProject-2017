using System;
using System.Collections.Generic;
using MongoDB.Bson;
using spots.Models.Shared;
using spots.Models.Spot;

namespace DbManager.Collections
{
    internal static class SpotsCollection
    {
        public static string SID1 = "58e4c79fb7e8eb4cd082a72c";
        public static string SID2 = "58e4d61bb7e8ed76fc04fcc8";

        public static string SID3 = "58e4d61bb7e8ed76fc04fcf8";
        public static string SID4 = "58e4d61bb7e8ed76fc04fcc9";
        public static string SID5 = "58e4d61bb7e8ed76fc04fcc6";

        public static string SID6 = "58e4d61bb7e8ed76fc04fcc2";
        public static string SID7 = "58e4d61bb7e8ed76fc04fcc3";
        public static string SID8 = "58e4d61bb7e8ed76fc04fcc4";
        public static string SID9 = "58e4d61bb7e8ed76fc04fcc5";
        public static string SID10 = "58e4d61bb7e8ed76fc04fcf6";
        public static string SID11 = "58e4d61bb7e8ed76fc04fcd1";
        public static string SID12 = "58e4d61bb7e8ed76fc04fcd2";
        public static string SID13 = "58e4d61bb7e8ed76fc04fcd3";
        public static string SID14 = "58e4d61bb7e8ed76fc04fcd4";


        public static IEnumerable<Spot> Spots => new List<Spot>
        {
            new Spot
            {
                Id = ObjectId.Parse(SID1),
                LocationId = ObjectId.Parse(LocationCollection.LID1),
                Capacity = 5,
                DaylyAvailableHours = GetIntervalDictionary,
                Name = "Jernbanegade Class 1",
                Visible = false
            },
            new Spot
            {
                Id = ObjectId.Parse(SID2),
                LocationId = ObjectId.Parse(LocationCollection.LID1),
                Capacity = 5,
                DaylyAvailableHours = GetIntervalDictionary,
                Name = "Jernbanegade Class 2",
                Visible = true
            },
            new Spot
            {
                Id = ObjectId.Parse(SID3),
                LocationId = ObjectId.Parse(LocationCollection.LID2),
                Capacity = 10,
                DaylyAvailableHours = GetIntervalDictionary,

                Name = "Hobrovej Class 1",
                Visible = true
            },
            new Spot
            {
                Id = ObjectId.Parse(SID4),
                LocationId = ObjectId.Parse(LocationCollection.LID2),
                Capacity = 10,
                DaylyAvailableHours = GetIntervalDictionary,

                Name = "Hobrovej Class 1",
                Visible = true
            },
            new Spot
            {
                Id = ObjectId.Parse(SID5),
                LocationId = ObjectId.Parse(LocationCollection.LID2),
                Capacity = 10,
                DaylyAvailableHours = GetIntervalDictionary,

                Name = "Hobrovej Class 1",
                Visible = true
            },
            new Spot
            {
                Id = ObjectId.Parse(SID6),
                LocationId = ObjectId.Parse(LocationCollection.LID3),
                Capacity = 4,
                DaylyAvailableHours = GetIntervalDictionary,

                Name = "Table 1",
                Visible = true
            },
            new Spot
            {
                Id = ObjectId.Parse(SID7),
                LocationId = ObjectId.Parse(LocationCollection.LID3),
                Capacity = 4,
                DaylyAvailableHours = GetIntervalDictionary,

                Name = "Table 2",
                Visible = true
            },
            new Spot
            {
                Id = ObjectId.Parse(SID8),
                LocationId = ObjectId.Parse(LocationCollection.LID3),
                Capacity = 4,
                DaylyAvailableHours = GetIntervalDictionary,

                Name = "Table 3",
                Visible = true
            },
            new Spot
            {
                Id = ObjectId.Parse(SID9),
                LocationId = ObjectId.Parse(LocationCollection.LID3),
                Capacity = 4,
                DaylyAvailableHours = GetIntervalDictionary,

                Name = "Table 4",
                Visible = true
            },
            new Spot
            {
                Id = ObjectId.Parse(SID10),
                LocationId = ObjectId.Parse(LocationCollection.LID3),
                Capacity = 4,
                DaylyAvailableHours = GetIntervalDictionary,

                Name = "Table 5",
                Visible = true
            },
            new Spot
            {
                Id = ObjectId.Parse(SID11),
                LocationId = ObjectId.Parse(LocationCollection.LID3),
                Capacity = 4,
                DaylyAvailableHours = GetIntervalDictionary,

                Name = "Table 6",
                Visible = true
            },
            new Spot
            {
                Id = ObjectId.Parse(SID12),
                LocationId = ObjectId.Parse(LocationCollection.LID3),
                Capacity = 4,
                DaylyAvailableHours = GetIntervalDictionary,

                Name = "Table 7",
                Visible = true
            },
            new Spot
            {
                Id = ObjectId.Parse(SID13),
                LocationId = ObjectId.Parse(LocationCollection.LID3),
                Capacity = 4,
                DaylyAvailableHours = GetIntervalDictionary,

                Name = "Table 8",
                Visible = true
            },
            new Spot
            {
                Id = ObjectId.Parse(SID14),
                LocationId = ObjectId.Parse(LocationCollection.LID3),
                Capacity = 4,
                DaylyAvailableHours = GetIntervalDictionary,

                Name = "Table 9",
                Visible = true
            }
        };

        private static IDictionary<string, IEnumerable<TimeInterval>> GetIntervalDictionary => new Dictionary<string, IEnumerable<TimeInterval>>()
        {
            { "Monday", GetWeekDayTimeIntervals},
            { "Tuesday", GetWeekDayTimeIntervals},
            { "Wednesday", GetWeekDayTimeIntervals},
            { "Thursday", GetWeekDayTimeIntervals},
            { "Friday", GetWeekDayTimeIntervals},
            { "Saturday", GetWeekendTimeIntervals},
            { "Sunday", GetWeekendTimeIntervals}
        };

        private static IEnumerable<TimeInterval> GetWeekDayTimeIntervals => new List<TimeInterval>
        {
            new TimeInterval
            {
                From = DateTime.MinValue.AddHours(8).AddMinutes(30),
                To = DateTime.MinValue.AddHours(18)
            }
        };

        private static IEnumerable<TimeInterval> GetWeekendTimeIntervals => new List<TimeInterval>
        {
            new TimeInterval
            {
                From = DateTime.MinValue.AddHours(00).AddMinutes(00),
                To = DateTime.MinValue.AddHours(5)
            },
            new TimeInterval
            {
                From = DateTime.MinValue.AddHours(18),
                To = DateTime.MinValue.AddHours(24)
            }
        };
    }
}
