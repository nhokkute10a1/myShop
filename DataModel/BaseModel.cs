using System;

namespace DataModel
{
    public class BaseModel
    {
        public string Keyword_Titile { get; set; } // Keyword_Titile (length: 50)
        public string Keyword_Content { get; set; } // Keyword_Content
        public string Keyword_Description { get; set; } // Keyword_Description
        public DateTime? CreateDate { get; set; } // CreateDate
        public int? CreateBy { get; set; } // CreateBy
        public DateTime? UpdateDate { get; set; } // UpdateDate
        public int? UpdateBy { get; set; } // UpdateBy
        public int? Lock { get; set; } // Lock
        public bool? Is_Active { get; set; } // Is_Active
        public bool? Is_HomePage { get; set; } // Is_HomePage
        public bool? Is_TopMenu { get; set; } // Is_TopMenu
        public bool? Is_BottomMenu { get; set; } // Is_BottomMenu
        public int? Display_Order { get; set; } // Display_Order
        public int? Img_Width { get; set; } // Img_Width
        public string Img_Unit_Width { get; set; } // Img_Unit_Width (length: 10)
        public int? Img_Height { get; set; } // Img_Height
        public string Img_Unit_Height { get; set; } // Img_Unit_Height (length: 10

        public int totalCount { get; set; }
        public Double totalPages { get; set; }
    }
}