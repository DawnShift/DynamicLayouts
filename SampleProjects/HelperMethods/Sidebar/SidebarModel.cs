using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleProjects.HelperMethods.Sidebar
{
    public class SidebarModel
    {
        public List<NavLinks> SingleLevelMenu { get; set; }
        public List<MultiLevelMenu> MultiLevelMenu { get; set; }
    }

    public class NavLinks
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public string LinkText { get; set; }
    }

    public class MultiLevelMenu
    {
        public List<NavLinks> Links { get; set; }
        public string MenuName { get; set; }
    } 
}