using System;

namespace AzureTableStorageDataStore.Models
{
    public class AzureSubscriptionList :BaseEntity  
    {
        public AzureSubscriptionList() 
        { 
           
        } 
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public DateTime InsertDate { get; set; }
        public string SubscriptionId { get; set; }
        public string SubscriptionName { get; set; }
        public string TenantId { get; set; }
    }
}
