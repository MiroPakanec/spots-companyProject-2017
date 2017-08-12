using System.Web.Mvc;

namespace spots.Services.ViewServices
{
    public static class RedirectTo
    {
        public static string Url(string link)
        {
            return "window.location = '" + link + "'";
        }

        public static string Action(UrlHelper url, string actionName, string controllerName)
        {
            var returnString = "window.location = '" + url.Action(actionName, controllerName) + "'";
            return returnString;
        }
    }
}