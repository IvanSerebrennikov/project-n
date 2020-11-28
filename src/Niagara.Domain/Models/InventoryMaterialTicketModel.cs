namespace Niagara.Domain.Models
{
    public class InventoryMaterialTicketModel
    {
        public int Id { get; set; }

        public string MaterialLogLotNumber { get; set; }

        public string JobTrackNumber { get; set; }

        public string InventoryItem { get; set; }

        public string TicketNumber { get; set; }

        public string MCE { get; set; }

        public int QuantityToBeMade { get; set; }

        public int QuantityIssued { get; set; }

        public string CreatedBy { get; set; }

        public string DateCreated { get; set; }
    }
}