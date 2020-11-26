using Niagara.Data.Common.Entities;
using Niagara.Data.Common.RepositoryInterfaces;
using Niagara.Data.InMemory.InMemoryStorage.Providers;
using Niagara.Data.InMemory.Repositories.Base;

namespace Niagara.Data.InMemory.Repositories
{
    public class UnitOfMeasureInMemoryRepository : GenericInMemoryRepository<UnitOfMeasure, int>,
        IUnitOfMeasureRepository
    {
        public UnitOfMeasureInMemoryRepository(UnitOfMeasureInMemoryProvider inMemoryProvider) : base(
            inMemoryProvider)
        {
        }
    }
}