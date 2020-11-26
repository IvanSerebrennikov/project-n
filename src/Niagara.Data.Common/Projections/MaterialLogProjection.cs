using System;

namespace Niagara.Data.Common.Projections
{
    public class MaterialLogProjection
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public DateTime DateCreated { get; set; }
    }
}