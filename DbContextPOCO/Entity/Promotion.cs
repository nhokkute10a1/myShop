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

    // Promotion
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public class Promotion
    {
        public int PromotionId { get; set; } // Promotion_ID (Primary key)
        public string PromotionNameVn { get; set; } // Promotion_NameVN (length: 50)
        public string PromotionNameEn { get; set; } // Promotion_NameEN (length: 50)
        public string PromotionUrlOut { get; set; } // Promotion_UrlOut (length: 255)
        public string PromotionRewrite { get; set; } // Promotion_Rewrite (length: 255)
        public string PromotionSearchVn { get; set; } // Promotion_SearchVN (length: 50)
        public string PromotionSearchEn { get; set; } // Promotion_SearchEN (length: 50)
        public string PromotionContentVn { get; set; } // Promotion_ContentVN
        public string PromotionContentEn { get; set; } // Promotion_ContentEN
        public string PromotionDescriptionVn { get; set; } // Promotion_DescriptionVN
        public string PromotionDescriptionEn { get; set; } // Promotion_DescriptionEN
        public string PromotionImg { get; set; } // Promotion_Img
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
        public int? Lock { get; set; } // Lock
        public bool? IsActive { get; set; } // Is_Active
        public bool? IsLeftPage { get; set; } // Is_LeftPage
        public bool? IsRightPage { get; set; } // Is_RightPage
        public int? DisplayOrder { get; set; } // Display_Order

        public Promotion()
        {
            CreateDate = System.DateTime.Now;
            UpdateDate = System.DateTime.Now;
            Lock = 0;
            IsActive = true;
            IsLeftPage = false;
            IsRightPage = false;
            DisplayOrder = 1;
        }
    }

}
// </auto-generated>
