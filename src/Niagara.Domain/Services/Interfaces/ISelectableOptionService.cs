using System.Collections.Generic;
using Niagara.Domain.Models;

namespace Niagara.Domain.Services.Interfaces
{
    public interface ISelectableOptionService
    {
        IReadOnlyList<SelectableOptionModel> GetUnitOfMeasures();


        IReadOnlyList<SelectableOptionModel> GetPartNumbers();

        SelectableOptionModel CreatePartNumber(SelectableOptionModel model);


        IReadOnlyList<SelectableOptionModel> GetSuppliers();

        SelectableOptionModel CreateSupplier(SelectableOptionModel model);


        IReadOnlyList<SelectableOptionModel> GetShapes();


        IReadOnlyList<SelectableOptionModel> GetMaterialLogTypes();
    }
}