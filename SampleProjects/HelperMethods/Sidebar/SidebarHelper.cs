using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using SampleProjects.HelperMethods.Sidebar;

namespace SampleProjects.HelperMethods
{
    public static class SidebarHelper
    {
        public static string SetativeLink(this HtmlHelper helper, string actionName = "", string controllerName = "", string cssClass = "activeLink")
         => (Action(helper) == actionName.ToLower() && (Controller(helper) == controllerName.ToLower())) ? cssClass : "";

        public static string SetActiveDropDown(this HtmlHelper helper, List<NavLinks> sublinkList, string cssClass = "active")
            => sublinkList.Any(x => x.Action.ToLower() == Action(helper) && x.Controller.ToLower() == Controller(helper)) ? cssClass : "";

        public static string ExpandDropDown(this HtmlHelper helper, List<NavLinks> sublinkList)
          => sublinkList.Any(x => x.Action.ToLower() == Action(helper) && x.Controller.ToLower() == Controller(helper)) ? "display:block" : "display:none";

        private static string Controller(this HtmlHelper htmlHelper)
        {
            var routeValues = HttpContext.Current.Request.RequestContext.RouteData.Values;
            return routeValues.ContainsKey("controller") ? routeValues["controller"].ToString().ToLower() : string.Empty;
        }

        private static string Action(this HtmlHelper htmlHelper)
        {
            var routeValues = HttpContext.Current.Request.RequestContext.RouteData.Values;
            return routeValues.ContainsKey("action") ? routeValues["action"].ToString().ToLower() : string.Empty;
        }
    }

}
