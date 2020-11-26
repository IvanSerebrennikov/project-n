using Niagara.Data.Common.Entities;
using Niagara.Data.Common.RepositoryInterfaces;
using Niagara.Data.InMemory.InMemoryStorage.Providers;
using Niagara.Data.InMemory.Repositories.Base;

namespace Niagara.Data.InMemory.Repositories
{
    public class ShapeInMemoryRepository : GenericInMemoryRepository<Shape, int>,
        IShapeRepository
    {
        public ShapeInMemoryRepository(ShapeInMemoryProvider inMemoryProvider) : base(
            inMemoryProvider)
        {
        }
    }
}