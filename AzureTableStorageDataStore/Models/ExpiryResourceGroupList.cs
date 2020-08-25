using System;
using System.Collections.Generic;
using System.Text;

namespace AzureTableStorageDataStore.Models
{
    public class ExpiryResourceGroupList : BaseEntity
    {
        public ExpiryResourceGroupList(string partetionKey, string rowKey):base(partetionKey,rowKey)
        { 
        }
        public Guid SubscriptionId { get; set; }
        public string SubscriptionName { get; set; }
        public string ResourceGroupName { get; set; }
        public string InsertDate { get; set; }
    }
}
