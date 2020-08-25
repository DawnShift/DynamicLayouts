using System;
using System.Collections.Generic;
using System.Text;

namespace AzureTableStorageDataStore.Models
{
    public class AzureSubscriptionList : BaseEntity
    {
        public AzureSubscriptionList(string partetionKey, string rowKey) : base(partetionKey, rowKey)
        {

        }
        public Guid ClientId { get; set; }
        public Guid ClientSecret { get; set; }
        public DateTime InsertDate { get; set; }
        public Guid SubscriptionId { get; set; }
        public string SubscriptionName { get; set; }
        public Guid TenantId { get; set; }
    }
}
