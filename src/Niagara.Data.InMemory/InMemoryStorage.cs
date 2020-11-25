using System;
using System.Collections.Generic;
using Niagara.Data.Common.Entities;

namespace Niagara.Data.InMemory
{
    public static class InMemoryStorage
    {
        public static List<MaterialLog> MaterialLogs { get; set; } = new List<MaterialLog>
        {
            new MaterialLog
            {
                Id = "ML900",
                Description = "Maecenas eu turpis",
                Quantity = 115,
                DateCreated = new DateTime(2020, 09, 05),
                DateUpdated = new DateTime(2020, 09, 15)
            },
            new MaterialLog
            {
                Id = "ML901",
                Description = "Pellentesque pharetra",
                Quantity = 5,
                DateCreated = new DateTime(2020, 10, 25),
                DateUpdated = new DateTime(2020, 11, 01)
            },
            new MaterialLog
            {
                Id = "ML902",
                Description = "Quisque molestie",
                Quantity = 27,
                DateCreated = new DateTime(2020, 10, 29),
                DateUpdated = null
            }
        };
    }
}