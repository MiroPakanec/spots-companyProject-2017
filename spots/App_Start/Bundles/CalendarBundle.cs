using System.Web.Optimization;

namespace spots.Bundles
{
    public class CalendarBundle
    {
        public ScriptBundle Script(string name)
        {
            return (ScriptBundle)new ScriptBundle(BundlePathConfig.ScriptPath + name).Include(
                "~/Scripts/Calendar/Communication/requests.js",
                "~/Scripts/Calendar/Communication/responses.js",
                "~/Scripts/Calendar/load.js",
                "~/Scripts/Calendar/functions.js");
        }

        public StyleBundle Style(string name)
        {
            return (StyleBundle) new StyleBundle(BundlePathConfig.StylePath + name).Include(
                "~/Content/Calendar/layout.css");
        }
    }
}