using System.Collections.Generic;
using Niagara.Domain.Models;

namespace Niagara.Domain.Services.Interfaces
{
    public interface IInventoryMaterialTicketService
    {
        IReadOnlyList<InventoryMaterialTicketModel> GetAllByLotNumber(string lotNumber);

        InventoryMaterialTicketModel GetById(int ticketId);

        InventoryMaterialTicketModel Create(InventoryMaterialTicketModel model);
    }
}