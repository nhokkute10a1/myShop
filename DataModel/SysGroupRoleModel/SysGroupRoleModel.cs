using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.SysGroupRoleModel
{
    public class SysGroupRoleModel:BaseModel
    {
        public int GroupRolesId { get; set; } // GroupRolesId (Primary key)
        public string GroupRolesCode { get; set; } // GroupRolesICode (length: 50)
        public string GroupRolesName { get; set; } // GroupRolesIName (length: 50)

       public SysGroupRoleModel()
        {
            Display_Order = 1;
            Is_Active = true;
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }
    }
}
