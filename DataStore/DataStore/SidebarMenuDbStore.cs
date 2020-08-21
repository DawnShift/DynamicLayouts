using DataStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStore.DataStore
{
    public class SidebarMenuDbStore
    {
        public static List<SidebarMenus> SidebarMenu => CreateSidebarMenu();

        private static List<SidebarMenus> CreateSidebarMenu()
        {
            return new List<SidebarMenus> {
               new SidebarMenus{ Id=1, Action="ReaderApp1",Controller=" Application",
               }
             };
        }
    }
}
