using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using spots.BL.Core.Helpers;
using spots.BL.Core.Interfaces;
using spots.DAL.Queries.AtomicWork.Event;
using spots.DAL.Queries.Repositories.SpotUser;
using spots.Models.Event.ViewModels;
using spots.Models.User;
using spots.Services.DateService;

namespace spots.BL.Core
{
    public class EventCore : IEventCore
    {
        private readonly ISpotUserRepository _spotUserRepository;
        private readonly IAtomicEventWork _atomicEventWork;

        public EventCore(ISpotUserRepository spotUserRepository, IAtomicEventWork atomicEventWork)
        {
            _atomicEventWork = atomicEventWork;
            _spotUserRepository = spotUserRepository;
        }

        public IEnumerable<CommonFreeTimesViewModel> GetCommonFreeTimes(
            CreateEventTimeSlotsViewModel commonFreeTimesViewModel)
        {

            var ids = commonFreeTimesViewModel.UserIds;
            var date = commonFreeTimesViewModel.Date;
            var commonFreeTimes = new List<TimeSlot>();

            var timeSlot = new TimeSlot();
            var availableTime = new TimeSlot();
            var iteration = 0;

            foreach (var id in ids)
            {
                var tempCommonFreeTimes = new List<TimeSlot>();

                //todo: user event end time
                availableTime.StartTime = ChangeTime(date, 0, 0, 0);
                availableTime.EndTime = ChangeTime(date, 23, 59, 59);

                var even = UserEventsWtihIdDate(id, date).ToList();
                var events = even.OrderBy(o => o.StartDateTime.ToLocalTime());

                var isItEndOfAvailableTime = false;
                foreach (var userEvent in events)
                {

                    if (userEvent.StartDateTime.ToLocalTime() == availableTime.StartTime)
                    {
                    }
                    else
                    {
                        timeSlot.StartTime = availableTime.StartTime;
                        timeSlot.EndTime = userEvent.StartDateTime.ToLocalTime();
                        
                        //add timeslot in a list
                        if (iteration > 0)
                        {
                            tempCommonFreeTimes = FindBestTime(commonFreeTimes, timeSlot, tempCommonFreeTimes);
                        }
                        else
                        {
                            commonFreeTimes.Add(new TimeSlot() { StartTime = timeSlot.StartTime, EndTime = timeSlot.EndTime });

                        }
                    }

                    var @event = _atomicEventWork.GetEventDetails(userEvent.EventId);
                    var tempTime = Convert.ToDateTime(@event.EndDatetime);

                    availableTime.StartTime = tempTime;

                    if (tempTime == availableTime.EndTime)
                    {
                        isItEndOfAvailableTime = true;
                    }                   
                }
                if (isItEndOfAvailableTime == false)
                {
                    timeSlot.StartTime = availableTime.StartTime;
                    timeSlot.EndTime = availableTime.EndTime;

                    if (iteration > 0)
                    {
                        tempCommonFreeTimes = FindBestTime(commonFreeTimes, timeSlot, tempCommonFreeTimes);
                    }
                    else
                    {
                        commonFreeTimes.Add(new TimeSlot() {StartTime = timeSlot.StartTime,EndTime = timeSlot.EndTime});

                    }
                }
                if (iteration > 0)
                {
                    commonFreeTimes = tempCommonFreeTimes;
                }

                iteration = 1;
               
            }

            return ToBestCommonFreeTimesViewModel(commonFreeTimes);
        }

        private List<TimeSlot> FindBestTime(IEnumerable<TimeSlot> commonFreeTimes, TimeSlot timeSlot,
            List<TimeSlot> tempCommonFreeTimes)
        {
            foreach (var commonFreeTime in commonFreeTimes)
            {
                var tempTimeSlot = new TimeSlot();

                if (commonFreeTime.StartTime <= timeSlot.EndTime && timeSlot.StartTime <= commonFreeTime.EndTime)
                {
                    if (commonFreeTime.StartTime == timeSlot.StartTime && commonFreeTime.EndTime == timeSlot.EndTime)
                    {
                        tempTimeSlot.StartTime = commonFreeTime.StartTime;
                        tempTimeSlot.EndTime = commonFreeTime.EndTime;
                        tempCommonFreeTimes.Add(tempTimeSlot);
                    }
                    else
                    {                        
                        // check if there is overlap
                        if (commonFreeTime.StartTime < timeSlot.StartTime)
                        {
                            tempTimeSlot.StartTime = timeSlot.StartTime;
                        }
                        else
                        {
                            tempTimeSlot.StartTime = commonFreeTime.StartTime;
                        }


                        //check
                        if (commonFreeTime.EndTime > timeSlot.EndTime)
                        {
                            tempTimeSlot.EndTime = timeSlot.EndTime;
                        }
                        else
                        {
                            tempTimeSlot.EndTime = commonFreeTime.EndTime;
                        }
                        tempCommonFreeTimes.Add(tempTimeSlot);
                    }
                }
            }
            return tempCommonFreeTimes;

        }

        private IEnumerable<CommonFreeTimesViewModel> ToBestCommonFreeTimesViewModel(
            IEnumerable<TimeSlot> commonFreeTimes)
        {
            var collection = new List<CommonFreeTimesViewModel>();

            foreach (var commonFreeTime in commonFreeTimes)
            {
                var model = new CommonFreeTimesViewModel
                {
                    StartDate = commonFreeTime.StartTime.ToString(DateService.GetBasicDateTimeFormat),
                    EndDate = commonFreeTime.EndTime.ToString(DateService.GetBasicDateTimeFormat)
                };
                collection.Add(model);
            }
            return collection;
        }

        //Todo: To be added "EndTime" field in Users/MyEvents
        private IEnumerable<UserEvent> UserEventsWtihIdDate(string id, DateTime date)
        {
            var spotUser = _spotUserRepository.GetWithId(id);
            var events = new List<UserEvent>();

            foreach (var userEvent in spotUser.MyEvents)
            {
                if (userEvent.StartDateTime.ToLocalTime().Date == date.Date)
                {
                    events.Add(userEvent);
                }
            }

            return events;
        }

        private static DateTime ChangeTime(DateTime dateTime, int hours, int minutes, int seconds)
        {
            return new DateTime(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                hours,
                minutes,
                seconds
            );
        }
    }
}