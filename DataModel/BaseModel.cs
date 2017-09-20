using System;

namespace DataModel
{
    public class BaseModel
    {
        public DateTime CreateDate { set; get; }
        public int CreateBy { set; get; }
        public DateTime UpdateDate { set; get; }
        public int UpdateBy { set; get; }
        public bool Is_Active { set; get; }
        public int Display_Order { set; get; }
    }
}
