using System;
using Niagara.Data.Common.Entities.Base;
using Niagara.Data.Common.StaticOptions;

namespace Niagara.Data.Common.Entities
{
    public class MaterialLog : IEntity<string>
    {
        public string Id { get; set; }

        public YesOrNoEnum Magnet { get; set; }

        /// <summary>
        /// If <see cref="Magnet"/> "Yes". Magnet Properties - BHmax. In MGOe.
        /// </summary>
        public string BHmax { get; set; }

        /// <summary>
        /// If <see cref="Magnet"/> "Yes". Magnet Properties - Br. In kG.
        /// </summary>
        public string Br { get; set; }

        /// <summary>
        /// If <see cref="Magnet"/> "Yes". Magnet Properties - Hci. In kOe.
        /// </summary>
        public string Hci { get; set; }

        /// <summary>
        /// If <see cref="Magnet"/> "Yes". Magnet Properties - Hc. In kOe.
        /// </summary>
        public string Hc { get; set; }

        /// <summary>
        /// If <see cref="Magnet"/> "No". Specifications - Material Complies to.
        /// </summary>
        public string MaterialCompliesTo { get; set; }

        /// <summary>
        /// PO #
        /// </summary>
        public string PONumber { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        /// <summary>
        /// U/M. Id of <see cref="UnitOfMeasure"/>. 
        /// </summary>
        public int UnitOfMeasureId { get; set; }

        /// <summary>
        /// Part #. Id of <see cref="PartNumber"/>. 
        /// </summary>
        public int PartNumberId { get; set; }

        public YesOrNoEnum Available { get; set; }

        /// <summary>
        /// Supplier. Id of <see cref="Supplier"/>. 
        /// </summary>
        public int SupplierId { get; set; }

        public YesOrNoEnum DFARS { get; set; }

        public string PrimaryLocation { get; set; }

        /// <summary>
        /// If <see cref="Magnet"/> "Yes". Dimensions - Shape. Id of <see cref="Shape"/>. 
        /// </summary>
        public int? ShapeId { get; set; }

        /// <summary>
        /// If <see cref="Magnet"/> "Yes". Dimensions - Dim1.
        /// </summary>
        public float? Dim1 { get; set; }

        /// <summary>
        /// If <see cref="Magnet"/> "Yes". Dimensions - Dim2.
        /// </summary>
        public float? Dim2 { get; set; }

        /// <summary>
        /// If <see cref="Magnet"/> "Yes". Dimensions - DimLm.
        /// </summary>
        public float? DimLm { get; set; }

        /// <summary>
        /// If <see cref="Magnet"/> "No". Bars 1.
        /// </summary>
        public int? Bars1 { get; set; }

        /// <summary>
        /// If <see cref="Magnet"/> "No". Bars 2.
        /// </summary>
        public int? Bars2 { get; set; }

        /// <summary>
        /// If <see cref="Magnet"/> "No". Bars 3.
        /// </summary>
        public int? Bars3 { get; set; }

        /// <summary>
        /// If <see cref="Magnet"/> "No". FT 1.
        /// </summary>
        public int? FT1 { get; set; }

        /// <summary>
        /// If <see cref="Magnet"/> "No". FT 2.
        /// </summary>
        public int? FT2 { get; set; }

        /// <summary>
        /// If <see cref="Magnet"/> "No". FT 3.
        /// </summary>
        public int? FT3 { get; set; }

        /// <summary>
        /// If <see cref="Magnet"/> "No". Total FT.
        /// </summary>
        public int? TotalFT { get; set; }

        /// <summary>
        /// Type. Id of <see cref="MaterialLogType"/>. 
        /// </summary>
        public int MaterialLogTypeId { get; set; }

        public string SupplierMaterialGrade { get; set; }

        /// <summary>
        /// MRT #
        /// </summary>
        public int MRTNumber { get; set; }

        public string CreatedBy { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }
    }
}