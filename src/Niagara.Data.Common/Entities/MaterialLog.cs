using System;
using Niagara.Data.Common.Entities.Base;

namespace Niagara.Data.Common.Entities
{
    public class MaterialLog : IEntity<string>
    {
        public string Id { get; set; }

        public bool IsMagnet { get; set; }

        /// <summary>
        ///     If <see cref="IsMagnet" /> true. Magnetic Properties - BHmax. In MGOe.
        /// </summary>
        public float? BHmax { get; set; }

        /// <summary>
        ///     If <see cref="IsMagnet" /> "true". Magnetic Properties - Br. In kG.
        /// </summary>
        public float? Br { get; set; }

        /// <summary>
        ///     If <see cref="IsMagnet" /> true. Magnetic Properties - Hci. In kOe.
        /// </summary>
        public float? Hci { get; set; }

        /// <summary>
        ///     If <see cref="IsMagnet" /> true. Magnetic Properties - Hc. In kOe.
        /// </summary>
        public float? Hc { get; set; }

        /// <summary>
        ///     If <see cref="IsMagnet" /> false. Specifications - Material Complies to.
        /// </summary>
        public string MaterialCompliesTo { get; set; }

        /// <summary>
        ///     PO #
        /// </summary>
        public string PONumber { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        /// <summary>
        ///     U/M. Id of <see cref="UnitOfMeasure" />.
        /// </summary>
        public int UnitOfMeasureId { get; set; }

        /// <summary>
        ///     Part #. Id of <see cref="PartNumber" />.
        /// </summary>
        public int PartNumberId { get; set; }

        public bool IsAvailable { get; set; }

        /// <summary>
        ///     Supplier. Id of <see cref="Supplier" />.
        /// </summary>
        public int SupplierId { get; set; }

        public bool IsDFARS { get; set; }

        public string PrimaryLocation { get; set; }

        /// <summary>
        ///     If <see cref="IsMagnet" /> true. Dimensions - Shape. Id of <see cref="Shape" />.
        /// </summary>
        public int? ShapeId { get; set; }

        /// <summary>
        ///     If <see cref="IsMagnet" /> true. Dimensions - Dim1.
        /// </summary>
        public float? Dim1 { get; set; }

        /// <summary>
        ///     If <see cref="IsMagnet" /> true. Dimensions - Dim2.
        /// </summary>
        public float? Dim2 { get; set; }

        /// <summary>
        ///     If <see cref="IsMagnet" /> true. Dimensions - DimLm.
        /// </summary>
        public float? DimLm { get; set; }

        /// <summary>
        ///     If <see cref="IsMagnet" /> false. Bars 1.
        /// </summary>
        public int? Bars1 { get; set; }

        /// <summary>
        ///     If <see cref="IsMagnet" /> false. Bars 2.
        /// </summary>
        public int? Bars2 { get; set; }

        /// <summary>
        ///     If <see cref="IsMagnet" /> false. Bars 3.
        /// </summary>
        public int? Bars3 { get; set; }

        /// <summary>
        ///     If <see cref="IsMagnet" /> false. FT 1.
        /// </summary>
        public int? FT1 { get; set; }

        /// <summary>
        ///     If <see cref="IsMagnet" /> false. FT 2.
        /// </summary>
        public int? FT2 { get; set; }

        /// <summary>
        ///     If <see cref="IsMagnet" /> false. FT 3.
        /// </summary>
        public int? FT3 { get; set; }

        /// <summary>
        ///     If <see cref="IsMagnet" /> false. Total FT.
        /// </summary>
        public int? TotalFT { get; set; }

        /// <summary>
        ///     Type. Id of <see cref="MaterialLogType" />.
        /// </summary>
        public int MaterialLogTypeId { get; set; }

        public string SupplierMaterialGrade { get; set; }

        /// <summary>
        ///     MRT #
        /// </summary>
        public int MRTNumber { get; set; }

        public string CreatedBy { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }
    }
}