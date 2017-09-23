using System;

namespace DataModel.CategoryModel
{
    public class CategoryModel : BaseModel
    {
        public int Category_ID { get; set; } // Category_ID (Primary key)
        public int? Category_Parent_ID { get; set; } // Category_Parent_ID
        public string Category_NameVN { get; set; } // Category_NameVN (length: 50)
        public string Category_NameEN { get; set; } // Category_NameEN (length: 50)
        public string Category_UrlOut { get; set; } // Category_UrlOut (length: 255)
        public string Category_Rewrite { get; set; } // Category_Rewrite (length: 255)
        public string Category_SearchVN { get; set; } // Category_SearchVN (length: 50)
        public string Category_SearchEN { get; set; } // Category_SearchEN (length: 50)
        public string Category_Icon { get; set; } // Category_Icon (length: 255)
        public string Category_Img { get; set; } // Category_Img (length: 255)

        public CategoryModel()
        {
            Category_Parent_ID = 0;
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            Lock = 0;
            Is_Active = true;
            Is_HomePage = true;
            Is_TopMenu = false;
            Is_BottomMenu = true;
            Display_Order = 1;
        }
    }
}