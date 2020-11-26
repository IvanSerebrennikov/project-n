using System.Collections.Generic;
using Niagara.Data.Common.Entities;
using Niagara.Data.InMemory.InMemoryStorage.Providers.Interfaces;

namespace Niagara.Data.InMemory.InMemoryStorage.Providers
{
    public class ShapeInMemoryProvider : IInMemoryProvider<Shape, int>
    {
        private int _initialId = 100;

        public List<Shape> Entities { get; } = new List<Shape>();

        public int GenerateEntityId()
        {
            return _initialId++;
        }
    }
}