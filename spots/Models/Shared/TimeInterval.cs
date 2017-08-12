using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace spots.Models.Shared
{
    public class TimeInterval
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public bool IsValid => From < To;
    }
}   