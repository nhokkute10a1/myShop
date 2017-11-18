using DataModel.PagingModel;
using DataModel.SysGroupRoleModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataServices.SysGroupRoleService
{
    public class SysGroupRoleService
    {
        private readonly UnitOfWork.UnitOfWork _uow = new UnitOfWork.UnitOfWork();


        /*==GetAll  ==*/
        public List<SysGroupRoleModel> GetAll(PagingModel _params)
        {
            var data = _uow.SysGroupRoleRepo.SQLQuery<SysGroupRoleModel>("exec sp_SysGroupRoles_GetAll " +
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
        public SysGroupRoleModel GetById(SysGroupRoleModel _params)
        {
            var data = _uow.SysGroupRoleRepo.SQLQuery<SysGroupRoleModel>("sp_SysGroupRoles_GetById "
                + "@GroupRolesId",
                new SqlParameter("GroupRolesId", SqlDbType.Int)
                {
                    Value = _params.GroupRolesId
                }).FirstOrDefault();
            return data;
        }

        /*===Insert===*/
        public void Insert(SysGroupRoleModel _params)
        {
            try
            {
                _uow.SysGroupRoleRepo.ExcQuery("exec sp_SysGroupRoles_Insert " +
                    "@GroupRolesCode,"+
                    "@GroupRolesName,"+
                    "@Is_Active," +
                    "@Display_Order," +
                    "@CreateDate," +
                    "@CreateBy," +
                    "@UpdateDate," +
                    "@UpdateBy",
                     new SqlParameter("GroupRolesCode", SqlDbType.VarChar, (50))
                     {
                         Value = _params.GroupRolesCode ?? DBNull.Value.ToString()
                     },
                    new SqlParameter("GroupRolesName", SqlDbType.NVarChar, (50))
                    {
                        Value = _params.GroupRolesName
                    },
                     new SqlParameter("Is_Active", SqlDbType.Bit)
                     {
                         Value = _params.Is_Active == null ? true : _params.Is_Active
                     },
                    new SqlParameter("Display_Order", SqlDbType.Int)
                    {
                        Value = _params.Display_Order ?? 1
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
        public void Update(SysGroupRoleModel _params)
        {
            try
            {
                _uow.SysGroupRoleRepo.ExcQuery("exec sp_SysGroupRoles_Update " +
                    "@GroupRolesId,"+
                    "@GroupRolesCode," +
                    "@GroupRolesName," +
                    "@Is_Active," +
                    "@Display_Order," +
                    "@CreateDate," +
                    "@CreateBy," +
                    "@UpdateDate," +
                    "@UpdateBy",
                    new SqlParameter("GroupRolesId", SqlDbType.Int)
                    {
                        Value = _params.GroupRolesId 
                    },
                     new SqlParameter("GroupRolesCode", SqlDbType.VarChar, (50))
                     {
                         Value = _params.GroupRolesCode ?? DBNull.Value.ToString()
                     },
                    new SqlParameter("GroupRolesName", SqlDbType.NVarChar, (50))
                    {
                        Value = _params.GroupRolesName
                    },
                     new SqlParameter("Is_Active", SqlDbType.Bit)
                     {
                         Value = _params.Is_Active == null ? true : _params.Is_Active
                     },
                    new SqlParameter("Display_Order", SqlDbType.Int)
                    {
                        Value = _params.Display_Order ?? 1
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
        public void Delete(SysGroupRoleModel _params)
        {
            try
            {
                _uow.SysGroupRoleRepo.ExcQuery("exec sp_SysGroupRoles_Delete " +
                    "@GroupRolesId",
                    new SqlParameter("GroupRolesId", SqlDbType.Int)
                    {
                        Value = _params.GroupRolesId
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