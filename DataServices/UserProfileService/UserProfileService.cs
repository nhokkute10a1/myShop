using DataModel.UserProfileModel;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataServices.UserProfileService
{
    public class UserProfileService
    {
        UnitOfWork.UnitOfWork _ouw = new UnitOfWork.UnitOfWork();

        /*===Thêm mới===*/
        public void Insert(UserProfileModel _params)
        {
            try
            {
                _ouw.UserProfileRepo.ExcQuery("exec sp_UserProfile_Insert " +
                  "@UserProfile_LastName,"+
                  "@UserProfile_FirstName,"+
                  "@UserProfile_FullName,"+
                  "@UserProfile_Birth_Day,"+
                  "@UserProfile_Birth_Month,"+
                  "@UserProfile_Birth_Year,"+
                  "@UserProfile_Age,"+
                  "@UserProfile_Gender,"+
                  "@UserProfile_Phone,"+
                  "@UserProfile_Email,"+
                  "@UserProfile_Pass,"+
                  "@UserProfile_About_Me,"+
                  "@UserProfile_Avatar,"+
                  "@UserProfile_ConnectID,"+
                  "@CreateDate,"+
                  "@UpdateDate,"+
                  "@Lock,"+
                  "@Is_Active"
                  ,
                  new SqlParameter("UserProfile_LastName", SqlDbType.NVarChar)
                  {
                      Value=_params.UserProfile_LastName
                  },
                  new SqlParameter("UserProfile_FirstName", SqlDbType.NVarChar)
                  {
                      Value = _params.UserProfile_FirstName
                  },
                  new SqlParameter("UserProfile_FullName", SqlDbType.NVarChar)
                  {
                      Value = _params.UserProfile_FullName
                  },
                  new SqlParameter("UserProfile_Birth_Day", SqlDbType.Int)
                  {
                      Value = _params.UserProfile_Birth_Day
                  },
                  new SqlParameter("UserProfile_Birth_Month", SqlDbType.Int)
                  {
                      Value = _params.UserProfile_Birth_Month
                  },
                  new SqlParameter("UserProfile_Birth_Year", SqlDbType.Int)
                  {
                      Value = _params.UserProfile_Birth_Year
                  },
                  new SqlParameter("UserProfile_Age", SqlDbType.Int)
                  {
                      Value = _params.UserProfile_Age ??0
                  },
                  new SqlParameter("UserProfile_Gender", SqlDbType.NVarChar)
                  {
                      Value = _params.UserProfile_Gender
                  },
                  new SqlParameter("UserProfile_Phone", SqlDbType.VarChar)
                  {
                      Value = _params.UserProfile_Phone
                  },
                  new SqlParameter("UserProfile_Email", SqlDbType.VarChar)
                  {
                      Value = _params.UserProfile_Email
                  },
                  new SqlParameter("UserProfile_Pass", SqlDbType.VarChar)
                  {
                      Value = _params.UserProfile_Pass
                  },
                  new SqlParameter("UserProfile_About_Me", SqlDbType.NVarChar)
                  {
                      Value = _params.UserProfile_About_Me ?? DBNull.Value.ToString()
                  },
                  new SqlParameter("UserProfile_Avatar", SqlDbType.VarChar)
                  {
                      Value = _params.UserProfile_Avatar ?? DBNull.Value.ToString()
                  },
                  new SqlParameter("UserProfile_ConnectID", SqlDbType.VarChar)
                  {
                      Value = _params.UserProfile_ConnectID ??DBNull.Value.ToString()
                  },
                  new SqlParameter("CreateDate", SqlDbType.Date)
                  {
                      Value = _params.CreateDate ?? DateTime.Now
                  },
                  new SqlParameter("UpdateDate", SqlDbType.Date)
                  {
                      Value = _params.UpdateDate ?? DateTime.Now
                  },
                  new SqlParameter("Lock", SqlDbType.Int)
                  {
                      Value = _params.Lock??0
                  },
                  new SqlParameter("Is_Active", SqlDbType.Bit)
                  {
                      Value = _params.Is_Active==null?true: _params.Is_Active
                  }
                    );
            }
            catch(Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình thêm mới"+ex.Message);
            }
        }

        /*===Cập nhập===*/
        public void Update(UserProfileModel _params)
        {
            try
            {
                _ouw.UserProfileRepo.ExcQuery("exec sp_UserProfile_Update " +
                  "@UserProfile_ID," +
                  "@UserProfile_LastName," +
                  "@UserProfile_FirstName," +
                  "@UserProfile_FullName," +
                  "@UserProfile_Birth_Day," +
                  "@UserProfile_Birth_Month," +
                  "@UserProfile_Birth_Year," +
                  "@UserProfile_Age," +
                  "@UserProfile_Gender," +
                  "@UserProfile_Phone," +
                  "@UserProfile_Email," +
                  "@UserProfile_Pass," +
                  "@UserProfile_About_Me," +
                  "@UserProfile_Avatar," +
                  "@UserProfile_ConnectID," +
                  "@CreateDate," +
                  "@UpdateDate," +
                  "@Lock," +
                  "@Is_Active"
                  ,
                  new SqlParameter("UserProfile_ID", SqlDbType.Int)
                  {
                      Value = _params.UserProfile_ID
                  },
                  new SqlParameter("UserProfile_LastName", SqlDbType.NVarChar)
                  {
                      Value = _params.UserProfile_LastName
                  },
                  new SqlParameter("UserProfile_FirstName", SqlDbType.NVarChar)
                  {
                      Value = _params.UserProfile_FirstName
                  },
                  new SqlParameter("UserProfile_FullName", SqlDbType.NVarChar)
                  {
                      Value = _params.UserProfile_FullName
                  },
                  new SqlParameter("UserProfile_Birth_Day", SqlDbType.Int)
                  {
                      Value = _params.UserProfile_Birth_Day
                  },
                  new SqlParameter("UserProfile_Birth_Month", SqlDbType.Int)
                  {
                      Value = _params.UserProfile_Birth_Month
                  },
                  new SqlParameter("UserProfile_Birth_Year", SqlDbType.Int)
                  {
                      Value = _params.UserProfile_Birth_Year
                  },
                  new SqlParameter("UserProfile_Age", SqlDbType.Int)
                  {
                      Value = _params.UserProfile_Age ?? 0
                  },
                  new SqlParameter("UserProfile_Gender", SqlDbType.NVarChar)
                  {
                      Value = _params.UserProfile_Gender
                  },
                  new SqlParameter("UserProfile_Phone", SqlDbType.VarChar)
                  {
                      Value = _params.UserProfile_Phone
                  },
                  new SqlParameter("UserProfile_Email", SqlDbType.VarChar)
                  {
                      Value = _params.UserProfile_Email
                  },
                  new SqlParameter("UserProfile_Pass", SqlDbType.VarChar)
                  {
                      Value = _params.UserProfile_Pass
                  },
                  new SqlParameter("UserProfile_About_Me", SqlDbType.NVarChar)
                  {
                      Value = _params.UserProfile_About_Me ?? DBNull.Value.ToString()
                  },
                  new SqlParameter("UserProfile_Avatar", SqlDbType.VarChar)
                  {
                      Value = _params.UserProfile_Avatar ?? DBNull.Value.ToString()
                  },
                  new SqlParameter("UserProfile_ConnectID", SqlDbType.VarChar)
                  {
                      Value = _params.UserProfile_ConnectID ?? DBNull.Value.ToString()
                  },
                  new SqlParameter("CreateDate", SqlDbType.Date)
                  {
                      Value = _params.CreateDate ?? DateTime.Now
                  },
                  new SqlParameter("UpdateDate", SqlDbType.Date)
                  {
                      Value = _params.UpdateDate ?? DateTime.Now
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

        /*===Xóa===*/
        public void Delete(UserProfileModel _params)
        {
            try
            {
                _ouw.UserProfileRepo.ExcQuery("exec sp_UserProfile_Delete @UserProfile_ID",
                  new SqlParameter("UserProfile_ID", SqlDbType.Int)
                  {
                      Value = _params.UserProfile_ID
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