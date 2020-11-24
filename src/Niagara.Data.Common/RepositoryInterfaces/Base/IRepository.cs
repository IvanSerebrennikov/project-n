using System.Collections.Generic;
using Niagara.Data.Common.Entities.Base;

namespace Niagara.Data.Common.RepositoryInterfaces.Base
{
    public interface IRepository<TEntity, in TEntityKeyType>
        where TEntity : class, IEntity<TEntityKeyType>
    {
        TEntity GetById(TEntityKeyType id);

        IReadOnlyList<TEntity> GetAll();

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}