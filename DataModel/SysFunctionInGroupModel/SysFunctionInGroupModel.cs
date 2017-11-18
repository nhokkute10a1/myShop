using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.SysFunctionInGroupModel
{
    public class SysFunctionInGroupModel:BaseModel
    {
        public int SysFunctionInGroupId { get; set; } // SysFunctionInGroupId (Primary key)
        public int? GroupRolesId { get; set; } // GroupRolesId
        public int? FuctionId { get; set; } // FuctionId
        public string Descriptions { get; set; } // Descriptions
        public string SysFunctionInGroupCode { get; set; } // SysFunctionInGroupCode (length: 50)
        public string SysFunctionInGroupName { get; set; } // SysFunctionInGroupName (length: 10)

        public SysFunctionInGroupModel()
        {
            Display_Order = 1;
            Is_Active = true;
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }
    }
}
