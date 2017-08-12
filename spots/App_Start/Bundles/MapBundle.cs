using System.Web.Optimization;

namespace spots.Bundles
{
    public class MapBundle
    {
        public ScriptBundle Script(string name)
        {
            return (ScriptBundle)new ScriptBundle(BundlePathConfig.ScriptPath + name).Include(
                "~/Scripts/Map/mapconfig.js");
        }

        public StyleBundle Style(string name)
        {
            return (StyleBundle)new StyleBundle(BundlePathConfig.StylePath + name).Include(
                "~/Content/Map/layout.css");
        }
    }
}