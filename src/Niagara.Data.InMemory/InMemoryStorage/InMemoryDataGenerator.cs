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
        private readonly MaterialLogNoteInMemoryProvider _materialLogNoteInMemoryProvider;

        public InMemoryDataGenerator(
            MaterialLogInMemoryProvider materialLogsInMemoryProvider,
            MaterialLogTypeInMemoryProvider materialLogTypeInMemoryProvider,
            PartNumberInMemoryProvider partNumberInMemoryProvider,
            ShapeInMemoryProvider shapeInMemoryProvider,
            SupplierInMemoryProvider supplierInMemoryProvider,
            UnitOfMeasureInMemoryProvider unitOfMeasureInMemoryProvider,
            MaterialLogNoteInMemoryProvider materialLogNoteInMemoryProvider
        )
        {
            _materialLogsInMemoryProvider = materialLogsInMemoryProvider;
            _materialLogTypeInMemoryProvider = materialLogTypeInMemoryProvider;
            _partNumberInMemoryProvider = partNumberInMemoryProvider;
            _shapeInMemoryProvider = shapeInMemoryProvider;
            _supplierInMemoryProvider = supplierInMemoryProvider;
            _unitOfMeasureInMemoryProvider = unitOfMeasureInMemoryProvider;
            _materialLogNoteInMemoryProvider = materialLogNoteInMemoryProvider;
        }

        public void Generate()
        {
            GenerateUnitOfMeasures();
            GeneratePartNumbers();
            GenerateSuppliers();
            GenerateShapes();
            GenerateMaterialLogTypes();

            GenerateMaterialLogs();

            GenerateMaterialLogNotes();
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
            var count = 15;

            for (var i = 0; i < count; i++)
            {
                _materialLogsInMemoryProvider.Entities.Add(
                    new MaterialLog
                    {
                        Id = _materialLogsInMemoryProvider.GenerateEntityId(),
                        Description = string.Join(" ", Faker.Lorem.Words(3)),
                        Quantity = Faker.RandomNumber.Next(1, 300),
                        DateCreated = new DateTime(2020, 10, Faker.RandomNumber.Next(1, 29)),
                        DateUpdated = new DateTime(2020, 11, 27),

                        IsMagnet = true,
                        BHmax = Faker.RandomNumber.Next(1, 1000).ToString(),
                        Br = Faker.RandomNumber.Next(1, 1000).ToString(),
                        Hci = Faker.RandomNumber.Next(1, 1000).ToString(),
                        Hc = Faker.RandomNumber.Next(1, 1000).ToString(),
                        ShapeId = GetAnyEntityId(_shapeInMemoryProvider.Entities),
                        Dim1 = Faker.RandomNumber.Next(1, 200),
                        Dim2 = Faker.RandomNumber.Next(1, 200),
                        DimLm = Faker.RandomNumber.Next(1, 200),

                        PONumber = $"PO{Faker.RandomNumber.Next(1000, 9999)}",
                        UnitOfMeasureId = GetAnyEntityId(_unitOfMeasureInMemoryProvider.Entities),
                        PartNumberId = GetAnyEntityId(_partNumberInMemoryProvider.Entities),
                        IsAvailable = Faker.Boolean.Random(),
                        SupplierId = GetAnyEntityId(_supplierInMemoryProvider.Entities),
                        IsDFARS = Faker.Boolean.Random(),
                        PrimaryLocation = Faker.Country.Name(),
                        MaterialLogTypeId = GetAnyEntityId(_materialLogTypeInMemoryProvider.Entities),
                        SupplierMaterialGrade = string.Join(" ", Faker.Lorem.Words(3)),
                        MRTNumber = Faker.RandomNumber.Next(100, 999),
                        CreatedBy = Faker.Name.FullName()
                    });

                _materialLogsInMemoryProvider.Entities.Add(
                    new MaterialLog
                    {
                        Id = _materialLogsInMemoryProvider.GenerateEntityId(),
                        Description = string.Join(" ", Faker.Lorem.Words(3)),
                        Quantity = Faker.RandomNumber.Next(1, 300),
                        DateCreated = new DateTime(2020, 10, Faker.RandomNumber.Next(1, 29)),
                        DateUpdated = new DateTime(2020, 11, 27),

                        IsMagnet = false,
                        MaterialCompliesTo = string.Join(" ", Faker.Lorem.Words(4)),
                        Bars1 = Faker.Boolean.Random() ? (int?)Faker.RandomNumber.Next(1, 90) : null,
                        Bars2 = Faker.Boolean.Random() ? (int?)Faker.RandomNumber.Next(1, 90) : null,
                        Bars3 = Faker.Boolean.Random() ? (int?)Faker.RandomNumber.Next(1, 90) : null,
                        FT1 = Faker.Boolean.Random() ? (int?)Faker.RandomNumber.Next(1, 190) : null,
                        FT2 = Faker.Boolean.Random() ? (int?)Faker.RandomNumber.Next(1, 190) : null,
                        FT3 = Faker.Boolean.Random() ? (int?)Faker.RandomNumber.Next(1, 190) : null,
                        TotalFT = Faker.RandomNumber.Next(100, 1000),

                        PONumber = $"PO{Faker.RandomNumber.Next(1000, 9999)}",
                        UnitOfMeasureId = GetAnyEntityId(_unitOfMeasureInMemoryProvider.Entities),
                        PartNumberId = GetAnyEntityId(_partNumberInMemoryProvider.Entities),
                        IsAvailable = Faker.Boolean.Random(),
                        SupplierId = GetAnyEntityId(_supplierInMemoryProvider.Entities),
                        IsDFARS = Faker.Boolean.Random(),
                        PrimaryLocation = Faker.Country.Name(),
                        MaterialLogTypeId = GetAnyEntityId(_materialLogTypeInMemoryProvider.Entities),
                        SupplierMaterialGrade = string.Join(" ", Faker.Lorem.Words(3)),
                        MRTNumber = Faker.RandomNumber.Next(100, 999),
                        CreatedBy = Faker.Name.FullName()
                    });
            }
        }

        private void GenerateMaterialLogNotes()
        {
            var count = 100;

            for (var i = 0; i < count; i++)
            {
                var day = Faker.RandomNumber.Next(1, 30);
                var hour = Faker.RandomNumber.Next(1, 23);
                var minute = Faker.RandomNumber.Next(1, 59);
                var second = Faker.RandomNumber.Next(1, 59);

                _materialLogNoteInMemoryProvider.Entities.Add(
                    new MaterialLogNote
                    {
                        Id = _materialLogNoteInMemoryProvider.GenerateEntityId(),
                        MaterialLogId = GetAnyMaterialLogId(_materialLogsInMemoryProvider.Entities),
                        Text = Faker.Lorem.Sentence(3),
                        DateTimeCreated = new DateTime(2020, 11, day, hour, minute, second),
                        CreatedBy = Faker.Name.FullName()
                    });
            }
        }

        private int GetAnyEntityId<TEntity>(List<TEntity> entities)
            where TEntity : IEntity<int>
        {
            var index = Faker.RandomNumber.Next(0, entities.Count - 1);

            return entities[index].Id;
        }

        private string GetAnyMaterialLogId(List<MaterialLog> entities)
        {
            var index = Faker.RandomNumber.Next(0, entities.Count - 1);

            return entities[index].Id;
        }
    }
}