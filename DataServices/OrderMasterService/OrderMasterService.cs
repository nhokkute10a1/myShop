using DataModel.OrderMasterModel;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataServices.OrderMasterService
{
    public class OrderMasterService
    {
        UnitOfWork.UnitOfWork _ouw = new UnitOfWork.UnitOfWork();

        /*===Thêm mới OrderMaster===*/
        public void Insert(OrderMasterModel _params)
        {
            try
            {
                _ouw.OrderMasterRepo.ExcQuery("exec sp_OrderMaster_Insert " +
                  "@UserProfile_ID," +
                  "@Payment_ID," +
                  "@Provice_ID," +
                  "@OrderMaster_Code," +
                  "@PriceShip," +
                  "@VAT," +
                  "@Total," +
                  "@Note," +
                  "@OrderMaster_Date," +
                  "@OrderMaster_Status," +
                  "@Lock," +
                  "@Is_Active"
                  ,
                  new SqlParameter("UserProfile_ID", SqlDbType.Int)
                  {
                      Value = _params.UserProfile_ID
                  },
                  new SqlParameter("Payment_ID", SqlDbType.Int)
                  {
                      Value = _params.Payment_ID ?? 0
                  },
                  new SqlParameter("Provice_ID", SqlDbType.Int)
                  {
                      Value = _params.Provice_ID ?? 0
                  },
                  new SqlParameter("OrderMaster_Code", SqlDbType.VarChar, (50))
                  {
                      Value = _params.OrderMaster_Code
                  },
                  new SqlParameter("PriceShip", SqlDbType.Float)
                  {
                      Value = _params.PriceShip == null ? 0 : _params.PriceShip
                  },
                   new SqlParameter("VAT", SqlDbType.Float)
                   {
                       Value = _params.VAT == null ? 0 : _params.VAT
                   },
                  new SqlParameter("Total", SqlDbType.Float)
                  {
                      Value = _params.Total == null ? 0 : _params.Total
                  },
                  new SqlParameter("Note", SqlDbType.NVarChar)
                  {
                      Value = _params.Note ?? DBNull.Value.ToString()
                  },
                  new SqlParameter("OrderMaster_Date", SqlDbType.Date)
                  {
                      Value = _params.OrderMaster_Date == null ? DateTime.Now : _params.OrderMaster_Date
                  },
                  new SqlParameter("OrderMaster_Status", SqlDbType.Int)
                  {
                      Value = _params.OrderMaster_Status == null ? 0 : 1
                  },
                  new SqlParameter("Lock", SqlDbType.Int)
                  {
                      Value = _params.Lock ?? 0
                  },
                  new SqlParameter("Is_Active", SqlDbType.Bit)
                  {
                      Value = _params.Is_Active == null ? true : _params.Is_Active
                  }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình thêm mới" + ex.Message);
            }
        }

        /*===Cập nhập OrderMaster===*/
        public void Update(OrderMasterModel _params)
        {
            try
            {
                _ouw.OrderMasterRepo.ExcQuery("exec sp_OrderMaster_Update " +
                  "@OrderMaster_ID," +
                  "@UserProfile_ID," +
                  "@Payment_ID," +
                  "@Provice_ID," +
                  "@OrderMaster_Code," +
                  "@PriceShip," +
                  "@VAT," +
                  "@Total," +
                  "@Note," +
                  "@OrderMaster_Date," +
                  "@OrderMaster_Status," +
                  "@Lock," +
                  "@Is_Active"
                  ,
                  new SqlParameter("OrderMaster_ID", SqlDbType.Int)
                  {
                      Value = _params.OrderMaster_ID
                  },
                  new SqlParameter("UserProfile_ID", SqlDbType.Int)
                  {
                      Value = _params.UserProfile_ID
                  },
                  new SqlParameter("Payment_ID", SqlDbType.Int)
                  {
                      Value = _params.Payment_ID ?? 0
                  },
                  new SqlParameter("Provice_ID", SqlDbType.Int)
                  {
                      Value = _params.Provice_ID ?? 0
                  },
                  new SqlParameter("OrderMaster_Code", SqlDbType.VarChar, (50))
                  {
                      Value = _params.OrderMaster_Code
                  },
                  new SqlParameter("PriceShip", SqlDbType.Float)
                  {
                      Value = _params.PriceShip == null ? 0 : _params.PriceShip
                  },
                   new SqlParameter("VAT", SqlDbType.Float)
                   {
                       Value = _params.VAT == null ? 0 : _params.VAT
                   },
                  new SqlParameter("Total", SqlDbType.Float)
                  {
                      Value = _params.Total == null ? 0 : _params.Total
                  },
                  new SqlParameter("Note", SqlDbType.NVarChar)
                  {
                      Value = _params.Note ?? DBNull.Value.ToString()
                  },
                  new SqlParameter("OrderMaster_Date", SqlDbType.Date)
                  {
                      Value = _params.OrderMaster_Date == null ? DateTime.Now : _params.OrderMaster_Date
                  },
                  new SqlParameter("OrderMaster_Status", SqlDbType.Int)
                  {
                      Value = _params.OrderMaster_Status == null ? 0 : 1
                  },
                  new SqlParameter("Lock", SqlDbType.Int)
                  {
                      Value = _params.Lock ?? 0
                  },
                  new SqlParameter("Is_Active", SqlDbType.Bit)
                  {
                      Value = _params.Is_Active == null ? true : _params.Is_Active
                  }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình cập nhập" + ex.Message);
            }
        }

        /*===Xóa OrderMaster===*/
        public void Delete(OrderMasterModel _params)
        {
            try
            {
                _ouw.OrderMasterRepo.ExcQuery("exec sp_OrderMaster_Delete  @OrderMaster_ID" ,                
                  new SqlParameter("OrderMaster_ID", SqlDbType.Int)
                  {
                      Value = _params.OrderMaster_ID
                  }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xóa" + ex.Message);
            }
        }
    }
}