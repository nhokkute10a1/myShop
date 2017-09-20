using System;

namespace DataModel
{
    public class CategoryModel : BaseModel
    {
        //step 2

        public int Category_ID { set; get; }
        public int Category_Parent_ID { set; get; }
        public string Category_NameVN { set; get; }
        public string Category_NameEN { set; get; }
        public string Category_UrlOut { set; get; }
        public string Category_Rewrite { set; get; }
        public string Category_SearchVN { set; get; }
        public string Category_SearchEN { set; get; }
        public string Category_Icon { set; get; }
        public string Category_Img { set; get; }
        public string Keyword_Titile { set; get; }
        public string Keyword_Content { set; get; }
        public string Keyword_Description { set; get; }
        public int Lock { set; get; }
        public bool Is_HomePage { set; get; }
        public bool Is_TopMenu { set; get; }
        public bool Is_BottomMenu { set; get; }
        public CategoryModel()
        {
            CreateDate = DateTime.Now;
            CreateBy = 0;
            UpdateDate = DateTime.Now;
            UpdateBy = 0;
            Display_Order = 1;
        }
    }
    public class CategoryModelAdd
    {
        //step 2
        public int Category_Parent_ID { set; get; }
        public string Category_NameVN { set; get; }
        public string Category_NameEN { set; get; }
        public string Category_UrlOut { set; get; }
        public string Category_Rewrite { set; get; }
        public string Category_SearchVN { set; get; }
        public string Category_SearchEN { set; get; }
        public string Category_Icon { set; get; }
        public string Category_Img { set; get; }
        public string Keyword_Titile { set; get; }
        public string Keyword_Content { set; get; }
        public string Keyword_Description { set; get; }
        public int Lock { set; get; }
        public bool Is_HomePage { set; get; }
        public bool Is_TopMenu { set; get; }
        public bool Is_BottomMenu { set; get; }

        public DateTime CreateDate { set; get; }
        public int CreateBy { set; get; }
        public DateTime UpdateDate { set; get; }
        public int UpdateBy { set; get; }
        public bool Is_Active { set; get; }
        public int Display_Order { set; get; }
        public CategoryModelAdd()
        {
            CreateDate = DateTime.Now;
            CreateBy = 0;
            UpdateDate = DateTime.Now;
            UpdateBy = 0;
            Display_Order = 1;
        }
    }
}
