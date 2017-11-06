using System;

namespace DataModel.AdvertisementModel
{
    public class AdvertisementModel : BaseModel
    {
        public int Advertisement_ID { get; set; } // Advertisement_ID (Primary key)
        public string Advertisement_NameVN { get; set; } // Advertisement_NameVN (length: 50)
        public string Advertisement_NameEN { get; set; } // Advertisement_NameEN (length: 50)
        public string Advertisement_UrlOut { get; set; } // Advertisement_UrlOut (length: 255)
        public string Advertisement_Rewrite { get; set; } // Advertisement_Rewrite (length: 255)
        public string Advertisement_SearchVN { get; set; } // Advertisement_SearchVN (length: 50)
        public string Advertisement_SearchEN { get; set; } // Advertisement_SearchEN (length: 50)
        public string Advertisement_ContentVN { get; set; } // Advertisement_ContentVN
        public string Advertisement_ContentEN { get; set; } // Advertisement_ContentEN
        public string Advertisement_DescriptionVN { get; set; } // Advertisement_DescriptionVN
        public string Advertisement_DescriptionEN { get; set; } // Advertisement_DescriptionEN
        public string Advertisement_Img { get; set; } // Advertisement_Img (length: 255)

        public bool? Is_TopPage { get; set; } // Is_TopPage
        public bool? Is_LeftPage { get; set; } // Is_LeftPage
        public bool? Is_RightPage { get; set; } // Is_RightPage
        public bool? Is_BottomPage { get; set; } // Is_BottomPage

        public AdvertisementModel()
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