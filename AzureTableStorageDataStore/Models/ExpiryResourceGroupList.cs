using System;

namespace AzureTableStorageDataStore.Models
{
    public class ExpiryResourceGroupList : BaseEntity
    {
        public ExpiryResourceGroupList()
        { 
        }
        public Guid SubscriptionId { get; set; }
        public string SubscriptionName { get; set; }
        public string ResourceGroupName { get; set; }
        public string InsertDate { get; set; }
    }
}
