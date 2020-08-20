using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleProjects.HelperMethods.Sidebar
{
    public sealed class SideBarDataStore
    {
        private SideBarDataStore()
        {
            Menu = GetMenu().GetAwaiter().GetResult();
        }

        private Task<List<SidebarModel>> GetMenu() => GetMenuDS.GetDatabaseMenus();

        private static readonly Lazy<SideBarDataStore> lazy = new Lazy<SideBarDataStore>(() => new SideBarDataStore());
        public List<SidebarModel> Menu { get; }
        public static SideBarDataStore SideBar
        {
            get => lazy.Value;
        }

    }
}