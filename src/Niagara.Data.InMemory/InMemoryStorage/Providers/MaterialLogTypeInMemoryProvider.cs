using System.Collections.Generic;
using Niagara.Data.Common.Entities;
using Niagara.Data.InMemory.InMemoryStorage.Providers.Interfaces;

namespace Niagara.Data.InMemory.InMemoryStorage.Providers
{
    public class MaterialLogTypeInMemoryProvider : IInMemoryProvider<MaterialLogType, int>
    {
        private int _initialId = 100;

        public List<MaterialLogType> Entities { get; } = new List<MaterialLogType>();

        public int GenerateEntityId()
        {
            return _initialId++;
        }
    }
}