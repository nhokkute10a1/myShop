using DataModel.UserRolesModel;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataServices.UserRolesService
{
    public class UserRolesService
    {
        UnitOfWork.UnitOfWork _uow = new UnitOfWork.UnitOfWork();

        /*===Thêm mới===*/
        public void Insert(UserRolesModel _params)
        {
            try
            {
                _uow.RolesRepo.ExcQuery("exec sp_UserRoles_Insert " +
                  "@Roles_ID,"+
                  "@UserProfile_ID,"+
                  "@Is_Active,"+
                  "@Display_Order",
                   new SqlParameter("Roles_ID", SqlDbType.Int)
                   {
                       Value = _params.Roles_ID
                   },
                   new SqlParameter("UserProfile_ID", SqlDbType.Int)
                   {
                       Value = _params.UserProfile_ID 
                   },
                   new SqlParameter("Is_Active", SqlDbType.Bit)
                   {
                       Value = _params.Is_Active == null ? false : _params.Is_Active
                   },
                   new SqlParameter("Display_Order", SqlDbType.Int)
                   {
                       Value = _params.Display_Order ?? 0
                   }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình thêm mới" + ex.Message);
            }
        }

        /*===Cập nhập===*/
        public void Update(UserRolesModel _params)
        {
            try
            {
                _uow.RolesRepo.ExcQuery("exec sp_UserRoles_Update " +
                  "@UserRoles_ID," +
                  "@Roles_ID," +
                  "@UserProfile_ID," +
                  "@Is_Active," +
                  "@Display_Order",
                  new SqlParameter("UserRoles_ID", SqlDbType.Int)
                  {
                      Value = _params.UserRoles_ID
                  },
                   new SqlParameter("Roles_ID", SqlDbType.Int)
                   {
                       Value = _params.Roles_ID
                   },
                   new SqlParameter("UserProfile_ID", SqlDbType.Int)
                   {
                       Value = _params.UserProfile_ID
                   },
                   new SqlParameter("Is_Active", SqlDbType.Bit)
                   {
                       Value = _params.Is_Active == null ? false : _params.Is_Active
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
        public void Delete(UserRolesModel _params)
        {
            try
            {
                _uow.RolesRepo.ExcQuery("exec sp_UserRoles_Delete @UserRoles_ID" ,
                  new SqlParameter("UserRoles_ID", SqlDbType.Int)
                  {
                      Value = _params.UserRoles_ID
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