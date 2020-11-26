using System.Collections.Generic;
using Niagara.Data.Common.Entities;
using Niagara.Data.InMemory.InMemoryStorage.Providers.Interfaces;

namespace Niagara.Data.InMemory.InMemoryStorage.Providers
{
    public class SupplierInMemoryProvider : IInMemoryProvider<Supplier, int>
    {
        private int _initialId = 100;

        public List<Supplier> Entities { get; } = new List<Supplier>();

        public int GenerateEntityId()
        {
            return _initialId++;
        }
    }
}