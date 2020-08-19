using System.Collections.Generic;

namespace SampleProjects.HelperMethods.Sidebar
{
    public class SidebarModel
    {
        public int Order { get; set; }
        public bool IsMultiLevel { get; set; }
        public List<NavLinks> Links { get; set; }
        public string MenuName { get; set; }
    }

    public class NavLinks
    {
        public int Order { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string LinkText { get; set; }
        public string Parameters { get; set; }
    } 
}