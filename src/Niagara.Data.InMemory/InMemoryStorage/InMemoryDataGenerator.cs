using System;
using System.Collections.Generic;
using Niagara.Data.Common.Entities;
using Niagara.Data.Common.Entities.Base;
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
            GenerateUnitOfMeasures();
            GeneratePartNumbers();
            GenerateSuppliers();
            GenerateShapes();
            GenerateMaterialLogTypes();
            GenerateMaterialLogs();
        }

        private void GenerateUnitOfMeasures()
        {
            var values = new List<string>
            {
                "Each",
                "Feet",
                "Inches",
                "Lbs",
                "Other"
            };

            foreach (var value in values)
                _unitOfMeasureInMemoryProvider.Entities.Add(
                    new UnitOfMeasure
                    {
                        Id = _unitOfMeasureInMemoryProvider.GenerateEntityId(),
                        Value = value
                    });
        }

        private void GeneratePartNumbers()
        {
            var values = new List<string>
            {
                "Part number 1",
                "Part number 2",
                "Part number A",
                "Part number B",
                "Part number X"
            };

            foreach (var value in values)
                _partNumberInMemoryProvider.Entities.Add(
                    new PartNumber
                    {
                        Id = _partNumberInMemoryProvider.GenerateEntityId(),
                        Value = value
                    });
        }

        private void GenerateSuppliers()
        {
            var values = new List<string>
            {
                "Vendor 1",
                "Vendor 2",
                "Vendor A",
                "Vendor B",
                "Vendor X"
            };

            foreach (var value in values)
                _supplierInMemoryProvider.Entities.Add(
                    new Supplier
                    {
                        Id = _supplierInMemoryProvider.GenerateEntityId(),
                        Value = value
                    });
        }

        private void GenerateShapes()
        {
            var values = new List<string>
            {
                "Block",
                "Round",
                "Other"
            };

            foreach (var value in values)
                _shapeInMemoryProvider.Entities.Add(
                    new Shape
                    {
                        Id = _shapeInMemoryProvider.GenerateEntityId(),
                        Value = value
                    });
        }

        private void GenerateMaterialLogTypes()
        {
            var values = new List<string>
            {
                "T1",
                "T2",
                "T3",
                "T-A",
                "T-B",
                "T-C",
                "Type Z",
                "Type X",
                "Type Y",
                "tML zzzzzz",
                "tMN xxxxxx",
                "_0z",
                "_0x"
            };

            foreach (var value in values)
                _materialLogTypeInMemoryProvider.Entities.Add(
                    new MaterialLogType
                    {
                        Id = _materialLogTypeInMemoryProvider.GenerateEntityId(),
                        Value = value
                    });
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
                    DateUpdated = new DateTime(2020, 09, 15),

                    IsMagnet = true,
                    BHmax = "95",
                    Br = "10",
                    Hci = "119",
                    Hc = "1002",
                    ShapeId = GetAnyEntityId(_shapeInMemoryProvider.Entities, 999),
                    Dim1 = 14,
                    Dim2 = 23,
                    DimLm = 106,

                    PONumber = $"PO{new Random(1000).Next(1000, 9999)}",
                    UnitOfMeasureId = GetAnyEntityId(_unitOfMeasureInMemoryProvider.Entities, 1001),
                    PartNumberId = GetAnyEntityId(_partNumberInMemoryProvider.Entities, 1002),
                    IsAvailable = true,
                    SupplierId = GetAnyEntityId(_supplierInMemoryProvider.Entities, 1003),
                    IsDFARS = true,
                    PrimaryLocation = "Nulla facilisi",
                    MaterialLogTypeId = GetAnyEntityId(_materialLogTypeInMemoryProvider.Entities, 1004),
                    SupplierMaterialGrade = "Morbi a mauris",
                    MRTNumber = 19,
                    CreatedBy = "User11"
                });

            _materialLogsInMemoryProvider.Entities.Add(
                new MaterialLog
                {
                    Id = _materialLogsInMemoryProvider.GenerateEntityId(),
                    Description = "Donec luctus mattis justo vel facilisis",
                    Quantity = 5,
                    DateCreated = new DateTime(2020, 10, 25),
                    DateUpdated = new DateTime(2020, 11, 01),

                    IsMagnet = false,
                    MaterialCompliesTo = "Fusce in mi nisi",
                    Bars1 = 16,
                    Bars2 = 3,
                    Bars3 = 14,
                    FT1 = 105,
                    FT2 = null,
                    FT3 = 4,
                    TotalFT = 1742,

                    PONumber = $"PO{new Random(1000).Next(1000, 9999)}",
                    UnitOfMeasureId = GetAnyEntityId(_unitOfMeasureInMemoryProvider.Entities, 1001),
                    PartNumberId = GetAnyEntityId(_partNumberInMemoryProvider.Entities, 1002),
                    IsAvailable = true,
                    SupplierId = GetAnyEntityId(_supplierInMemoryProvider.Entities, 1003),
                    IsDFARS = false,
                    PrimaryLocation = "Cras ut viverra lorem",
                    MaterialLogTypeId = GetAnyEntityId(_materialLogTypeInMemoryProvider.Entities, 1004),
                    SupplierMaterialGrade = "Proin fermentum",
                    MRTNumber = 54,
                    CreatedBy = "Bob"
                });

            _materialLogsInMemoryProvider.Entities.Add(
                new MaterialLog
                {
                    Id = _materialLogsInMemoryProvider.GenerateEntityId(),
                    Description = "Duis consequat risus quis nibh faucibus lacinia",
                    Quantity = 27,
                    DateCreated = new DateTime(2020, 10, 29),
                    DateUpdated = null,

                    IsMagnet = true,
                    BHmax = "87",
                    Br = "15",
                    Hci = "100",
                    Hc = "817",
                    ShapeId = GetAnyEntityId(_shapeInMemoryProvider.Entities, 999),
                    Dim1 = 3,
                    Dim2 = 2,
                    DimLm = 1007,

                    PONumber = $"PO{new Random(1000).Next(1000, 9999)}",
                    UnitOfMeasureId = GetAnyEntityId(_unitOfMeasureInMemoryProvider.Entities, 1001),
                    PartNumberId = GetAnyEntityId(_partNumberInMemoryProvider.Entities, 1002),
                    IsAvailable = false,
                    SupplierId = GetAnyEntityId(_supplierInMemoryProvider.Entities, 1003),
                    IsDFARS = true,
                    PrimaryLocation = "Vivamus metus quam",
                    MaterialLogTypeId = GetAnyEntityId(_materialLogTypeInMemoryProvider.Entities, 1004),
                    SupplierMaterialGrade = "Maecenas ac mauris",
                    MRTNumber = 28,
                    CreatedBy = "User X"
                });
        }

        private int GetAnyEntityId<TEntity>(List<TEntity> entities, int seed)
            where TEntity : IEntity<int>
        {
            var unitOfMeasures = entities;

            var index = new Random(seed).Next(0, unitOfMeasures.Count);

            return unitOfMeasures[index].Id;
        }
    }
}