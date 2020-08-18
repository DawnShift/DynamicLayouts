using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Linq;

namespace SampleProjects.HelperMethods
{
    public static class SidebarHelper
    {
        public static string SetativeLink(this HtmlHelper helper, string actionName = "", string controllerName = "", string cssClass = "activeLink")
         => (Action(helper) == actionName.ToLower() && (Controller(helper) == controllerName.ToLower())) ? cssClass : "";


        public static string SetActiveDropDown(this HtmlHelper helper, List<SublinkList> sublinkList)
            => sublinkList.Any(x => x.Action == Action(helper) && x.Controller == Controller(helper)) ? "active" : "";

        public static string ExpandDropDown(this HtmlHelper helper, List<SublinkList> sublinkList)
          => sublinkList.Any(x => x.Action == Action(helper) && x.Controller == Controller(helper)) ? "display:block" : "display:none";

        private static string Controller(this HtmlHelper htmlHelper)
        {
            var routeValues = HttpContext.Current.Request.RequestContext.RouteData.Values;
            return routeValues.ContainsKey("controller") ? routeValues["controller"].ToString().ToLower() : string.Empty;
        }

        private static string Action(this HtmlHelper htmlHelper)
        {
            var routeValues = HttpContext.Current.Request.RequestContext.RouteData.Values;
            return routeValues.ContainsKey("action")? routeValues["action"].ToString().ToLower() : string.Empty;
        }
    } 

    public class SublinkList
    {
        private string action = "";
        private string controller = "";
        public string Action { get { return action.ToLower(); } set { action = value; } }
        public string Controller { get { return controller.ToLower(); } set { controller = value; } }
    }
}
