using System.Collections.Generic;
using spots.Modules.Timeline.ViewModels;

namespace spots.Modules.Timeline.Interfaces
{
    public interface ITimeline
    {
        IEnumerable<ITimelineEvent> GetTimeLineEvents(int skip);
        IEnumerable<ITimelineEvent> GetPastTimeLineEvents(int skip);

        IEnumerable<ITimelineEvent> GetUserTimelineEvents(int skip, string id);
        IEnumerable<ITimelineEvent> GetPastUserTimelineEvents(int skip, string id);
    }
}
