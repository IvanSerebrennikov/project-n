using System.Collections.Generic;
using System.Linq;
using Niagara.Data.Common.Entities;
using Niagara.Data.Common.Projections;
using Niagara.Data.Common.RepositoryInterfaces;
using Niagara.Data.InMemory.InMemoryStorage.Providers;
using Niagara.Data.InMemory.Repositories.Base;

namespace Niagara.Data.InMemory.Repositories
{
    public class MaterialLogInMemoryRepository : GenericInMemoryRepository<MaterialLog, string>, IMaterialLogRepository
    {
        public MaterialLogInMemoryRepository(MaterialLogInMemoryProvider inMemoryProvider) : base(inMemoryProvider)
        {
        }

        public IReadOnlyList<MaterialLogProjection> GetAllReduced()
        {
            return Provider.Entities.Select(x => new MaterialLogProjection
            {
                Id = x.Id,
                Description = x.Description,
                Quantity = x.Quantity,
                DateCreated = x.DateCreated
            }).ToList();
        }

        public int Count()
        {
            return Provider.Entities.Count;
        }
    }
}