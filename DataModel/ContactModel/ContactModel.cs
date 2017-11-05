using System;

namespace DataModel.ContactModel
{
    public class ContactModel
    {
        public int Contact_ID { get; set; } // Contact_ID (Primary key)
        public string Contact_Name { get; set; } // Contact_Name (length: 50)
        public string Contact_CellPhone { get; set; } // Contact_CellPhone (length: 50)
        public string Contact_Email { get; set; } // Contact_Email (length: 50)
        public string Contact_Address { get; set; } // Contact_Address
        public DateTime Contact_Date { get; set; } // Contact_Date
        public bool? Is_Active { get; set; } // Is_Active

        public ContactModel()
        {
            Contact_Date = DateTime.Now;
            Is_Active = true;
        }
    }
}