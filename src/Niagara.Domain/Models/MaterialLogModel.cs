namespace Niagara.Domain.Models
{
    public class MaterialLogReducedModel
    {
        public string LotNumber { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public string DateCreated { get; set; }
    }

    public class MaterialLogModel
    {
        public MaterialLogModel()
        {
            DefaultProperties = new MaterialLogDefaultPropertiesModel();
            MagneticProperties = new MaterialLogMagneticPropertiesModel();
            Dimensions = new MaterialLogDimensionsModel();
            Specifications = new MaterialLogSpecificationsModel();
            Bars = new MaterialLogBarsModel();
        }

        public MaterialLogDefaultPropertiesModel DefaultProperties { get; set; }

        public bool IsMagnet { get; set; }

        public MaterialLogMagneticPropertiesModel MagneticProperties { get; set; }

        public MaterialLogDimensionsModel Dimensions { get; set; }

        public MaterialLogSpecificationsModel Specifications { get; set; }

        public MaterialLogBarsModel Bars { get; set; }
    }

    public class MaterialLogDefaultPropertiesModel
    {
        public string LotNumber { get; set; }

        /// <summary>
        ///     PO #
        /// </summary>
        public string PONumber { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        /// <summary>
        ///     U/M.
        /// </summary>
        public int UnitOfMeasureId { get; set; }

        /// <summary>
        ///     Part #.
        /// </summary>
        public int PartNumberId { get; set; }

        public bool IsAvailable { get; set; }

        /// <summary>
        ///     Supplier.
        /// </summary>
        public int SupplierId { get; set; }

        public bool IsDFARS { get; set; }

        public string PrimaryLocation { get; set; }

        /// <summary>
        ///     Type.
        /// </summary>
        public int MaterialLogTypeId { get; set; }

        public string SupplierMaterialGrade { get; set; }

        /// <summary>
        ///     MRT #
        /// </summary>
        public int MRTNumber { get; set; }

        public string CreatedBy { get; set; }

        public string DateCreated { get; set; }

        public string DateUpdated { get; set; }
    }

    public class MaterialLogMagneticPropertiesModel
    {
        /// <summary>
        ///     Magnetic Properties - BHmax. In MGOe.
        /// </summary>
        public float? BHmax { get; set; }

        /// <summary>
        ///     Magnetic Properties - Br. In kG.
        /// </summary>
        public float? Br { get; set; }

        /// <summary>
        ///     Magnetic Properties - Hci. In kOe.
        /// </summary>
        public float? Hci { get; set; }

        /// <summary>
        ///     Magnetic Properties - Hc. In kOe.
        /// </summary>
        public float? Hc { get; set; }
    }

    public class MaterialLogDimensionsModel
    {
        /// <summary>
        ///     Dimensions - Shape.
        /// </summary>
        public int? ShapeId { get; set; }

        /// <summary>
        ///     Dimensions - Dim1.
        /// </summary>
        public float? Dim1 { get; set; }

        /// <summary>
        ///     Dimensions - Dim2.
        /// </summary>
        public float? Dim2 { get; set; }

        /// <summary>
        ///     Dimensions - DimLm.
        /// </summary>
        public float? DimLm { get; set; }
    }

    public class MaterialLogSpecificationsModel
    {
        /// <summary>
        ///     Specifications - Material Complies to.
        /// </summary>
        public string MaterialCompliesTo { get; set; }
    }

    public class MaterialLogBarsModel
    {
        /// <summary>
        ///     Bars 1.
        /// </summary>
        public int? Bars1 { get; set; }

        /// <summary>
        ///     Bars 2.
        /// </summary>
        public int? Bars2 { get; set; }

        /// <summary>
        ///     Bars 3.
        /// </summary>
        public int? Bars3 { get; set; }

        /// <summary>
        ///     FT 1.
        /// </summary>
        public int? FT1 { get; set; }

        /// <summary>
        ///     FT 2.
        /// </summary>
        public int? FT2 { get; set; }

        /// <summary>
        ///     FT 3.
        /// </summary>
        public int? FT3 { get; set; }

        /// <summary>
        ///     Total FT.
        /// </summary>
        public int? TotalFT { get; set; }
    }
}