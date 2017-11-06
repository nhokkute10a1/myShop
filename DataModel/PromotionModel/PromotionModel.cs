using System;

namespace DataModel.PromotionModel
{
    public class PromotionModel : BaseModel
    {
        public int Promotion_ID { get; set; } // Promotion_ID (Primary key)
        public string Promotion_NameVN { get; set; } // Promotion_NameVN (length: 50)
        public string Promotion_NameEN { get; set; } // Promotion_NameEN (length: 50)
        public string Promotion_UrlOut { get; set; } // Promotion_UrlOut (length: 255)
        public string Promotion_Rewrite { get; set; } // Promotion_Rewrite (length: 255)
        public string Promotion_SearchVN { get; set; } // Promotion_SearchVN (length: 50)
        public string Promotion_SearchEN { get; set; } // Promotion_SearchEN (length: 50)
        public string Promotion_ContentVN { get; set; } // Promotion_ContentVN
        public string Promotion_ContentEN { get; set; } // Promotion_ContentEN
        public string Promotion_DescriptionVN { get; set; } // Promotion_DescriptionVN
        public string Promotion_DescriptionEN { get; set; } // Promotion_DescriptionEN
        public string Promotion_Img { get; set; } // Promotion_Img (length: 255)
        public bool? Is_LeftPage { get; set; } // Is_LeftPage
        public bool? Is_RightPage { get; set; } // Is_RightPage

        public PromotionModel()
        {
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            Lock = 0;
            Is_Active = true;
            Is_LeftPage = false;
            Is_RightPage = false;
            Display_Order = 1;
        }
    }
}