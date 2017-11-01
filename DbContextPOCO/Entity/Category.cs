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

    // Category
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public class Category
    {
        public int CategoryId { get; set; } // Category_ID (Primary key)
        public int CategoryParentId { get; set; } // Category_Parent_ID
        public string CategoryNameVn { get; set; } // Category_NameVN (length: 50)
        public string CategoryNameEn { get; set; } // Category_NameEN (length: 50)
        public string CategoryUrlOut { get; set; } // Category_UrlOut (length: 255)
        public string CategoryRewrite { get; set; } // Category_Rewrite (length: 255)
        public string CategorySearchVn { get; set; } // Category_SearchVN (length: 50)
        public string CategorySearchEn { get; set; } // Category_SearchEN (length: 50)
        public string CategoryIcon { get; set; } // Category_Icon
        public string CategoryImg { get; set; } // Category_Img
        public string KeywordTitile { get; set; } // Keyword_Titile (length: 50)
        public string KeywordContent { get; set; } // Keyword_Content
        public string KeywordDescription { get; set; } // Keyword_Description
        public System.DateTime? CreateDate { get; set; } // CreateDate
        public int? CreateBy { get; set; } // CreateBy
        public System.DateTime? UpdateDate { get; set; } // UpdateDate
        public int? UpdateBy { get; set; } // UpdateBy
        public int? Lock { get; set; } // Lock
        public bool? IsActive { get; set; } // Is_Active
        public bool? IsHomePage { get; set; } // Is_HomePage
        public bool? IsTopMenu { get; set; } // Is_TopMenu
        public bool? IsBottomMenu { get; set; } // Is_BottomMenu
        public int? DisplayOrder { get; set; } // Display_Order

        // Reverse navigation

        /// <summary>
        /// Child Products where [Product].[Category_Parent_ID] point to this entity (FK_Product_Category)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<Product> Products { get; set; } // Product.FK_Product_Category

        public Category()
        {
            CreateDate = System.DateTime.Now;
            UpdateDate = System.DateTime.Now;
            Lock = 0;
            IsActive = true;
            IsHomePage = true;
            IsTopMenu = false;
            IsBottomMenu = true;
            DisplayOrder = 1;
            Products = new System.Collections.Generic.List<Product>();
        }
    }

}
// </auto-generated>
