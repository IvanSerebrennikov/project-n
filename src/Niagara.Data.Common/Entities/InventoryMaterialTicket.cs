using System;
using Niagara.Data.Common.Entities.Base;

namespace Niagara.Data.Common.Entities
{
    public class InventoryMaterialTicket : IEntity<int>
    {
        public int Id { get; set; }

        public string MaterialLogId { get; set; }

        public string JobTrackNumber { get; set; }

        public string InventoryItem { get; set; }

        public string TicketNumber { get; set; }

        public string MCE { get; set; }

        public int QuantityToBeMade { get; set; }

        public int QuantityIssued { get; set; }

        public string Notes { get; set; }

        public string CreatedBy { get; set; }

        public DateTime DateCreated { get; set; }
    }
}