using System.Collections.Generic;
using spots.Modules.Timeline.Interfaces;

namespace spots.DAL.Queries.AtomicWork.Modules.Timeline
{
    public interface IAtomicTimelineWork : IAtomicWork
    {
        IEnumerable<ITimelineEvent> GetEvents(int skip, int take);
        IEnumerable<ITimelineEvent> GetPastEvents(int skip, int take);
        IEnumerable<ITimelineEvent> GetFutureEvents(int skip, int take);

        IEnumerable<ITimelineEvent> GetFutureUserEvents(int skip, int take, string id);
        IEnumerable<ITimelineEvent> GetPastUserEvents(int skip, int take, string id);
    }
}
