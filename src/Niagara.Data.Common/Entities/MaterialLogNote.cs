using System;
using Niagara.Data.Common.Entities.Base;

namespace Niagara.Data.Common.Entities
{
    public class MaterialLogNote : IEntity<int>
    {
        public int Id { get; set; }

        public string MaterialLogId { get; set; }

        public string Text { get; set; }

        public string CreatedBy { get; set; }

        public DateTime DateTimeCreated { get; set; }
    }
}