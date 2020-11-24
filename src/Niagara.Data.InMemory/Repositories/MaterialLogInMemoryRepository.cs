using System;
using Niagara.Data.Common.Entities;
using Niagara.Data.Common.RepositoryInterfaces;
using Niagara.Data.InMemory.Repositories.Base;

namespace Niagara.Data.InMemory.Repositories
{
    public class MaterialLogInMemoryRepository : GenericInMemoryRepository<MaterialLog, string>, IMaterialLogRepository
    {
        public MaterialLogInMemoryRepository()
        {
            SetEntitiesSource(InMemoryStorage.MaterialLogs);
        }

        public override void Create(MaterialLog entity)
        {
            entity.Id = $"ML{new Random().Next(1000, 9999)}";

            base.Create(entity);
        }
    }
}