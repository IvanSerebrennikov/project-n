using System;
using System.Collections.Generic;
using Niagara.Data.Common.Entities;
using Niagara.Data.Common.RepositoryInterfaces;

namespace Niagara.Data.Database.Repositories
{
    public class ShapeRepository : IShapeRepository
    {
        public Shape GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Shape> GetAll()
        {
            // TODO: Implement

            throw new NotImplementedException();
        }

        public void Create(Shape entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Shape entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Shape entity)
        {
            throw new NotImplementedException();
        }
    }
}