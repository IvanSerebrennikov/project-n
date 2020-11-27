using Niagara.Data.Common.Entities;
using Niagara.Data.Common.RepositoryInterfaces;
using Niagara.Data.InMemory.InMemoryStorage.Providers;
using Niagara.Data.InMemory.Repositories.Base;

namespace Niagara.Data.InMemory.Repositories
{
    public class MaterialLogNoteInMemoryRepository : GenericInMemoryRepository<MaterialLogNote, int>,
        IMaterialLogNoteRepository
    {
        public MaterialLogNoteInMemoryRepository(MaterialLogNoteInMemoryProvider inMemoryProvider) : base(
            inMemoryProvider)
        {
        }
    }
}