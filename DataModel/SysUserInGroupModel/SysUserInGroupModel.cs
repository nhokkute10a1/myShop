using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.SysUserInGroupModel
{
    public class SysUserInGroupModel:BaseModel  
    {
        public int SysUserInGroupId { get; set; } // SysUserInGroupId (Primary key)
        public int? GroupRolesId { get; set; } // GroupRolesId
        public int? UserId { get; set; } // UserId
        public string Descriptions { get; set; } // Descriptions

        public SysUserInGroupModel()
        {
            Display_Order = 1;
            Is_Active = true;
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }
    }
}
