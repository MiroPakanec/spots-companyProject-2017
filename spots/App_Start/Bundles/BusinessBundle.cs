using System.Web.Optimization;

namespace spots.Bundles
{
    public class BusinessBundle
    {
        public ScriptBundle DetailsScripts(string name)
        {
            return (ScriptBundle) new ScriptBundle(BundlePathConfig.ScriptPath + name).Include(
                "~/Scripts/Business/Details/requests.js");
        }

        public StyleBundle DetailsStyle(string name)
        {
            return (StyleBundle)new StyleBundle(BundlePathConfig.StylePath + name).Include(
                "~/Content/Business/layout.css");
        }
    }
}