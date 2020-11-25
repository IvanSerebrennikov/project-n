using System;
using System.Collections.Generic;
using System.Text;
using Niagara.Data.Common.Entities.Base;

namespace Niagara.Data.Common.Entities
{
    public class PartNumber : IEntity<int>
    {
        public int Id { get; set; }

        public string Value { get; set; }
    }
}
