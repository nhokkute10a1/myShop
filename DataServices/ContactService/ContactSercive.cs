using DataModel.ContactModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices.ContactService
{
    public class ContactSercive
    {
        private readonly UnitOfWork.UnitOfWork _uow = new UnitOfWork.UnitOfWork();

        /*==Get All==*/
        public List<ContactModel> GetAll()
        {
            var data = _uow.ContactRepo.SQLQuery<ContactModel>("sp_Contact_GetAll").ToList();
            return data;
        }
        /*==Get All By Id==*/
        public ContactModel GetById(ContactModel _params)
        {
            var data = _uow.PageSettingRepo.SQLQuery<ContactModel>("sp_Contact_GetById " +
                "@Contact_ID",
                 new SqlParameter("Contact_ID", SqlDbType.Int)
                 {
                     Value = _params.Contact_ID
                 }).FirstOrDefault();
            return data;

        }
        /*==Insert==*/
        public void Insert(ContactModel _params)
        {
            try
            {
                _uow.ContactRepo.ExcQuery("exec sp_Contact_Insert " +
                    "@Contact_Name," +
                    "@Contact_CellPhone," +
                    "@Contact_Email," +
                    "@Contact_Address," +
                    "@Contact_Date," +
                    "@Is_Active"
                    ,
                    new SqlParameter("Contact_Name", SqlDbType.NVarChar,(50))
                    {
                        Value=_params.Contact_Name
                    },
                    new SqlParameter("Contact_CellPhone", SqlDbType.VarChar, (50))
                    {
                        Value = _params.Contact_CellPhone ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Contact_Email", SqlDbType.VarChar, (50))
                    {
                        Value = _params.Contact_Email
                    }, 
                    new SqlParameter("Contact_Address", SqlDbType.NVarChar)
                    {
                        Value = _params.Contact_Address ?? DBNull.Value.ToString()
                    }, 
                    new SqlParameter("Contact_Date", SqlDbType.Date)
                    {
                        Value = _params.Contact_Date ==null? DateTime.Now : _params.Contact_Date
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
        /*==Update==*/
        public void Update(ContactModel _params)
        {
            try
            {
                _uow.ContactRepo.ExcQuery("exec sp_Contact_Update " +
                    "@Contact_ID," +
                    "@Contact_Name," +
                    "@Contact_CellPhone," +
                    "@Contact_Email," +
                    "@Contact_Address," +
                    "@Contact_Date," +
                    "@Is_Active"
                    ,
                    new SqlParameter("Contact_ID", SqlDbType.Int)
                    {
                        Value = _params.Contact_ID
                    },
                    new SqlParameter("Contact_Name", SqlDbType.NVarChar, (50))
                    {
                        Value = _params.Contact_Name
                    },
                    new SqlParameter("Contact_CellPhone", SqlDbType.VarChar, (50))
                    {
                        Value = _params.Contact_CellPhone ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Contact_Email", SqlDbType.VarChar, (50))
                    {
                        Value = _params.Contact_Email
                    },
                    new SqlParameter("Contact_Address", SqlDbType.NVarChar)
                    {
                        Value = _params.Contact_Address ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Contact_Date", SqlDbType.Date)
                    {
                        Value = _params.Contact_Date == null ? DateTime.Now : _params.Contact_Date
                    },
                    new SqlParameter("Is_Active", SqlDbType.Bit)
                    {
                        Value = _params.Is_Active == null ? true : _params.Is_Active
                    }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình Cập nhập" + ex.Message);
            }
        }
        /*==Delete==*/
        public void Delete(ContactModel _params)
        {
            try
            {
                _uow.ContactRepo.ExcQuery("exec sp_Contact_Delete " +
                    "@Contact_ID" 
                    ,
                    new SqlParameter("Contact_ID", SqlDbType.Int)
                    {
                        Value = _params.Contact_ID
                    }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xóa " + ex.Message);
            }
        }
    }
}
