using Niagara.Data.Common.Entities;
using Niagara.Domain.Helpers;
using Niagara.Domain.Models;

namespace Niagara.Domain.Mapping
{
    public static class MaterialLogNoteMapping
    {
        public static MaterialLogNoteModel ToModel(this MaterialLogNote entity)
        {
            if (entity == null)
                return null;

            return new MaterialLogNoteModel
            {
                Id = entity.Id,
                MaterialLogLotNumber = entity.MaterialLogId,
                Text = entity.Text,
                CreatedBy = entity.CreatedBy,
                DateCreated = entity.DateTimeCreated.ToDateString(),
                TimeCreated = entity.DateTimeCreated.ToTimeString()
            };
        }
    }
}