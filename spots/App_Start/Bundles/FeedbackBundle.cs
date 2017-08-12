using spots.Bundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace spots.App_Start.Bundles
{
    public class FeedbackBundle
    {
        public ScriptBundle CreateScript(string name)
        {
            return (ScriptBundle)new ScriptBundle(BundlePathConfig.ScriptPath + name).Include(
                "~/Scripts/Feedback/requests.js");
        }
    }
}