using AzureTableStorageDataStore.Models;
using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;

namespace AzureTableStorageDataStore.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        TableResult Insert(T entity);
        List<TableResult> InsertMany(List<T> entity);
        TableResult InsertOrUpdate(T entity);
        List<TableResult> InsertManyOrUpdateMany(List<T> entity);
        bool Delete(T entity);
        T GetById<T>(string partetionKey, string rowKey) where T : ITableEntity, new(); 
        IEnumerable<T> RetrieveAllInPartition<T>(string partitionKey) where T : ITableEntity, new();
        IEnumerable<T> GetEntities<T>(Func<T, bool> condition) where T : ITableEntity, new();

    }
}
