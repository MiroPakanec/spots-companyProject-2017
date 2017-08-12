using System.Web.Optimization;

namespace spots.Bundles
{
    public class EventBundle
    {
        public ScriptBundle CreateScript(string name)
        {
            return (ScriptBundle) new ScriptBundle(BundlePathConfig.ScriptPath + name).Include(
                "~/Scripts/Event/Create/functions.js",
                "~/Scripts/User/peopleInviteEvents.js",
                "~/Scripts/Event/Create/availableSpotsEvents.js");
        }

        public ScriptBundle NewCreateScript(string name)
        {
            return (ScriptBundle)new ScriptBundle(BundlePathConfig.ScriptPath + name).Include(
                "~/Scripts/Event/Create/Shared/functions.js",
                "~/Scripts/Event/Create/People/functions.js",
                "~/Scripts/Event/Create/People/load.js",
                "~/Scripts/User/peopleInviteEvents.js",
                "~/Scripts/Event/Create/TimeCity/functions.js",
                "~/Scripts/Event/Create/availableSpotsEvents.js");
        }

        public ScriptBundle SearchScript(string name)
        {
            return (ScriptBundle) new ScriptBundle(BundlePathConfig.ScriptPath + name).Include(
                "~/Scripts/Event/Search/events.js",
                "~/Scripts/Event/Search/functions.js",
                "~/Scripts/Event/Search/autoEventLoad.js");
        }
    }
}