using AzureTableStorageDataStore.Models;
using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AzureTableStorageDataStore.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {

        private const string accountName = "driftstaccnt01";
        private const string token = "5yYb7SfhFv5jGgbMjUM+aiGGt0ppsHCg6RYHcSHU6iZ+j6FNXD/oFBez+Z2fRlNUdR1hs7eUVcCot2wkM8PYiA==";
        private readonly CloudTable tableContext;
        public Repository()
        {
            var storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, token), true);
            var tableClient = storageAccount.CreateCloudTableClient();
            tableContext = tableClient.GetTableReference(typeof(T).Name);
            tableContext.CreateIfNotExists();
        }

        public TableResult Insrt(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity", "entity cannot be null");
            return tableContext.Execute(TableOperation.Insert(entity));
        } 

        public TableBatchResult InsrtMany(List<T>entity)
        { 
            if (entity == null)
                throw new ArgumentNullException("entity", "entity cannot be null");
             var batchOp = new TableBatchOperation() { };
            foreach (T item in entity)
                batchOp.Add(TableOperation.Insert(item));
            return tableContext.ExecuteBatch(batchOp);
        } 
        public TableResult InsrtOrUpdate(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity", "entity cannot be null");
            return tableContext.Execute(TableOperation.InsertOrReplace(entity));
        } 
        public TableBatchResult InsrtManyOrUpdateMany(List<T> entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity", "entity cannot be null");
            var batchOp = new TableBatchOperation() { };
            foreach (T item in entity)
                batchOp.Add(TableOperation.InsertOrReplace(item));
            return tableContext.ExecuteBatch(batchOp);
        }
        public T GetById(string partetionKey, string rowKey)
        {
            var type = typeof(T);
           var result= tableContext.Execute(TableOperation.Retrieve(partetionKey, rowKey));
            return (T)result.Result;  
        }

        public void FilteredGet()
        {
            //_ = tableContext.CreateQuery().
        }
    }
}
