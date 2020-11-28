using System.Collections.Generic;
using System.Linq;
using Niagara.Data.Common.Entities;
using Niagara.Data.Common.RepositoryInterfaces;
using Niagara.Data.InMemory.InMemoryStorage.Providers;
using Niagara.Data.InMemory.Repositories.Base;

namespace Niagara.Data.InMemory.Repositories
{
    public class InventoryMaterialTicketInMemoryRepository : GenericInMemoryRepository<InventoryMaterialTicket, int>,
        IInventoryMaterialTicketRepository
    {
        public InventoryMaterialTicketInMemoryRepository(InventoryMaterialTicketInMemoryProvider inMemoryProvider) : base(
            inMemoryProvider)
        {
        }

        public IReadOnlyList<InventoryMaterialTicket> GetAllByMaterialLogId(string materialLogId)
        {
            return Provider.Entities.Where(x => x.MaterialLogId == materialLogId).ToList();
        }
    }
}