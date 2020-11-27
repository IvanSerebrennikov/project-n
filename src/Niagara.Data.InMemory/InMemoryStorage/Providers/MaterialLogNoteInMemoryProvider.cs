using System.Collections.Generic;
using Niagara.Data.Common.Entities;
using Niagara.Data.InMemory.InMemoryStorage.Providers.Interfaces;

namespace Niagara.Data.InMemory.InMemoryStorage.Providers
{
    public class MaterialLogNoteInMemoryProvider : IInMemoryProvider<MaterialLogNote, int>
    {
        private int _initialId = 100;

        public List<MaterialLogNote> Entities { get; } = new List<MaterialLogNote>();

        public int GenerateEntityId()
        {
            return _initialId++;
        }
    }
}