using DataModel.PagingModel;
using DataModel.SysFunctionModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices.SysFunctionService
{
    public class SysFunctionService
    {
        private readonly UnitOfWork.UnitOfWork _uow = new UnitOfWork.UnitOfWork();

        /*==GetAll  ==*/
        public List<SysFunctionModel> GetAll(PagingModel _params)
        {
            var data = _uow.SysFunctionRepo.SQLQuery<SysFunctionModel>("exec sp_SysFunction_GetAll " +
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
        public SysFunctionModel GetById(SysFunctionModel _params)
        {
            var data = _uow.SysFunctionRepo.SQLQuery<SysFunctionModel>("sp_SysFunction_GetById "
                + "@FunctionId",
                new SqlParameter("FunctionId", SqlDbType.Int)
                {
                    Value = _params.FunctionId
                }).FirstOrDefault();
            return data;
        }

        /*===Insert===*/
        public void Insert(SysFunctionModel _params)
        {
            try
            {
                _uow.SysFunctionRepo.ExcQuery("exec sp_SysFunction_Insert " +
                    "@TreePanelId," +
                    "@SysFunctionGroupId," +
                    "@FunctionCode," +
                    "@FunctionName," +
                    "@ButtonId," +
                    "@Display_Order," +
                    "@Is_Active," +
                    "@CreateDate," +
                    "@CreateBy," +
                    "@UpdateDate," +
                    "@UpdateBy",
                    new SqlParameter("TreePanelId", SqlDbType.Int)
                    {
                        Value = _params.TreePanelId ?? 1
                    },
                    new SqlParameter("SysFunctionGroupId", SqlDbType.Int)
                    {
                        Value = _params.SysFunctionGroupId
                    },
                     new SqlParameter("FunctionCode", SqlDbType.VarChar, (50))
                     {
                         Value = _params.FunctionCode ?? DBNull.Value.ToString()
                     },
                    new SqlParameter("FunctionName", SqlDbType.NVarChar, (50))
                    {
                        Value = _params.FunctionName
                    },
                     new SqlParameter("ButtonId", SqlDbType.VarChar, (50))
                     {
                         Value = _params.ButtonId ?? DBNull.Value.ToString()
                     },
                    new SqlParameter("Display_Order", SqlDbType.Int)
                    {
                        Value = _params.Display_Order ?? 1
                    },
                     new SqlParameter("Is_Active", SqlDbType.Bit)
                     {
                         Value = _params.Is_Active == null ? true : _params.Is_Active
                     },
                    new SqlParameter("CreateDate", SqlDbType.Date)
                    {
                        Value = _params.CreateDate == null ? DateTime.Now : _params.CreateDate
                    },
                     new SqlParameter("CreateBy", SqlDbType.Int)
                     {
                         Value = _params.CreateBy == null ? 1 : _params.CreateBy
                     },
                    new SqlParameter("UpdateDate", SqlDbType.Date)
                    {
                        Value = _params.UpdateDate == null ? DateTime.Now : _params.UpdateDate
                    },
                    new SqlParameter("UpdateBy", SqlDbType.Int)
                    {
                        Value = _params.UpdateBy == null ? 1 : _params.UpdateBy
                    }
                    );

            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xãy ra trong quá trình thêm mới " + ex.Message);
            }
        }

        /*===Update===*/
        public void Update(SysFunctionModel _params)
        {
            try
            {
                _uow.SysFunctionRepo.ExcQuery("exec sp_SysFunction_Update " +
                    "@FunctionId,"+
                    "@TreePanelId," +
                    "@SysFunctionGroupId," +
                    "@FunctionCode," +
                    "@FunctionName," +
                    "@ButtonId," +
                    "@Display_Order," +
                    "@Is_Active," +
                    "@CreateDate," +
                    "@CreateBy," +
                    "@UpdateDate," +
                    "@UpdateBy",
                    new SqlParameter("FunctionId", SqlDbType.Int)
                    {
                        Value = _params.FunctionId
                    },
                    new SqlParameter("TreePanelId", SqlDbType.Int)
                    {
                        Value = _params.TreePanelId ?? 1
                    },
                    new SqlParameter("SysFunctionGroupId", SqlDbType.Int)
                    {
                        Value = _params.SysFunctionGroupId
                    },
                     new SqlParameter("FunctionCode", SqlDbType.VarChar, (50))
                     {
                         Value = _params.FunctionCode ?? DBNull.Value.ToString()
                     },
                    new SqlParameter("FunctionName", SqlDbType.NVarChar, (50))
                    {
                        Value = _params.FunctionName
                    },
                     new SqlParameter("ButtonId", SqlDbType.VarChar, (50))
                     {
                         Value = _params.ButtonId ?? DBNull.Value.ToString()
                     },
                    new SqlParameter("Display_Order", SqlDbType.Int)
                    {
                        Value = _params.Display_Order ?? 1
                    },
                     new SqlParameter("Is_Active", SqlDbType.Bit)
                     {
                         Value = _params.Is_Active == null ? true : _params.Is_Active
                     },
                    new SqlParameter("CreateDate", SqlDbType.Date)
                    {
                        Value = _params.CreateDate == null ? DateTime.Now : _params.CreateDate
                    },
                     new SqlParameter("CreateBy", SqlDbType.Int)
                     {
                         Value = _params.CreateBy == null ? 1 : _params.CreateBy
                     },
                    new SqlParameter("UpdateDate", SqlDbType.Date)
                    {
                        Value = _params.UpdateDate == null ? DateTime.Now : _params.UpdateDate
                    },
                    new SqlParameter("UpdateBy", SqlDbType.Int)
                    {
                        Value = _params.UpdateBy == null ? 1 : _params.UpdateBy
                    }
                    );

            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xãy ra trong quá trình cập nhập " + ex.Message);
            }
        }

        /*===Delete===*/
        public void Delete(SysFunctionModel _params)
        {
            try
            {
                _uow.SysFunctionRepo.ExcQuery("exec sp_SysFunction_Delete " +
                    "@FunctionId" ,
                    new SqlParameter("FunctionId", SqlDbType.Int)
                    {
                        Value = _params.FunctionId
                    }
                    );

            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xãy ra trong quá trình xóa " + ex.Message);
            }
        }
    }
}
