using AzureTableStorageDataStore.Models;
using AzureTableStorageDataStore.Repository;
using System;

namespace SampleConsoleApp
{
    class Program
    {


        static async System.Threading.Tasks.Task Main(string[] args)
        {

            IRepository<TestTableRahul> list1 = new Repository<TestTableRahul>();
            //Already inserted values
            //_ = list1.Insert(new TestTableRahul { PartitionKey = "Cloud", RowKey = "4", Name = "Ommega", Timestamp = DateTime.Now });
            //_ = list1.InsertMany(new System.Collections.Generic.List<TestTableRahul> { new
            //    TestTableRahul { PartitionKey = "Cloud", RowKey = "5", Name = "efsilon", Timestamp = DateTime.Now },
            //new TestTableRahul{ PartitionKey = "Cloud", RowKey = "6", Name = "Godratio1.61", Timestamp = DateTime.Now }
            //});
            _ = list1.InsertOrUpdate(new TestTableRahul { PartitionKey = "Cloud", RowKey = "6", Name = "GodRatio_1.61", Timestamp = DateTime.Now });
            var singleEntity = list1.GetById<TestTableRahul>("Cloud", "5");
            var wholeListByPartetionKey = list1.RetrieveAllInPartition<TestTableRahul>("Cloud");
            var FliteredKey = list1.GetEntities<TestTableRahul>(x => x.Name == "Alpha");
            _ = list1.Delete(singleEntity);
            IRepository<AzureSubscriptionList> list = new Repository<AzureSubscriptionList>();
            var sa = list.GetById<AzureSubscriptionList>("Cloud", "00ce1913-e108-499d-846c-0627dc8b4071");
            var aa = list.RetrieveAllInPartition<AzureSubscriptionList>("Cloud");
            var da = list.GetEntities<AzureSubscriptionList>(x => x.SubscriptionName == "Sandbox");
            Console.WriteLine("Da");
            Console.ReadLine();
        }
    }
}
