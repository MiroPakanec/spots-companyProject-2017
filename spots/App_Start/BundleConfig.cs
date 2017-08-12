using System.Web.Optimization;
using spots.Bundles;

namespace spots
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-{version}.js",
                        "~/Scripts/jquery-migrate-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new StyleBundle("~/bundles/cssval").Include(
                        "~/Content/validation.css"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/bootstrap-extentions.css",
                        "~/Content/bootstrap-datetimepicker.css",
                        "~/Content/site.css",
                        "~/Content/navbar.css",
                        "~/Content/designTools.css",
                        "~/Content/layoutTools.css"));

            bundles.Add((new ScriptBundle("~/bundles/layoutScripts")).Include(
                        "~/Scripts/SharedLoad/featuresLoad.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                        "~/Scripts/knockout-{version}.js",
                        "~/Scripts/knockout.mapping-latest.js"));

            bundles.Add(new ScriptBundle("~/bundles/datetimepicker-js").Include(
                        "~/Scripts/moment.js",
                        "~/Scripts/Tools/Config/datetime.js",
                        "~/Scripts/bootstrap-datetimepicker.js"));

            bundles.Add(new ScriptBundle("~/bundles/tools").Include(
                        "~/Scripts/Tools/Config/config.js",
                        "~/Scripts/Tools/Communication/ajax.js",
                        "~/Scripts/Tools/Communication/formTools.js",
                        "~/Scripts/Tools/Tracking/events.js",
                        "~/Scripts/Tools/Helpers/knockoutHelper.js",
                        "~/Scripts/Tools/Helpers/dateHelper.js"));

            bundles.Add(new ScriptBundle("~/bundles/logout").Include(
                        "~/Scripts/Logout/logout.js"));

            bundles.Add(new ScriptBundle("~/bundles/Account").Include(
                "~/Scripts/Account/toggleAnim.js",
                "~/Scripts/Account/events.js",
                "~/Scripts/Account/viewmodels.js"));

            bundles.Add(new ScriptBundle("~/bundles/ProfileDetails").Include(
                "~/Scripts/ProfileDetails/communication.js"));

            bundles.Add(new ScriptBundle("~/bundles/ProfilePersonalDetails").Include(
                "~/Scripts/ProfileDetails/Personal/events.js",
                "~/Scripts/ProfileDetails/Personal/communication.js"));

            bundles.Add(new ScriptBundle("~/bundles/ProfileContactDetails").Include(
                "~/Scripts/ProfileDetails/Contact/events.js",
                "~/Scripts/ProfileDetails/Contact/communication.js"));

            bundles.Add(new ScriptBundle("~/bundles/DeleteProfile").Include(
                "~/Scripts/User/DeleteProfile/functions.js"));

            bundles.Add(new ScriptBundle("~/bundles/Business").Include(
                "~/Scripts/Business/searchBoxEvents.js",
                "~/Scripts/Business/createBusinessEvents.js"));

            bundles.Add(new ScriptBundle("~/bundles/CreateLocation").Include(
                "~/Scripts/Location/createLocationEvents.js"));

            bundles.Add(new ScriptBundle("~/bundles/CreateSpot").Include(
                "~/Scripts/Spot/Communication/requests.js",
                "~/Scripts/Spot/events.js",
                "~/Scripts/Spot/createSpotEvents.js",
                "~/Scripts/Spot/validation.js",
                "~/Scripts/Spot/availableHours.js"));

            bundles.Add(new StyleBundle("~/Content/Spot").Include(
            "~/Content/Spot/layout.css"));

            bundles.Add(new ScriptBundle("~/bundles/AvailableSpotsTools").Include(
                "~/Scripts/Spot/Tools/availableSpotsTools.js"));

            bundles.Add(BundleFactory.Event.CreateScript("EventCreate"));
            bundles.Add(BundleFactory.Event.NewCreateScript("NewEventCreate"));
            bundles.Add(BundleFactory.Event.SearchScript("EventSearch"));
            bundles.Add(BundleFactory.Timeline.Script("Timeline"));
            bundles.Add(BundleFactory.Group.Script("Group")); 
            bundles.Add(BundleFactory.Group.AddMemberScript("AddMember"));
            bundles.Add(BundleFactory.Group.Style("Group"));
            bundles.Add(BundleFactory.Calendar.Script("Calendar"));
            bundles.Add(BundleFactory.Calendar.Style("Calendar"));
            bundles.Add(BundleFactory.Map.Style("Map"));
            bundles.Add(BundleFactory.Map.Script("Map"));
            bundles.Add(BundleFactory.Business.DetailsScripts("BusinessDetails"));
            bundles.Add(BundleFactory.Business.DetailsStyle("BusinessDetails"));
            bundles.Add(BundleFactory.Feedback.CreateScript("Feedback"));
            bundles.Add(BundleFactory.User.Script("UserScripts"));
        }
    }
}
