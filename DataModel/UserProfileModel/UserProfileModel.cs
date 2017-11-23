using System;

namespace DataModel.UserProfileModel
{
    public class UserProfileModel:BaseModel
    {
        public int UserProfile_ID { get; set; } // UserProfile_ID (Primary key)
        public string UserProfile_LastName { get; set; } // UserProfile_LastName (length: 50)
        public string UserProfile_FirstName { get; set; } // UserProfile_FirstName (length: 50)
        public string UserProfile_FullName { get; set; } // UserProfile_FullName (length: 255)
        public System.DateTime? UserProfile_BirthDay { get; set; } // UserProfile_BirthDay
        public int? UserProfile_Age { get; set; } // UserProfile_Age
        public int? UserProfile_Gender { get; set; } // UserProfile_Gender (length: 10)
        public string UserProfile_Phone { get; set; } // UserProfile_Phone (length: 20)
        public string UserProfile_Email { get; set; } // UserProfile_Email (length: 50)
        public string UserProfile_Pass { get; set; } // UserProfile_Pass (length: 50)
        public string UserProfile_About_Me { get; set; } // UserProfile_About_Me
        public string UserProfile_Avatar { get; set; } // UserProfile_Avatar (length: 500)
        public string UserProfile_ConnectID { get; set; } // UserProfile_ConnectID
        public string ImageBase64 { get; set; }
        public int Msg { get; set; }

        public UserProfileModel()
        {
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            Lock = 0;
            Is_Active = true;
        }
    }
}