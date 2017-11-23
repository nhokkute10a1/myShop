using DataModel.PagingModel;
using DataModel.SysFunctionGroupModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataServices.SysFunctionGroupService
{
    public class SysFunctionGroupService
    {
        private readonly UnitOfWork.UnitOfWork _uow = new UnitOfWork.UnitOfWork();

        /*==GetAll  ==*/
        public List<SysFunctionGroupModel> GetAll(PagingModel _params)
        {
            var data = _uow.SysFunctionGroupRepo.SQLQuery<SysFunctionGroupModel>("exec sp_SysFunctionGroup_GetAll " +
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
        public SysFunctionGroupModel GetById(SysFunctionGroupModel _params)
        {
            var data = _uow.SysFunctionGroupRepo.SQLQuery<SysFunctionGroupModel>("sp_SysFunctionGroup_GetById "
                + "@SysFunctionGroupId",
                new SqlParameter("SysFunctionGroupId", SqlDbType.Int)
                {
                    Value = _params.SysFunctionGroupId
                }).FirstOrDefault();
            return data;
        }


        /*==Insert==*/
        public void Insert(SysFunctionGroupModel _params)
        {
            try
            {
                    _uow.SysFunctionGroupRepo.ExcQuery("exec sp_SysFunctionGroup_Insert " +
                        "@SysFunctionGroupCode,"+
                        "@SysFunctionGroupName,"+
                        "@Descriptions,"+
                        "@Display_Order,"+
                        "@Is_Active,"+
                        "@CreateDate,"+
                        "@CreateBy,"+
                        "@UpdateDate,"+
                        "@UpdateBy",
                    new SqlParameter("SysFunctionGroupCode", SqlDbType.VarChar, (50))
                    {
                        Value = _params.SysFunctionGroupCode ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("SysFunctionGroupName", SqlDbType.NVarChar, (255))
                    {
                        Value = _params.SysFunctionGroupName
                    },
                    new SqlParameter("Descriptions", SqlDbType.NVarChar)
                    {
                        Value = _params.Descriptions ?? DBNull.Value.ToString()
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
                        Value = _params.CreateDate ==null ? DateTime.Now : _params.CreateDate
                    },
                    new SqlParameter("CreateBy", SqlDbType.Int)
                    {
                        Value = _params.CreateBy ?? 1
                    },
                    new SqlParameter("UpdateDate", SqlDbType.Date)
                    {
                        Value = _params.UpdateDate ==null ? DateTime.Now : _params.UpdateDate
                    }, 
                    new SqlParameter("UpdateBy", SqlDbType.Int)
                    {
                        Value = _params.UpdateBy ?? 1
                    }); 
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình thêm mới " + ex.Message);
            }
        }

        /*==Update==*/
        public void Update(SysFunctionGroupModel _params)
        {
            try
            {
                _uow.SysFunctionGroupRepo.ExcQuery("exec sp_SysFunctionGroup_Update " +
                    "@SysFunctionGroupId,"+
                    "@SysFunctionGroupCode," +
                    "@SysFunctionGroupName," +
                    "@Descriptions," +
                    "@Display_Order," +
                    "@Is_Active," +
                    "@CreateDate," +
                    "@CreateBy," +
                    "@UpdateDate," +
                    "@UpdateBy",
                new SqlParameter("SysFunctionGroupId", SqlDbType.Int)
                {
                    Value = _params.SysFunctionGroupId 
                },
                new SqlParameter("SysFunctionGroupCode", SqlDbType.VarChar, (50))
                {
                    Value = _params.SysFunctionGroupCode ?? DBNull.Value.ToString()
                },
                new SqlParameter("SysFunctionGroupName", SqlDbType.NVarChar, (255))
                {
                    Value = _params.SysFunctionGroupName
                },
                new SqlParameter("Descriptions", SqlDbType.NVarChar)
                {
                    Value = _params.Descriptions ?? DBNull.Value.ToString()
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
                    Value = _params.CreateDate
                },
                new SqlParameter("CreateBy", SqlDbType.Int)
                {
                    Value = _params.CreateBy ?? 1
                },
                new SqlParameter("UpdateDate", SqlDbType.Date)
                {
                    Value = _params.UpdateDate == null ? DateTime.Now : _params.UpdateDate
                },
                new SqlParameter("UpdateBy", SqlDbType.Int)
                {
                    Value = _params.UpdateBy ?? 1
                });
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình cập nhập " + ex.Message);
            }
        }

        /*==Delete==*/
        public void Delete(SysFunctionGroupModel _params)
        {
            try
            {
                _uow.SysFunctionGroupRepo.ExcQuery("exec sp_SysFunctionGroup_Delete " +
                    "@SysFunctionGroupId" ,
                new SqlParameter("SysFunctionGroupId", SqlDbType.Int)
                {
                    Value = _params.SysFunctionGroupId
                });
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xóa " + ex.Message);
            }
        }
    }
}