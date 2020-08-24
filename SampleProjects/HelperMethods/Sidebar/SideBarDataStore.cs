using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace SampleProjects.HelperMethods.Sidebar
{
    public sealed class SideBarDataStore
    {
        private const string SESSION_MANAGER = "APP_SESSION_MANAGER";
        private SideBarDataStore()
        {
            UserId = GetUserId();
            Menu = GetMenu().GetAwaiter().GetResult();
            RefreshedOn = DateTime.Now;
        }

        private Task<List<SidebarModel>> GetMenu() => GetMenuDS.GetDatabaseMenus(this.UserId);

        //private static readonly Lazy<SideBarDataStore> lazy = new Lazy<SideBarDataStore>(() => new SideBarDataStore());
        public List<SidebarModel> Menu { get; }
        public DateTime RefreshedOn { get; set; }
        public int UserId { get; }
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
        private int GetUserId()
        {
            var claims = (ClaimsIdentity)HttpContext.Current?.User?.Identity;
            var id = claims.Claims?.Where(x => x.Type.Equals(ClaimTypes.Sid))?.Select(x => x.Value).FirstOrDefault();
            return id == null ? 0 : Convert.ToInt32(id);
        }
    }
}