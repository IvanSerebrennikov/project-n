using System.Collections.Generic;
using Niagara.Domain.Models;

namespace Niagara.Domain.Services.Interfaces
{
    public interface IMaterialLogService
    {
        MaterialLogModel GetByLotNumber(string lotNumber);

        IReadOnlyList<MaterialLogModel> GetAll();

        IReadOnlyList<MaterialLogReducedModel> GetAllReduced(int? skip = null, int? take = null);

        int Count();

        MaterialLogModel Create(MaterialLogModel model, string partNumberValue, string supplierValue, IReadOnlyList<string> newNotes);

        /// <summary>
        /// Update existing Material Log entry.
        /// </summary>
        /// <param name="model">Material Log model in which properties that should be updated has new actual values.</param>
        /// <returns>Material Log model that mapped from successfully updated DB entry. Or 'null' if entry was not found.</returns>
        MaterialLogModel Update(MaterialLogModel model, string partNumberValue, string supplierValue, IReadOnlyList<string> newNotes);

        IReadOnlyList<MaterialLogNoteModel> GetNotes(string lotNumber);
    }
}