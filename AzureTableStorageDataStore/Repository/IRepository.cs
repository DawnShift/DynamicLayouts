using AzureTableStorageDataStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureTableStorageDataStore.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
    }
}
