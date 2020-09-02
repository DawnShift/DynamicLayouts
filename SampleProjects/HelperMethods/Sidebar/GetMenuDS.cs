using DataStore.DataStore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProjects.HelperMethods.Sidebar
{
    public class GetMenuDS
    {
        public static async Task<List<SidebarModel>> GetDatabaseMenus(int userId = 1)
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

            //var dynamicList = await GetWikiFromDb(sidebarList.Count, userId);
            //if (dynamicList != null)
            //    sidebarList.Add(dynamicList);
            var newDynamicList = await GetSidebarListFromDB(sidebarList.Count, userId);
            sidebarList.AddRange(newDynamicList);
            return sidebarList;
        }

        private static async Task<SidebarModel> GetWikiFromDb(int count, int userId)
        { 
            //string tableName = ConfigurationManager.AppSettings["WikiCloudApplication"];
            //StorageTableManager TableManagerObj = new StorageTableManager(tableName);
            //WikiApplicationModel WikiModelObj = new WikiApplicationModel();
            //// Retrieve the ResourceGroup object where RowKey eq value of id
            //List<WikiApplicationModel> WikiappListObj = await TableManagerObj.RetrieveEntity<WikiApplicationModel>(null);
            //if (WikiappListObj.Count != 0)
            //{
            //    return new SidebarModel
            //    {
            //        IsMultiLevel = true,
            //        MenuName = "Application",
            //        Order = count,
            //        IsAdminPanel = false,
            //        Links = WikiappListObj.Select(x => new NavLinks { Order = 1, Action = "WikiViewPageData", Controller = "Wiki", LinkText = "<i class=\"fa fa-user-plus\"></i>" + x.MenuName }).ToList()
            //    };
            //}
            return null;
        }


        private static async Task<List<SidebarModel>> GetSidebarListFromDB(int count, int userId)
        {

            var data = await SidebarMenuDbStore.GetSidebarForUser(userId);
            return (from item in data
                            group item by item.ApplicationId into menuGroup
                            select new SidebarModel
                            {
                                IsMultiLevel = menuGroup.Count() > 1,
                                MenuName = menuGroup.Count() > 1 ? menuGroup.First().MenuName : string.Empty,
                                Order = data.FindIndex(x => x.Id == menuGroup.First().Id) + 1 + count,
                                Links = menuGroup.Select(x => new NavLinks { Action = x.Action, Controller = x.Controller, LinkText = x.LinkName }).ToList()
                            }
                            ).ToList(); 
        }
    }
}