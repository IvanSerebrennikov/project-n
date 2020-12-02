using System.Collections.Generic;
using Niagara.Domain.Models;

namespace Niagara.Domain.Services.Interfaces
{
    public interface ISelectableOptionService
    {
        IReadOnlyList<SelectableOptionModel> GetUnitOfMeasures();

        IReadOnlyList<SelectableOptionModel> GetPartNumbers();

        IReadOnlyList<SelectableOptionModel> GetSuppliers();

        IReadOnlyList<SelectableOptionModel> GetShapes();

        IReadOnlyList<SelectableOptionModel> GetMaterialLogTypes();
    }
}