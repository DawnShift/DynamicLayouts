using DataStore.Models;
using System.Collections.Generic;

namespace DataStore.DataStore
{
    public   class RoleDataStore
    {
        public static List<Roles> Roles => CreateRoleList();

        private static List<Roles> CreateRoleList()
        {
            return new List<Roles> {
             new Roles{ Id =1, Name="Admin" },
              new Roles{  Id=2,Name="User"}
            };
        }
    }
}
