using Niagara.Data.Common.Entities;
using Niagara.Domain.Helpers;
using Niagara.Domain.Models;

namespace Niagara.Domain.Mapping
{
    public static class InventoryMaterialTicketMapping
    {
        public static InventoryMaterialTicketModel ToModel(this InventoryMaterialTicket entity)
        {
            if (entity == null)
                return null;

            return new InventoryMaterialTicketModel
            {
                Id = entity.Id,
                MaterialLogLotNumber = entity.MaterialLogId,
                JobTrackNumber = entity.JobTrackNumber,
                InventoryItem = entity.InventoryItem,
                TicketNumber = entity.TicketNumber,
                MCE = entity.MCE,
                QuantityToBeMade = entity.QuantityToBeMade,
                QuantityIssued = entity.QuantityIssued,
                CreatedBy = entity.CreatedBy,
                DateCreated = entity.DateCreated.ToDateString()
            };
        }

        public static void MapFromModel(this InventoryMaterialTicket entity, InventoryMaterialTicketModel model)
        {
            if (entity != null && model != null)
            {
                entity.MaterialLogId = model.MaterialLogLotNumber;
                entity.JobTrackNumber = model.JobTrackNumber;
                entity.InventoryItem = model.InventoryItem;
                entity.TicketNumber = model.TicketNumber;
                entity.MCE = model.MCE;
                entity.QuantityToBeMade = model.QuantityToBeMade;
                entity.QuantityIssued = model.QuantityIssued;
            }
        }
    }
}