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

        public string GroupRolesName { get; set; } // GroupRolesIName (length: 50)
        public string UserProfile_Email { get; set; } // UserProfile_Email (length: 50)

        public SysUserInGroupModel()
        {
            Display_Order = 1;
            Is_Active = true;
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }
    }
    public class CheckPermissionModel
    {
        public int SysUserInGroupId { get; set; }
        public int? GroupRolesId { get; set; }
        public bool? ButtonId { get; set; }
        public int? UsersId { get; set; }
        public string FunctionCode { get; set; }
        public string FunctionName { get; set; }
    }
}
