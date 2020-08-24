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
        => new List<User> { new User {
             FirstName="Rahul",
              Email="rahuls1.rakvsgnr@gmail.com",
               Password ="abc",
                Id=1,
                 LastName ="S R"
           },
          new User{  FirstName="Application 1 Reader",
                 Email="app1reader",
                  Password ="abc",
                  Id=2
          },

          new User{  FirstName="Application 1 Editor",
                 Email="app1editor",
                  Password ="abc",
                  Id=3
          },

          new User{  FirstName="Application 1 Admin",
                 Email="app1admin",
                  Password ="abc",
                  Id=4
          },

          new User{  FirstName="Application 2 Reader",
                 Email="app2reader",
                  Password ="abc",
                  Id=5
          },

          new User{  FirstName="Application 2 Editor",
                 Email="app2editor",
                  Password ="abc",
                  Id=6
          },

          new User{  FirstName="Application 2 Admin",
                 Email="app2admin",
                  Password ="abc",
                  Id=7
          },

          new User{  FirstName="Application 3 Reader",
                 Email="app3reader",
                  Password ="abc",
                  Id=8
          },

          new User{  FirstName="Application 3 Editor",
                 Email="app3editor",
                  Password ="abc",
                  Id=9
          },

          new User{  FirstName="Application 3 Admin",
                 Email="app3admin",
                  Password ="abc",
                  Id=10
          },

        };

    }
}
