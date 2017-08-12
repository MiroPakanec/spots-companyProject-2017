using System;
using System.Web.Optimization;

namespace spots.Bundles
{
    public class TimelineBundle
    {
        public ScriptBundle Script(string name)
        {
            return (ScriptBundle) new ScriptBundle(BundlePathConfig.ScriptPath + name).Include(
                "~/Scripts/Timeline/load.js",
                "~/Scripts/Timeline/autoEventLoad.js",
                "~/Scripts/Timeline/Communication/requests.js",
                "~/Scripts/Timeline/Communication/responses.js");
        }
    }
}