using System.Collections.Generic;
using Niagara.Data.Common.Entities;
using Niagara.Data.Common.RepositoryInterfaces.Base;

namespace Niagara.Data.Common.RepositoryInterfaces
{
    public interface IMaterialLogNoteRepository : IRepository<MaterialLogNote, int>
    {
        IReadOnlyList<MaterialLogNote> GetAllByMaterialLogId(string materialLogId);
    }
}