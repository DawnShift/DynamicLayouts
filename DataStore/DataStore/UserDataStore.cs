using DataStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStore.DataStore
{
    public class UserDataStore
    {

        public static List<User> User => CreateUserList();

        private static List<User> CreateUserList()
        => new List<User> { new Models.User {
             FirstName="Rahul",
              Email="rahuls1.rakvsgnr@gmail.com",
               Password ="abc",
                Id=1,
                 LastName ="S R"
           } 
        };

    }
}
