using System.Collections.Generic;

namespace SampleProjects.HelperMethods.Sidebar
{
    public class SidebarModel
    {
        public int Order { get; set; }
        public bool IsMultiLevel { get; set; }
        public List<NavLinks> Links { get; set; }
        public string MenuName { get; set; }
        public bool IsAdminPanel { get; set; }
    }

    public class NavLinks
    {
        public int Order { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string LinkText { get; set; }
        public string Parameters { get; set; }


        //public void Test()
        //{
        //    var d = new List<SidebarModel> {
        //     new SidebarModel
        //     {
        //      Order =1,
        //       IsMultiLevel =false,
        //        MenuName = string.Empty,
        //         Links= new List<NavLinks>{ new NavLinks { Order=1, Action= "Index",Controller= "Home", LinkText= "<i class=\"fa fa-home\"></i> <span>Home</span>"} }
        //     },

        //       new SidebarModel
        //     {
        //      Order =2,
        //       IsMultiLevel =false,
        //        MenuName = string.Empty,
        //         Links= new List<NavLinks>{ new NavLinks { Order=1, Action= "viewapplicationlist", Controller= "budget", LinkText= " <i class=\"fa fa - book\"></i> <span>Application Registration</span>" } }
        //     },

        //       new SidebarModel
        //     {
        //      Order =3,
        //       IsMultiLevel =true,
        //        MenuName = "<i class=\"glyphicon glyphicon-time\"></i> <span>VM Snoozing</span> <i class=\"fa fa-angle-right pull-right\"></i>",
        //         Links= new List<NavLinks>{ new NavLinks { Order=1, Action= "GetVMResourceGroupList", Controller= "Application", LinkText= "<i class=\"fa fa - list\"></i> Resource Group List" },
        //                                    new NavLinks { Order=2, Action= "getvmsnoozelist", Controller= "Application", LinkText= "<i class=\"fa fa-list\"></i> Resource Group List(T)" },
        //                                    new NavLinks { Order=3, Action= "GetVMResourceGroupSummaryList", Controller= "Application", LinkText= "<i class=\"fa fa-calendar-check-o\"></i> Snoozing Summary List" },
        //                                    new NavLinks { Order=4, Action= "GetVMResourceList", Controller= "Application", LinkText= "<i class=\"fa fa-minus-circle\"></i> VM Exclusion List" },
        //                                    new NavLinks { Order=5, Action= "VmSnoozList", Controller= "Application", LinkText= "<i class=\"fa fa-search\"></i>VM Snoozing Logs" }
        //         }
        //     },

        //        new SidebarModel
        //     {
        //      Order =4,
        //       IsMultiLevel =true,
        //        MenuName = " <i class=\"fa fa-desktop\"></i> <span>Expired Resources</span> <i class=\"fa fa-angle-right pull-right\"></i>",
        //         Links= new List<NavLinks>{ new NavLinks { Order=1, Action= "GetIdleResourceGroupList", Controller= "Application", LinkText= "<i class=\"fa fa - list\"></i> Resource Group List" },
        //                                    new NavLinks { Order=2, Action= "GetIdleResourceList", Controller= "Application", LinkText= "<i class=\"fa fa-minus-circle\"></i> Resource Exclusion List" },
        //                                    new NavLinks { Order=3, Action= "IdleResourceList", Controller= "Application", LinkText= "<i class=\"fa fa-dollar\"></i> Expired Resource Cost" },
        //                                    new NavLinks { Order=4, Action= "ExpiryResourceAgeData", Controller= "Application", LinkText= "<i class=\"fa fa-life-ring\"></i> Expiry Resource Age" },
        //                                    new NavLinks { Order=5, Action= "GetIdleExpiryList", Controller= "Application", LinkText= "<i class=\"fa fa-bell\"></i> Expiry Notification List" }
        //         }
        //     },
        //          new SidebarModel
        //     {
        //      Order =5,
        //       IsMultiLevel =true,
        //        MenuName = " <i class=\"fa fa-th\"></i> <span>Orphan Resource</span> <i class=\"fa fa-angle-right pull-right\"></i>",
        //         Links= new List<NavLinks>{ new NavLinks { Order=1, Action= "GetCurrentOrphanResourceList", Controller= "Orphan", LinkText= "<i class=\"fa fa - list\"></i> Orphan Resource List" } }
        //     },

        //     new SidebarModel
        //     {
        //      Order =6,
        //       IsMultiLevel =false,
        //        MenuName = string.Empty,
        //         Links= new List<NavLinks>{ new NavLinks { Order=1, Action= "Index", Controller= "VMStatus", LinkText= "<i class=\"fa fa - tasks\"></i> <span>VM Status</span>" } }
        //     },

        //        new SidebarModel
        //     {
        //      Order =7,
        //       IsMultiLevel =false,
        //        MenuName = string.Empty,
        //         Links= new List<NavLinks>{ new NavLinks { Order=1, Action= "Index", Controller= "VMUtilization", LinkText= "<i class=\"fa fa - line - chart\"></i> <span>VM Utilization</span>" } }
        //     },
        //        new SidebarModel
        //     {
        //      Order =8,
        //       IsMultiLevel =true,
        //        MenuName = "<i class=\"fa fa-briefcase\"></i> <span>Project Budget</span> <i class=\"fa fa-angle-right pull-right\"></i>",
        //         Links= new List<NavLinks>{ new NavLinks { Order=1, Action= "ViewApplicationBudgetList", Controller= "Budget", LinkText= "<i class=\"fa fa - list\"></i> Application Budget" } }
        //     },

        //     new SidebarModel  {
        //      Order =9,
        //       IsMultiLevel =true,
        //        IsAdminPanel=true,
        //        MenuName = " <i class=\"fa fa-graduation-cap\"></i> <span>Admin Page</span> <i class=\"fa fa-angle-right pull-right\"></i>",
        //         Links= new List<NavLinks>{ new NavLinks { Order=1, Action= "CloudUserList", Controller= "Admin", LinkText= "<i class=\"fa fa - user - plus\"></i> Users List" },
        //         new NavLinks { Order=1, Action= "VMUserListManageData", Controller= "Admin", LinkText= "<i class=\"fa fa-users\"></i> VM User List Manage" }
        //         }
        //     }

        //};
        //}

    }
}