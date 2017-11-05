using DataModel.OrderDetailModel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataServices.OrderDetailService
{
    public class OrderDetailService
    {
        UnitOfWork.UnitOfWork _ouw = new UnitOfWork.UnitOfWork();

        /*===Thêm mới===*/
       public void Insert(OrderDetailModel _params)
        {
            try
            {
                _ouw.OrderDetailRepo.ExcQuery("exec sp_OrderDetail_Insert " +
                  "@OrderMaster_ID,"+
                  "@Product_ID,"+
                  "@Quanlity,"+
                  "@Amout,"+
                  "@OrderDetail_Date,"+
                  "@OrderDetail_Status,"+
                  "@Lock,"+
                  "@Is_Active",
                  new SqlParameter("OrderMaster_ID", SqlDbType.Int)
                  {
                      Value=_params.OrderMaster_ID
                  },
                  new SqlParameter("Product_ID", SqlDbType.Int)
                  {
                      Value = _params.Product_ID
                  },
                  new SqlParameter("Quanlity", SqlDbType.Int)
                  {
                      Value = _params.Quanlity ??0 
                  },
                  new SqlParameter("Amout", SqlDbType.Float)
                  {
                      Value = _params.Amout 
                  },
                  new SqlParameter("OrderDetail_Date", SqlDbType.Date)
                  {
                      Value = _params.OrderDetail_Date == null ? DateTime.Now : _params.OrderDetail_Date
                  },
                  new SqlParameter("OrderDetail_Status", SqlDbType.Int)
                  {
                      Value = _params.OrderDetail_Status == null ? 0 : 1
                  },
                  new SqlParameter("Lock", SqlDbType.Int)
                  {
                      Value = _params.Lock ??0
                  },
                  new SqlParameter("Is_Active", SqlDbType.Bit)
                  {
                      Value = _params.Is_Active == null ? true : _params.Is_Active
                  }
                    );
            }
            catch(Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình thêm mới" + ex.Message);
            }
        }

        /*===Xóa===*/
        public void Delete(OrderDetailModel _params)
        {
            try
            {
                _ouw.OrderDetailRepo.ExcQuery("exec sp_OrderDetail_Delete @OrderDetail_ID",
                  new SqlParameter("OrderDetail_ID", SqlDbType.Int)
                  {
                      Value = _params.OrderDetail_ID
                  }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình Xóa" + ex.Message);
            }
        }
    }
}