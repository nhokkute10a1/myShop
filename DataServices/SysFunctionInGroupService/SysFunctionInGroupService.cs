using DataModel.PagingModel;
using DataModel.SysFunctionInGroupModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices.SysFunctionInGroupService
{
    public class SysFunctionInGroupService
    {
        private readonly UnitOfWork.UnitOfWork _uow = new UnitOfWork.UnitOfWork();
        /*==GetAll  ==*/
        public List<SysFunctionInGroupModel> GetAll(PagingModel _params)
        {
            var data = _uow.SysFunctionInGroupRepo.SQLQuery<SysFunctionInGroupModel>("exec sp_SysFunctionInGroup_GetAll " +
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
        public SysFunctionInGroupModel GetById(SysFunctionInGroupModel _params)
        {
            var data = _uow.SysFunctionInGroupRepo.SQLQuery<SysFunctionInGroupModel>("sp_SysFunctionInGroup_GetById "
                + "@SysFunctionInGroupId",
                new SqlParameter("SysFunctionInGroupId", SqlDbType.Int)
                {
                    Value = _params.SysFunctionInGroupId
                }).FirstOrDefault();
            return data;
        }

        /*===Insert===*/
        public void Insert(SysFunctionInGroupModel _params)
        {
            try
            {
                _uow.SysFunctionInGroupRepo.ExcQuery("exec sp_SysFunctionInGroup_Insert " +
                    "@GroupRolesId," +
                    "@FuctionId," +
                    "@Descriptions," +
                    "@Display_Order," +
                    "@Is_Active," +
                    "@CreateDate," +
                    "@CreateBy," +
                    "@UpdateDate," +
                    "@UpdateBy",
                    new SqlParameter("GroupRolesId", SqlDbType.Int)
                    {
                        Value = _params.GroupRolesId
                    },
                    new SqlParameter("FuctionId", SqlDbType.Int)
                    {
                        Value = _params.FuctionId
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
        public void Update(SysFunctionInGroupModel _params)
        {
            try
            {
                _uow.SysFunctionInGroupRepo.ExcQuery("exec sp_SysFunctionInGroup_Update " +
                    "@SysFunctionInGroupId," +
                    "@GroupRolesId," +
                    "@FuctionId," +
                    "@Descriptions," +
                    "@Display_Order," +
                    "@Is_Active," +
                    "@CreateDate," +
                    "@CreateBy," +
                    "@UpdateDate," +
                    "@UpdateBy",
                     new SqlParameter("SysFunctionInGroupId", SqlDbType.Int)
                     {
                         Value = _params.SysFunctionInGroupId
                     },
                    new SqlParameter("GroupRolesId", SqlDbType.Int)
                    {
                        Value = _params.GroupRolesId
                    },
                    new SqlParameter("FuctionId", SqlDbType.Int)
                    {
                        Value = _params.FuctionId
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
                    });

            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xãy ra trong quá trình cập nhập " + ex.Message);
            }
        }

        /*===Delete===*/
        public void Delete(SysFunctionInGroupModel _params)
        {
            try
            {
                _uow.SysFunctionInGroupRepo.ExcQuery("exec sp_SysFunctionInGroup_Delete " +
                    "@SysFunctionInGroupId",
                    new SqlParameter("SysFunctionInGroupId", SqlDbType.Int)
                    {
                        Value = _params.SysFunctionInGroupId
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
