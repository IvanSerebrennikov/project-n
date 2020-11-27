using System;
using System.Globalization;
using Niagara.Data.Common.Entities;
using Niagara.Data.Common.Projections;
using Niagara.Domain.Helpers;
using Niagara.Domain.Models;

namespace Niagara.Domain.Mapping
{
    public static class MaterialLogMapping
    {
        public static MaterialLogReducedModel ToReducedModel(this MaterialLogProjection projection)
        {
            if (projection == null)
                return null;

            return new MaterialLogReducedModel
            {
                LotNumber = projection.Id,
                Description = projection.Description,
                Quantity = projection.Quantity,
                DateCreated = projection.DateCreated.ToDateString()
            };
        }

        public static MaterialLogModel ToModel(this MaterialLog entity)
        {
            if (entity == null)
                return null;

            return new MaterialLogModel
            {
                DefaultProperties = new MaterialLogDefaultPropertiesModel
                {
                    LotNumber = entity.Id,
                    PONumber = entity.PONumber,
                    Description = entity.Description,
                    Quantity = entity.Quantity,
                    UnitOfMeasureId = entity.UnitOfMeasureId,
                    PartNumberId = entity.PartNumberId,
                    IsAvailable = entity.IsAvailable,
                    SupplierId = entity.SupplierId,
                    IsDFARS = entity.IsDFARS,
                    PrimaryLocation = entity.PrimaryLocation,
                    MaterialLogTypeId = entity.MaterialLogTypeId,
                    SupplierMaterialGrade = entity.SupplierMaterialGrade,
                    MRTNumber = entity.MRTNumber,
                    CreatedBy = entity.CreatedBy,
                    DateCreated = entity.DateCreated.ToDateString(),
                    DateUpdated = entity.DateUpdated?.ToDateString()
                },
                IsMagnet = entity.IsMagnet,
                MagneticProperties = new MaterialLogMagneticPropertiesModel
                {
                    BHmax = entity.BHmax,
                    Br = entity.Br,
                    Hci = entity.Hci,
                    Hc = entity.Hc
                },
                Dimensions = new MaterialLogDimensionsModel
                {
                    ShapeId = entity.ShapeId,
                    Dim1 = entity.Dim1,
                    Dim2 = entity.Dim2,
                    DimLm = entity.DimLm
                },
                Specifications = new MaterialLogSpecificationsModel
                {
                    MaterialCompliesTo = entity.MaterialCompliesTo
                },
                Bars = new MaterialLogBarsModel
                {
                    Bars1 = entity.Bars1,
                    Bars2 = entity.Bars2,
                    Bars3 = entity.Bars3,
                    FT1 = entity.FT1,
                    FT2 = entity.FT2,
                    FT3 = entity.FT3,
                    TotalFT = entity.TotalFT
                }
            };
        }

        public static void MapFromModel(this MaterialLog entity, MaterialLogModel model)
        {
            if (entity != null && model != null)
            {
                entity.PONumber = model.DefaultProperties.PONumber;
                entity.Description = model.DefaultProperties.Description;
                entity.Quantity = model.DefaultProperties.Quantity;
                entity.UnitOfMeasureId = model.DefaultProperties.UnitOfMeasureId;
                entity.PartNumberId = model.DefaultProperties.PartNumberId;
                entity.IsAvailable = model.DefaultProperties.IsAvailable;
                entity.SupplierId = model.DefaultProperties.SupplierId;
                entity.IsDFARS = model.DefaultProperties.IsDFARS;
                entity.PrimaryLocation = model.DefaultProperties.PrimaryLocation;
                entity.MaterialLogTypeId = model.DefaultProperties.MaterialLogTypeId;
                entity.SupplierMaterialGrade = model.DefaultProperties.SupplierMaterialGrade;
                entity.MRTNumber = model.DefaultProperties.MRTNumber;

                entity.IsMagnet = model.IsMagnet;

                if (entity.IsMagnet)
                {
                    entity.BHmax = model.MagneticProperties.BHmax;
                    entity.Br = model.MagneticProperties.Br;
                    entity.Hci = model.MagneticProperties.Hci;
                    entity.Hc = model.MagneticProperties.Hc;

                    entity.ShapeId = model.Dimensions.ShapeId;
                    entity.Dim1 = model.Dimensions.Dim1;
                    entity.Dim2 = model.Dimensions.Dim2;
                    entity.DimLm = model.Dimensions.DimLm;

                    entity.MaterialCompliesTo = null;

                    entity.Bars1 = null;
                    entity.Bars2 = null;
                    entity.Bars3 = null;
                    entity.FT1 = null;
                    entity.FT2 = null;
                    entity.FT3 = null;
                    entity.TotalFT = null;
                }
                else
                {
                    entity.BHmax = null;
                    entity.Br = null;
                    entity.Hci = null;
                    entity.Hc = null;

                    entity.ShapeId = null;
                    entity.Dim1 = null;
                    entity.Dim2 = null;
                    entity.DimLm = null;

                    entity.MaterialCompliesTo = model.Specifications.MaterialCompliesTo;

                    entity.Bars1 = model.Bars.Bars1;
                    entity.Bars2 = model.Bars.Bars2;
                    entity.Bars3 = model.Bars.Bars3;
                    entity.FT1 = model.Bars.FT1;
                    entity.FT2 = model.Bars.FT2;
                    entity.FT3 = model.Bars.FT3;
                    entity.TotalFT = model.Bars.TotalFT;
                }
            }
        }
    }
}