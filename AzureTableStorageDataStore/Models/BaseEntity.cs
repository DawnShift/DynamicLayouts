using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureTableStorageDataStore.Models
{
    public class BaseEntity : TableEntity, ITableEntity
    {
        public BaseEntity(string partitionKey, string rowKey)
        {
            PartitionKey = partitionKey;
            RowKey = rowKey;
        }
    }
}
