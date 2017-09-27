using DataModel.RolesModel;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataServices.RolesService
{
    public class RolesService
    {
        UnitOfWork.UnitOfWork _uow = new UnitOfWork.UnitOfWork();

        /*===Thêm mới===*/
        public void Insert(RolesModel _params)
        {
            try
            {
                _uow.RolesRepo.ExcQuery("exec sp_Roles_Insert " +
                  "@Roles_Name,"+
                  "@Is_Active,"+
                  "@Display_Order",
                   new SqlParameter("Roles_Name", SqlDbType.NVarChar)
                   {
                       Value = _params.Roles_Name 
                   },
                   new SqlParameter("Is_Active", SqlDbType.Bit)
                   {
                       Value = _params.Is_Active == null ?true: _params.Is_Active
                   },
                   new SqlParameter("Display_Order", SqlDbType.Int)
                   {
                       Value = _params.Display_Order ??0
                   }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình thêm mới" + ex.Message);
            }
        }

        /*===Cập nhập===*/
        public void Update(RolesModel _params)
        {
            try
            {
                _uow.RolesRepo.ExcQuery("exec sp_Roles_Update " +
                   "@Roles_ID," +
                  "@Roles_Name," +
                  "@Is_Active," +
                  "@Display_Order",
                  new SqlParameter("Roles_ID", SqlDbType.Int)
                  {
                      Value = _params.Roles_ID
                  },
                   new SqlParameter("Roles_Name", SqlDbType.NVarChar)
                   {
                       Value = _params.Roles_Name
                   },
                   new SqlParameter("Is_Active", SqlDbType.Bit)
                   {
                       Value = _params.Is_Active == null ? true : _params.Is_Active
                   },
                   new SqlParameter("Display_Order", SqlDbType.Int)
                   {
                       Value = _params.Display_Order ?? 0
                   }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình cập nhập" + ex.Message);
            }
        }

        /*===Xóa===*/
        public void Delete(RolesModel _params)
        {
            try
            {
                _uow.RolesRepo.ExcQuery("exec sp_Roles_Delete @Roles_ID" ,
                  new SqlParameter("Roles_ID", SqlDbType.Int)
                  {
                      Value = _params.Roles_ID
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