using System.Collections.Generic;
using Niagara.Domain.Models;

namespace Niagara.Domain.Services.Interfaces
{
    public interface IMaterialLogNoteService
    {
        IReadOnlyList<MaterialLogNoteModel> GetAllByLotNumber(string lotNumber);

        MaterialLogNoteModel Create(string materialLogLotNumber, string text);
    }
}