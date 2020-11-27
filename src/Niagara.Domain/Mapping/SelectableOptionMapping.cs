using Niagara.Data.Common.Entities;
using Niagara.Domain.Models;

namespace Niagara.Domain.Mapping
{
    public static class SelectableOptionMapping
    {
        public static SelectableOptionModel ToModel(this UnitOfMeasure entity)
        {
            if (entity == null)
                return null;

            return new SelectableOptionModel
            {
                Id = entity.Id,
                Value = entity.Value
            };
        }

        public static SelectableOptionModel ToModel(this PartNumber entity)
        {
            if (entity == null)
                return null;

            return new SelectableOptionModel
            {
                Id = entity.Id,
                Value = entity.Value
            };
        }

        public static SelectableOptionModel ToModel(this Supplier entity)
        {
            if (entity == null)
                return null;

            return new SelectableOptionModel
            {
                Id = entity.Id,
                Value = entity.Value
            };
        }

        public static SelectableOptionModel ToModel(this Shape entity)
        {
            if (entity == null)
                return null;

            return new SelectableOptionModel
            {
                Id = entity.Id,
                Value = entity.Value
            };
        }

        public static SelectableOptionModel ToModel(this MaterialLogType entity)
        {
            if (entity == null)
                return null;

            return new SelectableOptionModel
            {
                Id = entity.Id,
                Value = entity.Value
            };
        }
    }
}