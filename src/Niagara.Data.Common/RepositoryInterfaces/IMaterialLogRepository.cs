using System.Collections.Generic;
using Niagara.Data.Common.Entities;
using Niagara.Data.Common.Projections;
using Niagara.Data.Common.RepositoryInterfaces.Base;

namespace Niagara.Data.Common.RepositoryInterfaces
{
    public interface IMaterialLogRepository : IRepository<MaterialLog, string>
    {
        IReadOnlyList<MaterialLogProjection> GetAllReduced();

        int Count();
    }
}