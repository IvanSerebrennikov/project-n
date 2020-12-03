using System;
using System.Collections.Generic;
using Niagara.Data.Common.Entities;
using Niagara.Data.Common.RepositoryInterfaces;

namespace Niagara.Data.Database.Repositories
{
    public class MaterialLogNoteRepository : IMaterialLogNoteRepository
    {
        public IReadOnlyList<MaterialLogNote> GetAllByMaterialLogId(string materialLogId)
        {
            // TODO: Implement

            throw new NotImplementedException();
        }

        public MaterialLogNote GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<MaterialLogNote> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Create(MaterialLogNote entity)
        {
            // TODO: Implement

            throw new NotImplementedException();
        }

        public void Update(MaterialLogNote entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(MaterialLogNote entity)
        {
            throw new NotImplementedException();
        }
    }
}