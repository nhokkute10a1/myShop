using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.SysFunctionModel
{
    public class SysFunctionModel :BaseModel
    {
        public int FunctionId { get; set; } // FunctionId (Primary key)
        public int? TreePanelId { get; set; } // TreePanelId
        public int? SysFunctionGroupId { get; set; } // SysFunctionGroupId
        public string FunctionCode { get; set; } // FunctionCode (length: 50)
        public string FunctionName { get; set; } // FunctionName (length: 50)
        public string ButtonId { get; set; } // ButtonId (length: 50)

        public SysFunctionModel()
        {
            Display_Order = 1;
            Is_Active = true;
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }

    }
}
