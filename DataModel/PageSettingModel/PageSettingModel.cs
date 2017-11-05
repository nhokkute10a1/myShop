using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.PageSettingModel
{
    public class PageSettingModel : BaseModel
    {
        public int PageSetting_ID { get; set; } // PageSetting_ID (Primary key)
        public string PageSetting_NameVN { get; set; } // PageSetting_NameVN (length: 50)
        public string PageSetting_NameEN { get; set; } // PageSetting_NameEN (length: 50)
        public string PageSetting_UrlOut { get; set; } // PageSetting_UrlOut (length: 255)
        public string PageSetting_Rewrite { get; set; } // PageSetting_Rewrite (length: 255)
        public string PageSetting_SearchVN { get; set; } // PageSetting_SearchVN (length: 50)
        public string PageSetting_SearchEN { get; set; } // PageSetting_SearchEN (length: 50)
        public string PageSetting_Img { get; set; } // PageSetting_Img (length: 255)

        public bool? Is_TopPage { get; set; } // Is_TopPage
        public bool? Is_LeftPage { get; set; } // Is_LeftPage
        public bool? Is_RightPage { get; set; } // Is_RightPage
        public bool? Is_BottomPage { get; set; } // Is_BottomPage
        public string ImageBase64 { get; set; }

        public PageSettingModel()
        {
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            Lock = 0;
            Is_Active = true;
            Is_TopPage = true;
            Is_LeftPage = false;
            Is_RightPage = false;
            Is_BottomPage = true;
            Display_Order = 1;
        }
    }
}
