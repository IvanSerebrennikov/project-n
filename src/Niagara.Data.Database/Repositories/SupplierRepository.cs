using System;
using System.Collections.Generic;
using Niagara.Data.Common.Entities;
using Niagara.Data.Common.RepositoryInterfaces;

namespace Niagara.Data.Database.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        public Supplier GetByValue(string value)
        {
            // TODO: Implement

            throw new NotImplementedException();
        }

        public Supplier GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Supplier> GetAll()
        {
            // TODO: Implement

            throw new NotImplementedException();
        }

        public void Create(Supplier entity)
        {
            // TODO: Implement

            throw new NotImplementedException();
        }

        public void Update(Supplier entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Supplier entity)
        {
            throw new NotImplementedException();
        }
    }
}