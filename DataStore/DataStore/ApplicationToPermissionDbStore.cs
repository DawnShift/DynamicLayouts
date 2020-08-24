using DataStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStore.DataStore
{
    public class ApplicationToPermissionDbStore
    {

        public static List<ApplicationToPermission> UserPermissions => CreateUserPermissions();

        private static List<ApplicationToPermission> CreateUserPermissions()
        {
            return new List<ApplicationToPermission> {
                        new ApplicationToPermission { Id =1, ApplicationId=1, Permission="Admin", UserId=1},
                        new ApplicationToPermission { Id =2, ApplicationId=2, Permission="Admin", UserId=1},
                        new ApplicationToPermission { Id =3, ApplicationId=3, Permission="Admin", UserId=1},
                        new ApplicationToPermission { Id =4, ApplicationId=1, Permission="Reader", UserId=2},
                        new ApplicationToPermission { Id =5, ApplicationId=1, Permission="Editor", UserId=3},
                        new ApplicationToPermission { Id =6, ApplicationId=1, Permission="Admin", UserId=4},
                        new ApplicationToPermission { Id =7, ApplicationId=2, Permission="Reader", UserId=5},
                        new ApplicationToPermission { Id =8, ApplicationId=2, Permission="Editor", UserId=6},
                        new ApplicationToPermission { Id =9, ApplicationId=2, Permission="Admin", UserId=7},
                        new ApplicationToPermission { Id =10, ApplicationId=3, Permission="Reader", UserId=8 },
                        new ApplicationToPermission { Id =11, ApplicationId=3, Permission="Editor", UserId=9},
                        new ApplicationToPermission { Id =12, ApplicationId=3, Permission="Admin", UserId=10},
                        };
        }
    }
};  