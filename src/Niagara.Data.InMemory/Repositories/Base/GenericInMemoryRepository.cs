using System.Collections.Generic;
using System.Linq;
using Niagara.Data.Common.Entities.Base;
using Niagara.Data.Common.RepositoryInterfaces.Base;
using Niagara.Data.InMemory.InMemoryStorage.Providers.Interfaces;

namespace Niagara.Data.InMemory.Repositories.Base
{
    public class GenericInMemoryRepository<TEntity, TEntityKeyType> : IRepository<TEntity, TEntityKeyType>
        where TEntity : class, IEntity<TEntityKeyType>
    {
        protected readonly IInMemoryProvider<TEntity, TEntityKeyType> Provider;

        public GenericInMemoryRepository(IInMemoryProvider<TEntity, TEntityKeyType> provider)
        {
            Provider = provider;
        }

        public virtual TEntity GetById(TEntityKeyType id)
        {
            return Provider.Entities.FirstOrDefault(x => x.Id?.ToString() == id?.ToString());
        }

        public virtual IReadOnlyList<TEntity> GetAll()
        {
            return Provider.Entities;
        }

        public virtual void Create(TEntity entity)
        {
            entity.Id = Provider.GenerateEntityId();
            Provider.Entities.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            var current = GetById(entity.Id);

            if (current != null)
            {
                var index = Provider.Entities.IndexOf(current);
                Provider.Entities[index] = entity;
            }
        }

        public virtual void Delete(TEntity entity)
        {
            Provider.Entities.Remove(entity);
        }
    }
}