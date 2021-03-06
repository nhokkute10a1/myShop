// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.6
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace DbContextPOCO.Entity
{

    // OrderMaster
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public class OrderMaster
    {
        public int OrderMasterId { get; set; } // OrderMaster_ID (Primary key)
        public int UserProfileId { get; set; } // UserProfile_ID
        public int? PaymentId { get; set; } // Payment_ID
        public int? ProviceId { get; set; } // Provice_ID
        public string OrderMasterCode { get; set; } // OrderMaster_Code (length: 50)
        public double? PriceShip { get; set; } // PriceShip
        public double? Vat { get; set; } // VAT
        public double? Total { get; set; } // Total
        public string Note { get; set; } // Note
        public System.DateTime OrderMasterDate { get; set; } // OrderMaster_Date
        public int? OrderMasterStatus { get; set; } // OrderMaster_Status
        public int? Lock { get; set; } // Lock
        public bool? IsActive { get; set; } // Is_Active

        // Reverse navigation

        /// <summary>
        /// Child OrderDetails where [OrderDetail].[OrderMaster_ID] point to this entity (FK_OrderDetail_OrderMaster)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<OrderDetail> OrderDetails { get; set; } // OrderDetail.FK_OrderDetail_OrderMaster

        // Foreign keys

        /// <summary>
        /// Parent UserProfile pointed by [OrderMaster].([UserProfileId]) (FK_OrderMaster_UserProfile)
        /// </summary>
        public virtual UserProfile UserProfile { get; set; } // FK_OrderMaster_UserProfile

        public OrderMaster()
        {
            Total = 0;
            OrderMasterDate = System.DateTime.Now;
            OrderMasterStatus = 0;
            Lock = 0;
            IsActive = true;
            OrderDetails = new System.Collections.Generic.List<OrderDetail>();
        }
    }

}
// </auto-generated>
