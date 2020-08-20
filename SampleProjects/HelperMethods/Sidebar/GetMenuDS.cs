using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProjects.HelperMethods.Sidebar
{
    public class GetMenuDS
    {
        public static async Task<List<SidebarModel>> GetDatabaseMenus()
        {
            var sidebarList = new List<SidebarModel> {  new SidebarModel {
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
                }};

            var dynamicList = await GetWikiFromDb(sidebarList.Count);
            if (dynamicList != null)
                sidebarList.Add(dynamicList);
            return sidebarList;
        }

        private static async Task<SidebarModel> GetWikiFromDb(int count)
        {
            string tableName = ConfigurationManager.AppSettings["WikiCloudApplication"];
            StorageTableManager TableManagerObj = new StorageTableManager(tableName);
            WikiApplicationModel WikiModelObj = new WikiApplicationModel();
            // Retrieve the ResourceGroup object where RowKey eq value of id
            List<WikiApplicationModel> WikiappListObj = await TableManagerObj.RetrieveEntity<WikiApplicationModel>(null);
            if (WikiappListObj.Count != 0)
            {
                return new SidebarModel
                {
                    IsMultiLevel = true,
                    MenuName = "Application",
                    Order = count,
                    IsAdminPanel = false,
                    Links = WikiappListObj.Select(x => new NavLinks { Order = 1, Action = "WikiViewPageData", Controller = "Wiki", LinkText = "<i class=\"fa fa-user-plus\"></i>" + x.MenuName }).ToList()
                };
            }
            return null;
        }
    }
}