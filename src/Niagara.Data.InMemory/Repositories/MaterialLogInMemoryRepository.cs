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

        public IReadOnlyList<MaterialLogProjection> GetAllReduced(int? skip = null, int? take = null)
        {
            var entities = Provider.Entities.Select(x => new MaterialLogProjection
            {
                Id = x.Id,
                Description = x.Description,
                Quantity = x.Quantity,
                DateCreated = x.DateCreated
            }).OrderByDescending(x => x.DateCreated).AsEnumerable();

            if (skip != null)
            {
                entities = entities.Skip(skip.Value);
            }

            if (take != null)
            {
                entities = entities.Take(take.Value);
            }

            return entities.ToList();
        }

        public int Count()
        {
            return Provider.Entities.Count;
        }
    }
}