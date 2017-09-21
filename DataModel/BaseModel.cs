using System;

namespace DataModel
{
    public class BaseModel
    {
        public string KeywordTitile { get; set; } // Keyword_Titile (length: 50)
        public string KeywordContent { get; set; } // Keyword_Content
        public string KeywordDescription { get; set; } // Keyword_Description
        public DateTime? CreateDate { get; set; } // CreateDate
        public int? CreateBy { get; set; } // CreateBy
        public DateTime? UpdateDate { get; set; } // UpdateDate
        public int? UpdateBy { get; set; } // UpdateBy
        public int? Lock { get; set; } // Lock
        public bool? Is_Active { get; set; } // Is_Active
        public bool? IsHomePage { get; set; } // Is_HomePage
        public bool? IsTopMenu { get; set; } // Is_TopMenu
        public bool? IsBottomMenu { get; set; } // Is_BottomMenu
        public int? Display_Order { get; set; } // Display_Order
    }
}