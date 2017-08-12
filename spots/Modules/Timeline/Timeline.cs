using System.Collections.Generic;
using spots.DAL.Queries.AtomicWork.Modules.Timeline;
using spots.Modules.Timeline.Interfaces;

namespace spots.Modules.Timeline
{
    public class Timeline : ITimeline
    {
        private readonly IAtomicTimelineWork _atomicWork;
        private const int DefaultAmountOfPosts = 10;

        public Timeline(IAtomicTimelineWork atomicWork)
        {
            _atomicWork = atomicWork;
        }

        public IEnumerable<ITimelineEvent> GetTimeLineEvents(int skip)
        {
            //return _atomicWork.GetEvents(skip, DefaultAmountOfPosts);
            return _atomicWork.GetFutureEvents(skip, DefaultAmountOfPosts);
        }

        public IEnumerable<ITimelineEvent> GetPastTimeLineEvents(int skip)
        {
            return _atomicWork.GetPastEvents(skip, DefaultAmountOfPosts);
        }

        public IEnumerable<ITimelineEvent> GetUserTimelineEvents(int skip, string id)
        {
            return _atomicWork.GetFutureUserEvents(skip, DefaultAmountOfPosts, id);
        }

        public IEnumerable<ITimelineEvent> GetPastUserTimelineEvents(int skip, string id)
        {
            return _atomicWork.GetPastUserEvents(skip, DefaultAmountOfPosts, id);
        }
    }
}
 