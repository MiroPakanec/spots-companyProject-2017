using spots.App_Start.Bundles;

namespace spots.Bundles
{
    public static class BundleFactory
    {
        public static TimelineBundle Timeline => new TimelineBundle();
        public static CalendarBundle Calendar => new CalendarBundle();
        public static MapBundle Map => new MapBundle();
        public static BusinessBundle Business => new BusinessBundle();
        public static GroupBundle Group => new GroupBundle();
        public static EventBundle Event => new EventBundle();
        public static FeedbackBundle Feedback => new FeedbackBundle();
        public static UserBundle User => new UserBundle();

    }
}