using System.Collections.Generic;
using spots.Models.Event.Interfaces;
using spots.Modules.Calendar.Interfaces;
using spots.Modules.Calendar.ViewModels;

namespace spots.Modules.Calendar
{
    public class DayUnit : IDayUnit
    {
        public string Day { get; set; }
        public IEnumerable<CalendarEventViewModel> Events { get; set; }
    }
}