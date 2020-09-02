
using Microsoft.Azure.Cosmos.Table;

namespace AzureTableStorageDataStore.Models
{
    public class BaseEntity : TableEntity
    {
        //mapper to map partition Key
       // public string PartKey { get { return PartitionKey; } set { PartitionKey = value; } }
    }
}
