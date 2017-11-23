using DataModel.PagingModel;
using DataModel.UserProfileModel;
using LibCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataServices.UserProfileService
{
    public class UserProfileService
    {
        UnitOfWork.UnitOfWork _ouw = new UnitOfWork.UnitOfWork();
        /*==GetAll  ==*/
        public List<UserProfileModel> GetAll(PagingModel _params)
        {
            var data = _ouw.SysFunctionRepo.SQLQuery<UserProfileModel>("exec sp_UserProfile_GetAll " +
                  "@PageNumber," +
                  "@PageSize"
                  ,
                  new SqlParameter("PageNumber", SqlDbType.Int)
                  {
                      Value = _params.PageNumber
                  },
                  new SqlParameter("PageSize", SqlDbType.Int)
                  {
                      Value = _params.PageSize
                  }).ToList();
            return data;
        }

        /*==GetAllById  ==*/
        public UserProfileModel GetById(UserProfileModel _params)
        {
            var data = _ouw.SysFunctionRepo.SQLQuery<UserProfileModel>("sp_UserProfile_GetById "
                + "@UserProfile_ID",
                new SqlParameter("UserProfile_ID", SqlDbType.Int)
                {
                    Value = _params.UserProfile_ID
                }).FirstOrDefault();
            return data;
        }
        /*===Thêm mới===*/
        public void Insert(UserProfileModel _params)
        {
            try
            {
                _ouw.UserProfileRepo.ExcQuery("exec sp_UserProfile_Insert " +
                  "@UserProfile_LastName,"+
                  "@UserProfile_FirstName,"+
                  "@UserProfile_FullName,"+
                  "@UserProfile_BirthDay," +
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
                  new SqlParameter("UserProfile_BirthDay", SqlDbType.Date)
                  {
                      Value = _params.UserProfile_BirthDay == null ? DateTime.Now : _params.UserProfile_BirthDay
                  },
                  new SqlParameter("UserProfile_Age", SqlDbType.Int)
                  {
                      Value = _params.UserProfile_Age ??0
                  },
                  new SqlParameter("UserProfile_Gender", SqlDbType.Int)
                  {
                      Value = _params.UserProfile_Gender ?? 1
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
                  "@UserProfile_BirthDay," +
                  "@UserProfile_Age," +
                  "@UserProfile_Gender," +
                  "@UserProfile_Phone," +
                  "@UserProfile_Email," +
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
                      Value = _params.UserProfile_FullName == null 
                      ? _params.UserProfile_LastName +' ' + _params.UserProfile_FirstName : _params.UserProfile_FullName
                  },
                  new SqlParameter("UserProfile_BirthDay", SqlDbType.Date)
                  {
                      Value = _params.UserProfile_BirthDay == null ? DateTime.Now : _params.UserProfile_BirthDay
                  },
                  new SqlParameter("UserProfile_Age", SqlDbType.Int)
                  {
                      Value = _params.UserProfile_Age ?? 0
                  },
                  new SqlParameter("UserProfile_Gender", SqlDbType.Int)
                  {
                      Value = _params.UserProfile_Gender ?? 0
                  },
                  new SqlParameter("UserProfile_Phone", SqlDbType.VarChar)
                  {
                      Value = _params.UserProfile_Phone
                  },
                  new SqlParameter("UserProfile_Email", SqlDbType.VarChar)
                  {
                      Value = _params.UserProfile_Email
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
    public class ServiceLogin
    {
        /*==Define-UnitOfWork==*/
        UnitOfWork.UnitOfWork _uow = new UnitOfWork.UnitOfWork();
        /*==Define-Login-User==*/
        public bool Login(string UserProfileEmail, string UserProfilePass)
        {
            return _uow.UserProfileRepo.GetAny(a => a.UserProfileEmail.Equals(UserProfileEmail, StringComparison.OrdinalIgnoreCase)
            && a.UserProfilePass == UserProfilePass);
        }
        public void LoginService(UserProfileModel _params, out bool status, out string Message, out object Data)
        {

            status = false;
            Message = string.Empty;
            Data = null;
            var outputParams = new SqlParameter("@Msg", SqlDbType.Int)
            {
                Size = 400,
                Direction = ParameterDirection.Output
            };
            if (_params != null)
            {
                if (string.IsNullOrEmpty(_params.UserProfile_Email))
                {
                    status = false;
                    Message = "Vui lòng nhập vào tên Email";
                }
                else if (string.IsNullOrEmpty(_params.UserProfile_Pass))
                {
                    status = false;
                    Message = "Vui lòng nhập vào mật khẩu đăng nhập";
                }
                else
                {
                    var IsLogin = _uow.UserProfileRepo
                    .SQLQuery<UserProfileModel>("sp_Login @Email,@PassWords,@Msg out",
                    new SqlParameter("Email", SqlDbType.VarChar)
                    {
                        Value = _params.UserProfile_Email
                    },
                    new SqlParameter("PassWords", SqlDbType.VarChar)
                    {
                        Value = _params.UserProfile_Pass
                    }, outputParams).FirstOrDefault();
                    _params.Msg = (int)outputParams.Value;
                    if (_params.Msg == 1)
                    {
                        status = true;
                        Message = "Đăng nhập thành công";
                        Data = "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(_params.UserProfile_Email + ":" + _params.UserProfile_Pass.ToMD5()));
                    }
                    else
                    {
                        status = false;
                        Message = "Tên đăng nhập hoặc mật khẩu không chính xác";
                        Data = null;
                    }
                }
            }
            else
            {
                status = false;
                Message = "Đăng nhập thất bại";
                Data = null;
            }
        }
    }
}