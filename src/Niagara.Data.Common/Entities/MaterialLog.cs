using System;
using Niagara.Data.Common.Entities.Base;

namespace Niagara.Data.Common.Entities
{
    public class MaterialLog : IEntity<string>
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }
    }
}