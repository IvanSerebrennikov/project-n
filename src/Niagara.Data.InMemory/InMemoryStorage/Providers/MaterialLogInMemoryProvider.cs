using System;
using System.Collections.Generic;
using Niagara.Data.Common.Entities;
using Niagara.Data.InMemory.InMemoryStorage.Providers.Interfaces;

namespace Niagara.Data.InMemory.InMemoryStorage.Providers
{
    public class MaterialLogInMemoryProvider : IInMemoryProvider<MaterialLog, string>
    {
        private readonly List<string> _existingIds = new List<string>();

        public List<MaterialLog> Entities { get; } = new List<MaterialLog>();

        public string GenerateEntityId()
        {
            var maxAttempts = 1000;

            for (var i = 0; i < maxAttempts; i++)
            {
                var id = $"ML{new Random(i).Next(1000, 9999)}";

                if (!_existingIds.Contains(id))
                {
                    _existingIds.Add(id);
                    return id;
                }
            }

            return Guid.NewGuid().ToString();
        }
    }
}