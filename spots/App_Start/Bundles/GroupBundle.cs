using System.Web.Optimization;

namespace spots.Bundles
{
    public class GroupBundle
    {
        public ScriptBundle Script(string name)
        {
            return (ScriptBundle) new ScriptBundle(BundlePathConfig.ScriptPath + name).Include(
                "~/Scripts/Group/communication.js",
                "~/Scripts/Group/events.js",
                "~/Scripts/Group/functions.js");
        }

        public ScriptBundle AddMemberScript(string name)
        {
            return (ScriptBundle)new ScriptBundle(BundlePathConfig.ScriptPath + name).Include(
                "~/Scripts/Group/communication.js",
                "~/Scripts/Group/AddMember/events.js",
                "~/Scripts/Group/AddMember/functions.js");
        }

        public StyleBundle Style(string name)
        {
            return (StyleBundle)new StyleBundle(BundlePathConfig.StylePath + name).Include(
                "~/Content/Group/layout.css");
        }
    }
}