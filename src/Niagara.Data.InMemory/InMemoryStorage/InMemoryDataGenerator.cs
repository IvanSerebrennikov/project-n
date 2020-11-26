using System;
using Niagara.Data.Common.Entities;
using Niagara.Data.InMemory.InMemoryStorage.Providers;

namespace Niagara.Data.InMemory.InMemoryStorage
{
    public class InMemoryDataGenerator
    {
        private readonly MaterialLogInMemoryProvider _materialLogsInMemoryProvider;
        private readonly MaterialLogTypeInMemoryProvider _materialLogTypeInMemoryProvider;
        private readonly PartNumberInMemoryProvider _partNumberInMemoryProvider;
        private readonly ShapeInMemoryProvider _shapeInMemoryProvider;
        private readonly SupplierInMemoryProvider _supplierInMemoryProvider;
        private readonly UnitOfMeasureInMemoryProvider _unitOfMeasureInMemoryProvider;

        public InMemoryDataGenerator(
            MaterialLogInMemoryProvider materialLogsInMemoryProvider,
            MaterialLogTypeInMemoryProvider materialLogTypeInMemoryProvider,
            PartNumberInMemoryProvider partNumberInMemoryProvider,
            ShapeInMemoryProvider shapeInMemoryProvider,
            SupplierInMemoryProvider supplierInMemoryProvider,
            UnitOfMeasureInMemoryProvider unitOfMeasureInMemoryProvider
        )
        {
            _materialLogsInMemoryProvider = materialLogsInMemoryProvider;
            _materialLogTypeInMemoryProvider = materialLogTypeInMemoryProvider;
            _partNumberInMemoryProvider = partNumberInMemoryProvider;
            _shapeInMemoryProvider = shapeInMemoryProvider;
            _supplierInMemoryProvider = supplierInMemoryProvider;
            _unitOfMeasureInMemoryProvider = unitOfMeasureInMemoryProvider;
        }

        public void Generate()
        {
            GenerateMaterialLogs();
        }

        private void GenerateMaterialLogs()
        {
            _materialLogsInMemoryProvider.Entities.Add(
                new MaterialLog
                {
                    Id = _materialLogsInMemoryProvider.GenerateEntityId(),
                    Description = "Maecenas eu turpis",
                    Quantity = 115,
                    DateCreated = new DateTime(2020, 09, 05),
                    DateUpdated = new DateTime(2020, 09, 15)
                });

            _materialLogsInMemoryProvider.Entities.Add(
                new MaterialLog
                {
                    Id = _materialLogsInMemoryProvider.GenerateEntityId(),
                    Description = "Pellentesque pharetra",
                    Quantity = 5,
                    DateCreated = new DateTime(2020, 10, 25),
                    DateUpdated = new DateTime(2020, 11, 01)
                });

            _materialLogsInMemoryProvider.Entities.Add(
                new MaterialLog
                {
                    Id = _materialLogsInMemoryProvider.GenerateEntityId(),
                    Description = "Quisque molestie",
                    Quantity = 27,
                    DateCreated = new DateTime(2020, 10, 29),
                    DateUpdated = null
                });
        }
    }
}