using System.Collections.Generic;
using Niagara.Data.Common.Entities;
using Niagara.Data.InMemory.InMemoryStorage.Providers.Interfaces;

namespace Niagara.Data.InMemory.InMemoryStorage.Providers
{
    public class PartNumberInMemoryProvider : IInMemoryProvider<PartNumber, int>
    {
        private int _initialId = 100;

        public List<PartNumber> Entities { get; } = new List<PartNumber>();

        public int GenerateEntityId()
        {
            return _initialId++;
        }
    }
}