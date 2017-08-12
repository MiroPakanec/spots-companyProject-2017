using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace spots.Models.Event.ViewModels
{
    public class CreateEventTimeSlotsViewModel
    {
        public DateTime Date { get; set; }
        public IEnumerable<string> UserIds { get; set; }
    }
}