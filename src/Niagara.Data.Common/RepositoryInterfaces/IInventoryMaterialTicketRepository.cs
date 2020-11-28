using System.Collections.Generic;
using Niagara.Data.Common.Entities;
using Niagara.Data.Common.RepositoryInterfaces.Base;

namespace Niagara.Data.Common.RepositoryInterfaces
{
    public interface IInventoryMaterialTicketRepository : IRepository<InventoryMaterialTicket, int>
    {
        IReadOnlyList<InventoryMaterialTicket> GetAllByMaterialLogId(string materialLogId);
    }
}