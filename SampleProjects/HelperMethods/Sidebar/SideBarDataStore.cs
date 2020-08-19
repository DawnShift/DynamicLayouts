using System;
using System.Collections.Generic;

namespace SampleProjects.HelperMethods.Sidebar
{
    public sealed class SideBarDataStore
    {
        private SideBarDataStore()
        {  
            Menu = new List<SidebarModel>
            {
                new SidebarModel {
                    Links = new List<NavLinks> { new NavLinks { Action = "Index", Controller = "Home", LinkText = "Home" } },
                    IsMultiLevel = false,
                    MenuName = string.Empty,
                    Order = 1
                },
                new SidebarModel {
                    Links = new List<NavLinks> { new NavLinks { Action = "About", Controller = "Home", LinkText = "About" } },
                    IsMultiLevel = false,
                    MenuName = string.Empty,
                    Order = 2
                },
                new SidebarModel {
                    Links = new List<NavLinks> { new NavLinks { Action = "Contact", Controller = "Home", LinkText = "Contact" } },
                    IsMultiLevel = false,
                    MenuName = string.Empty,
                    Order = 4
                },
                new SidebarModel {
                    Links = new List<NavLinks> { new NavLinks { Order=2, Action = "VmSnoozlist", Controller = "Application", LinkText = "Vm Snooze" },
                                                 new NavLinks {Order=1, Action = "GetVmResourcegroupList", Controller = "Application", LinkText = "Resource Groups", Parameters="?vmId=1" } },
                    IsMultiLevel = true,
                    MenuName = "Application",
                    Order = 3
                }
            };
        }

        private static readonly Lazy<SideBarDataStore> lazy = new Lazy<SideBarDataStore>(() => new SideBarDataStore());
        public List<SidebarModel> Menu { get; }
        public static SideBarDataStore SideBar
        {
            get => lazy.Value;
        }

    }

}