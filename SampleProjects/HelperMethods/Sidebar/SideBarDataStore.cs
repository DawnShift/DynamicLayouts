using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace SampleProjects.HelperMethods.Sidebar
{
    public sealed class SideBarDataStore
    {
        private const string SESSION_MANAGER = "APP_SESSION_MANAGER";
        private SideBarDataStore()
        {
            Menu = GetMenu().GetAwaiter().GetResult();
            RefreshedOn = DateTime.Now;
        }

        private Task<List<SidebarModel>> GetMenu() => GetMenuDS.GetDatabaseMenus();

        //private static readonly Lazy<SideBarDataStore> lazy = new Lazy<SideBarDataStore>(() => new SideBarDataStore());
        public List<SidebarModel> Menu { get; }
        public DateTime RefreshedOn { get; set; }
        public static SideBarDataStore SideBar
        {
            get
            {
                HttpContext context = HttpContext.Current;
                SideBarDataStore manager = context.Session[SESSION_MANAGER] as SideBarDataStore;
                if (manager == null)
                {
                    manager = new SideBarDataStore(); 
                    context.Session[SESSION_MANAGER] = manager;
                }
                return manager;
            } 
        }
        public static void Dispose()
        {
            System.Web.HttpContext.Current.Session.Remove(SESSION_MANAGER);
        }


    }
}