using System;

namespace DataModel.OrderMasterModel
{
    public class OrderMasterModel: BaseModel
    {
        public int OrderMaster_ID { get; set; } // OrderMaster_ID (Primary key)
        public int UserProfile_ID { get; set; } // UserProfile_ID
        public int? Payment_ID { get; set; } // Payment_ID
        public int? Provice_ID { get; set; } // Provice_ID
        public string OrderMaster_Code { get; set; } // OrderMaster_Code (length: 50)
        public double? PriceShip { get; set; } // PriceShip
        public double? VAT { get; set; } // VAT
        public double? Total { get; set; } // Total
        public string Note { get; set; } // Note
        public DateTime OrderMaster_Date { get; set; } // OrderMaster_Date
        public int? OrderMaster_Status { get; set; } // OrderMaster_Status 

        public OrderMasterModel()
        {
            Total = 0;
            OrderMaster_Date = DateTime.Now;
            OrderMaster_Status = 0;
            Lock = 0;
            Is_Active = true;
        }
    }
}