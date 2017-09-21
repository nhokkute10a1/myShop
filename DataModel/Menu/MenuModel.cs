namespace DataModel.Menu
{
    public class MenuModel : BaseModel
    {
        public int Menu_ID { get; set; } // Menu_ID (Primary key)
        public int? Parent_ID { get; set; } // Parent_ID
        public string Menu_Name { get; set; } // Menu_Name (length: 50)
        public MenuModel ()
        {
            Parent_ID = 0;
            Display_Order = 1;
            Is_Active = true;
        }
    }
}
