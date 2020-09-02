using AzureTableStorageDataStore.Models;
using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;

namespace AzureTableStorageDataStore.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Insert Entity to Azure table storage
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TableResult Insert(T entity);

        /// <summary>
        /// Bulk insert to Azure table storage
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        List<TableResult> InsertMany(List<T> entity);

        /// <summary>
        /// Insert if not exists else update entity in Azure table storage
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TableResult InsertOrUpdate(T entity);

        /// <summary>
        /// Bulk insert if not exists else update entities in Azure table storage
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        List<TableResult> InsertManyOrUpdateMany(List<T> entity);

        /// <summary>
        /// Delete entity in Azure table Storage 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Delete(T entity);

        /// <summary>
        /// Get Entity from Azure table storage by Partetion Id and RowKey
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="partetionKey"></param>
        /// <param name="rowKey"></param>
        /// <returns></returns>
        T GetById<T>(string partetionKey, string rowKey) where T : ITableEntity, new();

        /// <summary>
        /// Get All Entities in azure table by partetion key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="partitionKey"></param>
        /// <returns></returns>
        IEnumerable<T> RetrieveAllInPartition<T>(string partitionKey) where T : ITableEntity, new();

        /// <summary>
        /// GetAll with Condition filtering from azure table storage
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <returns></returns>
        IEnumerable<T> GetEntities<T>(Func<T, bool> condition) where T : ITableEntity, new();

    }
}
