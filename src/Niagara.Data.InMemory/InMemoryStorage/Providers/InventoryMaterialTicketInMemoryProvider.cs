using System.Collections.Generic;
using Niagara.Data.Common.Entities;
using Niagara.Data.InMemory.InMemoryStorage.Providers.Interfaces;

namespace Niagara.Data.InMemory.InMemoryStorage.Providers
{
    public class InventoryMaterialTicketInMemoryProvider : IInMemoryProvider<InventoryMaterialTicket, int>
    {
        private int _initialId = 100;

        public List<InventoryMaterialTicket> Entities { get; } = new List<InventoryMaterialTicket>();

        public int GenerateEntityId()
        {
            return _initialId++;
        }
    }
}