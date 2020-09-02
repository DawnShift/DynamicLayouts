using AzureTableStorageDataStore.Models;
using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AzureTableStorageDataStore.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {

        private const string accountName = "<Account_Name>";
        private const string token = "<Hash_Key>";
        private readonly CloudTable tableContext;
        public Repository()
        {
            var storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, token), true);
            var tableClient = storageAccount.CreateCloudTableClient();
            tableContext = tableClient.GetTableReference(typeof(T).Name);
            tableContext.CreateIfNotExistsAsync();
        }

        public TableResult Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity", "entity cannot be null");
            return tableContext.Execute(TableOperation.Insert(entity));
        }

        public List<TableResult> InsertMany(List<T> entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity", "entity cannot be null");
            var batchOp = new TableBatchOperation() { };
            foreach (T item in entity)
                batchOp.Add(TableOperation.Insert(item));
            return tableContext.ExecuteBatch(batchOp).ToList();
        }
        public TableResult InsertOrUpdate(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity", "entity cannot be null");
            return tableContext.Execute(TableOperation.InsertOrReplace(entity));
        }
        public List<TableResult> InsertManyOrUpdateMany(List<T> entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity", "entity cannot be null");
            var batchOp = new TableBatchOperation() { };
            foreach (T item in entity)
                batchOp.Add(TableOperation.InsertOrReplace(item));
            return tableContext.ExecuteBatch(batchOp).ToList();
        }

        public bool Delete(T entity)
        {
            TableOperation delteOperation = TableOperation.Delete(entity);
            tableContext.Execute(delteOperation);
            return true;
        }
        public T GetById<T>(string partetionKey = "", string rowKey = "") where T : ITableEntity, new()
            => tableContext.CreateQuery<T>().Where(x => x.PartitionKey == partetionKey && x.RowKey == rowKey).FirstOrDefault();


        public IEnumerable<T> RetrieveAllInPartition<T>(string partitionKey) where T : ITableEntity, new()
        {
            var query = new TableQuery<T>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey));
            return tableContext.ExecuteQuerySegmented<T>(query, null).Results;
        }
        public IEnumerable<T> GetEntities<T>(Func<T, bool> condition) where T : ITableEntity, new()
         => tableContext.CreateQuery<T>().Where(condition).ToList();
    }
}
