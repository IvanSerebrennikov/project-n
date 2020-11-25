using System;

namespace Niagara.Domain.Models
{
    public class MaterialLogModel
    {
        public string LotNumber { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public string DateCreated { get; set; }

        public string DateUpdated { get; set; }
    }
}