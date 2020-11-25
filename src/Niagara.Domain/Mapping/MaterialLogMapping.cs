using System.Globalization;
using Niagara.Data.Common.Entities;
using Niagara.Domain.Models;

namespace Niagara.Domain.Mapping
{
    public static class MaterialLogMapping
    {
        public static MaterialLogModel ToModel(this MaterialLog entity)
        {
            if (entity == null)
                return null;

            return new MaterialLogModel
            {
                LotNumber = entity.Id,
                Description = entity.Description,
                Quantity = entity.Quantity,
                DateCreated = entity.DateCreated.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                DateUpdated = entity.DateUpdated?.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)
            };
        }

        public static void MapFromModel(this MaterialLog entity, MaterialLogModel model)
        {
            if (entity != null && model != null)
            {
                entity.Description = model.Description;
                entity.Quantity = model.Quantity;
            }
        }
    }
}