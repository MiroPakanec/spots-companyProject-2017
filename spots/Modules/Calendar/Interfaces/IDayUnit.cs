using System.Collections.Generic;
using spots.Models.Event.Interfaces;
using spots.Modules.Calendar.ViewModels;

namespace spots.Modules.Calendar.Interfaces
{
    public interface IDayUnit
    {
        string Day { get; set; }
        IEnumerable<CalendarEventViewModel> Events { get; set; }
    }
}
