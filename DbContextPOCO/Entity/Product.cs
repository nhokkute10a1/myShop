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

    // Product
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public class Product
    {
        public int ProductId { get; set; } // Product_ID (Primary key)
        public string ProductCode { get; set; } // Product_Code (length: 50)
        public int CategoryParentId { get; set; } // Category_Parent_ID
        public int? CurrencyId { get; set; } // Currency_ID
        public string ProductNameVn { get; set; } // Product_NameVN (length: 50)
        public string ProductNameEn { get; set; } // Product_NameEN (length: 50)
        public string ProductUrlOut { get; set; } // Product_UrlOut (length: 255)
        public string ProductRewrite { get; set; } // Product_Rewrite (length: 255)
        public string ProductSearchVn { get; set; } // Product_SearchVN (length: 50)
        public string ProductSearchEn { get; set; } // Product_SearchEN (length: 50)
        public string ProductContentVn { get; set; } // Product_ContentVN
        public string ProductContentEn { get; set; } // Product_ContentEN
        public string ProductDescriptionVn { get; set; } // Product_DescriptionVN
        public string ProductDescriptionEn { get; set; } // Product_DescriptionEN
        public double? ProductPrice { get; set; } // Product_Price
        public double? ProductDiscount { get; set; } // Product_Discount
        public string ProductImg { get; set; } // Product_Img
        public int? ImgWidth { get; set; } // Img_Width
        public string ImgUnitWidth { get; set; } // Img_Unit_Width (length: 10)
        public int? ImgHeight { get; set; } // Img_Height
        public string ImgUnitHeight { get; set; } // Img_Unit_Height (length: 10)
        public string KeywordTitile { get; set; } // Keyword_Titile (length: 50)
        public string KeywordContent { get; set; } // Keyword_Content
        public string KeywordDescription { get; set; } // Keyword_Description
        public System.DateTime? CreateDate { get; set; } // CreateDate
        public int? CreateBy { get; set; } // CreateBy
        public System.DateTime? UpdateDate { get; set; } // UpdateDate
        public int? UpdateBy { get; set; } // UpdateBy
        public int? ProductView { get; set; } // Product_View
        public int? Lock { get; set; } // Lock
        public bool? IsActive { get; set; } // Is_Active
        public bool? IsHomePage { get; set; } // Is_HomePage
        public bool? IsTopMenu { get; set; } // Is_TopMenu
        public bool? IsBottomMenu { get; set; } // Is_BottomMenu
        public int? DisplayOrder { get; set; } // Display_Order

        // Reverse navigation

        /// <summary>
        /// Child OrderDetails where [OrderDetail].[Product_ID] point to this entity (FK_OrderDetail_Product)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<OrderDetail> OrderDetails { get; set; } // OrderDetail.FK_OrderDetail_Product

        // Foreign keys

        /// <summary>
        /// Parent Category pointed by [Product].([CategoryParentId]) (FK_Product_Category)
        /// </summary>
        public virtual Category Category { get; set; } // FK_Product_Category

        public Product()
        {
            CreateDate = System.DateTime.Now;
            UpdateDate = System.DateTime.Now;
            ProductView = 0;
            Lock = 0;
            IsActive = true;
            IsHomePage = true;
            IsTopMenu = false;
            IsBottomMenu = true;
            DisplayOrder = 0;
            OrderDetails = new System.Collections.Generic.List<OrderDetail>();
        }
    }

}
// </auto-generated>
