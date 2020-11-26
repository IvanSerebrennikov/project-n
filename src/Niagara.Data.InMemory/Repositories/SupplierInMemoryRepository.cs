using Niagara.Data.Common.Entities;
using Niagara.Data.Common.RepositoryInterfaces;
using Niagara.Data.InMemory.InMemoryStorage.Providers;
using Niagara.Data.InMemory.Repositories.Base;

namespace Niagara.Data.InMemory.Repositories
{
    public class SupplierInMemoryRepository : GenericInMemoryRepository<Supplier, int>,
        ISupplierRepository
    {
        public SupplierInMemoryRepository(SupplierInMemoryProvider inMemoryProvider) : base(
            inMemoryProvider)
        {
        }
    }
}