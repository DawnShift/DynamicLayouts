using DataStore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStore.DataStore
{
    public class SidebarMenuDbStore
    {
        public static List<SidebarMenus> SidebarMenu => CreateSidebarMenu();

        private static List<SidebarMenus> CreateSidebarMenu()
        {
            return new List<SidebarMenus> {
               new SidebarMenus{ Id=1, Action="Viewer1",Controller=" Application", MenuName="Application 1", ApplicationId=1, LinkName="View 1" , Permisssions=new []{"Reader","Editor","Admin" } },
               new SidebarMenus{ Id=2, Action="Editor1",Controller=" Application", MenuName="Application 1",ApplicationId=1, LinkName="Add/Edit 1" , Permisssions=new []{"Editor","Admin" } },
               new SidebarMenus{ Id=3, Action="Admin1",Controller=" Application", MenuName="Application 1",ApplicationId=1, LinkName="Admin Panel 1" , Permisssions=new []{"Admin" } },
               new SidebarMenus{ Id=4, Action="Viewer2",Controller=" Application", MenuName="Application 2",ApplicationId=2, LinkName="View 2" , Permisssions=new []{"Reader","Editor","Admin" } },
               new SidebarMenus{ Id=5, Action="Editor2",Controller=" Application", MenuName="Application 2",ApplicationId=2, LinkName="Add/Edit 2" , Permisssions=new []{"Editor","Admin" } },
               new SidebarMenus{ Id=6, Action="Admin2",Controller=" Application", MenuName="Application 2",ApplicationId=2, LinkName="Admin panel 2" , Permisssions=new []{"Admin" } },
               new SidebarMenus{ Id=7, Action="Viewer3",Controller=" Application", MenuName="Application 3",ApplicationId=3, LinkName="View 3" , Permisssions=new []{"Reader","Editor","Admin" } },
               new SidebarMenus{ Id=8, Action="Editor3",Controller=" Application", MenuName="Application 3",ApplicationId=3, LinkName="Add/Edit 3" , Permisssions=new []{"Editor","Admin" } },
               new SidebarMenus{ Id=9, Action="Admin3",Controller=" Application", MenuName="Application 3",ApplicationId=3, LinkName="Admin panel 3" , Permisssions=new []{"Admin" } }
               };
        }


        public static Task<List<SidebarMenus>> GetSidebarForUser(int userId)
        {
            var userPermissions = ApplicationToPermissionDbStore.UserPermissions.Where(x => x.UserId == userId).ToList();
            return Task.FromResult((from item in SidebarMenu
                                    join per in userPermissions on item.ApplicationId equals per.ApplicationId
                                    where item.Permisssions.Contains(per.Permission)
                                    select item).Distinct().ToList() ?? new List<SidebarMenus>());
        }
    }
}
