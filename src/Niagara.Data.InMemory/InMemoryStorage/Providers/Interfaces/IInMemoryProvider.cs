using System.Collections.Generic;
using Niagara.Data.Common.Entities.Base;

namespace Niagara.Data.InMemory.InMemoryStorage.Providers.Interfaces
{
    public interface IInMemoryProvider<TEntity, out TEntityKeyType>
        where TEntity : class, IEntity<TEntityKeyType>
    {
        List<TEntity> Entities { get; }

        TEntityKeyType GenerateEntityId();
    }
}