using Niagara.Data.Common.Entities;
using Niagara.Data.Common.RepositoryInterfaces.Base;

namespace Niagara.Data.Common.RepositoryInterfaces
{
    public interface ISupplierRepository : IRepository<Supplier, int>
    {
        Supplier GetByValue(string value);
    }
}