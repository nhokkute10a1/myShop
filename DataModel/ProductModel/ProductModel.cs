using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.ProductModel
{
    public class ProductModel :BaseModel
    {
        public int Product_ID { get; set; } // Product_ID (Primary key)
        public string Product_Code { get; set; } // Product_Code (length: 50)
        public int Category_Parent_ID { get; set; } // Category_Parent_ID
        public int? Currency_ID { get; set; } // Currency_ID
        public string Product_NameVN { get; set; } // Product_NameVN (length: 50)
        public string Product_NameEN { get; set; } // Product_NameEN (length: 50)
        public string Product_UrlOut { get; set; } // Product_UrlOut (length: 255)
        public string Product_Rewrite { get; set; } // Product_Rewrite (length: 255)
        public string Product_SearchVN { get; set; } // Product_SearchVN (length: 50)
        public string Product_SearchEN { get; set; } // Product_SearchEN (length: 50)
        public string Product_ContentVN { get; set; } // Product_ContentVN
        public string Product_ContentEN { get; set; } // Product_ContentEN
        public string Product_DescriptionVN { get; set; } // Product_DescriptionVN
        public string Product_DescriptionEN { get; set; } // Product_DescriptionEN
        public double? Product_Price { get; set; } // Product_Price
        public double? Product_Discount { get; set; } // Product_Discount
        public string Product_Img { get; set; } // Product_Img (length: 255)
      
        public int? Product_View { get; set; } // Product_View
        public string Category_NameVN { get; set; }
        public string ImageBase64 { get; set; }
        public ProductModel()
        {
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            Product_View = 0;
            Lock = 0;
            Is_Active = true;
            Is_HomePage = true;
            Is_TopMenu = false;
            Is_BottomMenu = true;
            Display_Order = 1;
        }

    }
}
