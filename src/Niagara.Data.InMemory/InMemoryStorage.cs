using System.Collections.Generic;
using Niagara.Data.Common.Entities;

namespace Niagara.Data.InMemory
{
    public static class InMemoryStorage
    {
        public static List<MaterialLog> MaterialLogs { get; set; } = new List<MaterialLog>();
    }
}