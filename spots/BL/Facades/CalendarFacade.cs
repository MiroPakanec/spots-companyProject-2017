using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using spots.BL.Facades.Interfaces;
using spots.DAL.Queries.AtomicWork.Event;
using spots.Models.Event.Interfaces;
using spots.Models.Event.ViewModels;
using spots.Modules.Calendar;
using spots.Modules.Calendar.Interfaces;
using spots.Modules.Calendar.ViewModels;
using spots.Services.Calendar;
using spots.Services.DateService;

namespace spots.BL.Facades
{
    public class CalendarFacade : ICalendarFacade
    {
        private readonly IEvent _event;
        private readonly IAtomicEventWork _atomicEventWork;

        public CalendarFacade(IEvent anEvent, IAtomicEventWork atomicEventWork)
        {
            _event = anEvent;
            _atomicEventWork = atomicEventWork;
        }

        public CalendarViewModel GetIndexViewModel()
        {
            var viewModel = new CalendarViewModel
            {
                DisplayDate = CalendarHelper.CurrentMonthYearDate
            };

            return viewModel;
        }

        public EventDetailsViewModel GetEventDetailsViewModel(string id)
        {
            if (id.IsNullOrEmpty())
            {
                throw new Exception("Event ID cannot be null.");
            }

            return _atomicEventWork.GetEventDetails(id) as EventDetailsViewModel;
        }

        public IEnumerable<IDayUnit> GetCalendarResult(string dateString)
        {
            var list = new List<IDayUnit>();
            var dayInMonth = DateTime.Parse(dateString);
            var lastDayInMonth = dayInMonth.AddMonths(1).AddDays(-1);

            //Add Empty days begining
            list.AddRange(EmptyDaysBeforeMonth(dayInMonth));

            //Add days in month
            list.AddRange(CalendarDays(dayInMonth, lastDayInMonth));

            //Add Empty days end
            list.AddRange(EmptyDaysAfterMonth(lastDayInMonth));

            return list;
        }

        public IEnumerable<CalendarFeatureEventViewModel> GetCalendarFeatureEvents(string date)
        {
            var bsonDate = DateService.ToBson(date);
            var events = _event.Repository.GetByDay(bsonDate);

            return events.Select(@event => new CalendarFeatureEventViewModel()
            {
                Title = @event.Title,
                MongoId = @event.MongoId,
                StartTime = DateService.TimeFromBson(@event.StartDateTime),
                EndTime = DateService.TimeFromBson(@event.EndDateTime)
            }).ToList();
        }

        public string GetDate(string month, string year, int increment)
        {
            return CalendarHelper.MonthYearDate(month, year, increment);
        }

        //private methods
        #region
        private IEnumerable<IDayUnit> CalendarDays(DateTime dayInMonth, DateTime lastDayInMonth)
        {
            var list = new List<IDayUnit>();
            var day = 1;

            while (dayInMonth <= lastDayInMonth)
            {
                var events = _event.Repository.GetByDay(dayInMonth);
                var eventViewModels = GetCalendarEvents(events);

                var dayUnit = new DayUnit
                {
                    Events = eventViewModels,
                    Day = day.ToString()
                };

                list.Add(dayUnit);

                day++;
                dayInMonth = dayInMonth.AddDays(1);
            }

            return list;
        }

        private static IEnumerable<CalendarEventViewModel> GetCalendarEvents(IEnumerable<IEvent> events)
        {
            var eventViewModels = new List<CalendarEventViewModel>();

            foreach (var @event in events)
            {
                var viewModel = new CalendarEventViewModel
                {
                    Title = @event.Title,
                    MongoId = @event.MongoId
                };

                viewModel.TimeFromBson(@event.StartDateTime);

                eventViewModels.Add(viewModel);
            }

            return eventViewModels;
        }

        private static IEnumerable<IDayUnit> EmptyDaysAfterMonth(DateTime datetime)
        {
            var list = new List<IDayUnit>();
            var position = datetime.GetDayPosition();

            while (position < 6)
            {
                list.Add(new DayUnit
                {
                    Events = new List<CalendarEventViewModel>()
                });
                position++;
            }

            return list;
        }

        private static IEnumerable<IDayUnit> EmptyDaysBeforeMonth(DateTime datetime)
        {
            var list = new List<IDayUnit>();
            var position = datetime.GetDayPosition();

            while (position != 0)
            {
                list.Add(new DayUnit
                {
                    Events = new List<CalendarEventViewModel>()
                });
                position--;
            }

            return list;
        }
        #endregion 
    }
}