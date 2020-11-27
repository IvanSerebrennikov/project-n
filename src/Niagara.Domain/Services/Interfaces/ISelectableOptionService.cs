using System.Collections.Generic;
using Niagara.Domain.Models;

namespace Niagara.Domain.Services.Interfaces
{
    public interface ISelectableOptionService
    {
        IReadOnlyList<SelectableOptionModel> GetUnitOfMeasures();


        IReadOnlyList<SelectableOptionModel> GetPartNumbers();

        SelectableOptionModel GetPartNumberByValue(string value);

        SelectableOptionModel CreatePartNumber(string value);


        IReadOnlyList<SelectableOptionModel> GetSuppliers();

        SelectableOptionModel GetSupplierByValue(string value);

        SelectableOptionModel CreateSupplier(string value);


        IReadOnlyList<SelectableOptionModel> GetShapes();


        IReadOnlyList<SelectableOptionModel> GetMaterialLogTypes();
    }
}