using System.Collections.Generic;
using Niagara.Data.Common.Entities;
using Niagara.Data.InMemory.InMemoryStorage.Providers.Interfaces;

namespace Niagara.Data.InMemory.InMemoryStorage.Providers
{
    public class UnitOfMeasureInMemoryProvider : IInMemoryProvider<UnitOfMeasure, int>
    {
        private int _initialId = 100;

        public List<UnitOfMeasure> Entities { get; } = new List<UnitOfMeasure>();

        public int GenerateEntityId()
        {
            return _initialId++;
        }
    }
}