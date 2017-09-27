using DataModel;

namespace DataModel.RolesModel
{
    public class RolesModel : BaseModel
    {
        public int Roles_ID { get; set; } // Roles_ID (Primary key)
        public string Roles_Name { get; set; } // Roles_Name (length: 20)

        public RolesModel()
        {
            Is_Active = true;
            Display_Order = 1;
        }
    }
}