using System.Collections.Generic;
using System.Linq;
using Niagara.Data.Common.Entities.Base;
using Niagara.Data.Common.RepositoryInterfaces.Base;

namespace Niagara.Data.InMemory.Repositories.Base
{
    public class GenericInMemoryRepository<TEntity, TEntityKeyType> : IRepository<TEntity, TEntityKeyType>
        where TEntity : class, IEntity<TEntityKeyType>
    {
        protected List<TEntity> Entities = new List<TEntity>();

        public virtual TEntity GetById(TEntityKeyType id)
        {
            return Entities.FirstOrDefault(x => x.Id.ToString() == id.ToString());
        }

        public virtual IReadOnlyList<TEntity> GetAll()
        {
            return Entities;
        }

        public virtual void Create(TEntity entity)
        {
            Entities.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            var current = GetById(entity.Id);

            if (current != null) Entities[Entities.IndexOf(current)] = entity;
        }

        public virtual void Delete(TEntity entity)
        {
            Entities.Remove(entity);
        }

        protected void SetEntitiesSource(List<TEntity> source)
        {
            Entities = source;
        }
    }
}