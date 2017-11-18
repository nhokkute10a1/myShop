using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.SysFunctionGroupModel
{
    public class SysFunctionGroupModel : BaseModel
    {
        public int SysFunctionGroupId { get; set; } // SysFunctionGroupId (Primary key)
        public string SysFunctionGroupCode { get; set; } // SysFunctionGroupCode (length: 50)
        public string SysFunctionGroupName { get; set; } // SysFunctionGroupName (length: 255)
        public string Descriptions { get; set; } // Descriptions

        public SysFunctionGroupModel()
        {
            Display_Order = 1;
            Is_Active = true;
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }
    }
}
