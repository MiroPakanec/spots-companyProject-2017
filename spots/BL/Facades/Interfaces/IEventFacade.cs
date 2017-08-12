using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using spots.Models.Event.ViewModels;
using spots.Models.Spot.ViewModels;
using spots.Models.User.ViewModels;

namespace spots.BL.Facades.Interfaces
{
    public interface IEventFacade
    {
        IEnumerable<UserCreateEventViewModel> GetAllUserCreateEventViewModels();
        IEnumerable<CommonFreeTimesViewModel> GetBestCommonFreeTimesViewModels(CreateEventTimeSlotsViewModel commonFreeTimesViewModel);
        IEnumerable<string> GetPublicEventAddresses(string city, DateTime startDateTime, DateTime endDateTime);
    }
}
