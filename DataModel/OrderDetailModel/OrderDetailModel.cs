using System;

namespace DataModel.OrderDetailModel
{
    public class OrderDetailModel:BaseModel
    {
        public int OrderDetail_ID { get; set; } // OrderDetail_ID (Primary key)
        public int OrderMaster_ID { get; set; } // OrderMaster_ID
        public int Product_ID { get; set; } // Product_ID
        public int? Quanlity { get; set; } // Quanlity
        public double Amout { get; set; } // Amout
        public DateTime OrderDetail_Date { get; set; } // OrderDetail_Date
        public int? OrderDetail_Status { get; set; } // OrderDetail_Status

        public OrderDetailModel()
        {
            OrderDetail_Date = DateTime.Now;
            OrderDetail_Status = 0;
            Lock = 0;
            Is_Active = true;
        }
    }
}