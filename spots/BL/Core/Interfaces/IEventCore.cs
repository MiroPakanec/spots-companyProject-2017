using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using spots.Models.Event.ViewModels;

namespace spots.BL.Core.Interfaces
{
    public interface IEventCore
    {
        IEnumerable<CommonFreeTimesViewModel> GetCommonFreeTimes(CreateEventTimeSlotsViewModel commonFreeTimesViewModel);
    }
}
