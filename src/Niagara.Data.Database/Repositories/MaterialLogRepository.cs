using System;
using System.Collections.Generic;
using Niagara.Data.Common.Entities;
using Niagara.Data.Common.Projections;
using Niagara.Data.Common.RepositoryInterfaces;

namespace Niagara.Data.Database.Repositories
{
    public class MaterialLogRepository : IMaterialLogRepository
    {
        public IReadOnlyList<MaterialLogProjection> GetAllReduced(int? skip = null, int? take = null)
        {
            // TODO: Implement

            throw new NotImplementedException();
        }

        public int Count()
        {
            // TODO: Implement

            throw new NotImplementedException();
        }

        public MaterialLog GetById(string id)
        {
            // TODO: Implement

            throw new NotImplementedException();
        }

        public IReadOnlyList<MaterialLog> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Create(MaterialLog entity)
        {
            // TODO: Implement

            throw new NotImplementedException();
        }

        public void Update(MaterialLog entity)
        {
            // TODO: Implement

            throw new NotImplementedException();
        }

        public void Delete(MaterialLog entity)
        {
            throw new NotImplementedException();
        }
    }
}