using System.Collections.Generic;
using spots.Models.Event.ViewModels;
using spots.Modules.Calendar.Interfaces;
using spots.Modules.Calendar.ViewModels;

namespace spots.BL.Facades.Interfaces
{
    public interface ICalendarFacade
    {
        CalendarViewModel GetIndexViewModel();   
        EventDetailsViewModel GetEventDetailsViewModel(string id);

        IEnumerable<IDayUnit> GetCalendarResult(string dateString);
        IEnumerable<CalendarFeatureEventViewModel> GetCalendarFeatureEvents(string date);

        string GetDate(string month, string year, int increment);
    }
}
