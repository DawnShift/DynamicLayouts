using System;
using System.Collections.Generic;

namespace SampleProjects.HelperMethods.Sidebar
{
    public sealed class SideBarDataStore
    {
        private SideBarDataStore()
        {
            Menu = new SidebarModel
            {
                SingleLevelMenu = new List<NavLinks>
                {
                    new NavLinks{Action ="Index", Controller="Home",LinkText="Home"},
                    new NavLinks{ Action="About",Controller="Home",LinkText="About"},
                    new NavLinks{ Action="Contact",Controller="Home",LinkText="Contact"},
                },
                MultiLevelMenu = new List<MultiLevelMenu> {
                  new MultiLevelMenu{
                     MenuName ="Application",
                      Links= new List<NavLinks>{
                        new NavLinks{Action ="VmSnoozlist", Controller="Application",LinkText="Vm Snooze"},
                         new NavLinks{ Action="GetVmResourcegroupList",Controller="Application",LinkText="Resource Groups"}
                      }
                  }
                 }
            };

        }
        private static readonly Lazy<SideBarDataStore> lazy = new Lazy<SideBarDataStore>(() => new SideBarDataStore());
        public SidebarModel Menu { get; }
        public static SideBarDataStore SideBar
        {
            get => lazy.Value;
        }

    }

}