namespace DataModel.UserRolesModel
{
    public class UserRolesModel:BaseModel
    {
        public int UserRoles_ID { get; set; } // UserRoles_ID (Primary key)
        public int? Roles_ID { get; set; } // Roles_ID
        public int? UserProfile_ID { get; set; } // UserProfile_ID

        public UserRolesModel()
        {
            Is_Active = false;
            Display_Order = 1;
        }
    }
}