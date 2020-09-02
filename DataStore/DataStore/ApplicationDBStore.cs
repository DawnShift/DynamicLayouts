using DataStore.Models;
using System.Collections.Generic;

namespace DataStore.DataStore
{
    public   class ApplicationDBStore
    {
        public static List<Application> Applications => CreateApplications();

        private static List<Application> CreateApplications()
        {
            return new List<Application> { new Application {  Id=1, IsActive=true, Name="Application 1"},
                                            new Application {  Id=1, IsActive=true, Name="Application 2"},
                                           new Application {  Id=1, IsActive=true, Name="Application 3"},
           };
        }
    }
}
