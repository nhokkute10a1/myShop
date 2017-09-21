using DataModel.Menu;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
namespace DataServices.MenuService
{
    public class MenuService
    {
        UnitOfWork.UnitOfWork _uow = new UnitOfWork.UnitOfWork();
        public void Insert(MenuModel _params)
        {
            try
            {
                _uow.MenuRepo.ExcQuery("exec sp_Menu_Insert " +
                    "@Parent_ID," +
                    "@Menu_Name," +
                    "@Display_Order," +
                    "@Is_Active",
                    new SqlParameter("Parent_ID", SqlDbType.Int)
                    {
                        Value = _params.Parent_ID ?? 0
                    },
                    new SqlParameter("Menu_Name", SqlDbType.NVarChar,(50))
                    {
                        Value = _params.Menu_Name ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Display_Order", SqlDbType.Int)
                    {
                        Value = _params.Display_Order ?? 1
                    },
                    new SqlParameter("Is_Active", SqlDbType.Bit)
                    {
                        Value = _params.Is_Active ?? true
                    }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xãy ra trong quá trình thêm mới " + ex.Message);
            }
        }
        public void Update(MenuModel _params)
        {
            try
            {
                _uow.MenuRepo.ExcQuery("exec sp_Menu_Update " +
                    "@Menu_ID," +
                    "@Parent_ID," +
                    "@Menu_Name," +
                    "@Display_Order," +
                    "@Is_Active",
                    new SqlParameter("Menu_ID", SqlDbType.Int)
                    {
                        Value = _params.Menu_ID
                    },
                    new SqlParameter("Parent_ID", SqlDbType.Int)
                    {
                        Value = _params.Parent_ID ?? 0
                    },
                    new SqlParameter("Menu_Name", SqlDbType.NVarChar, (50))
                    {
                        Value = _params.Menu_Name ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Display_Order", SqlDbType.Int)
                    {
                        Value = _params.Display_Order ?? 1
                    },
                    new SqlParameter("Is_Active", SqlDbType.Bit)
                    {
                        Value = _params.Is_Active ?? true
                    }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xãy ra trong quá trình cập nhật " + ex.Message);
            }
        }
        public void Delete(MenuModel _params)
        {
            try
            {
                _uow.MenuRepo.ExcQuery("exec sp_Menu_Update @Menu_ID",
                    new SqlParameter("Menu_ID", SqlDbType.Int)
                    {
                        Value = _params.Menu_ID
                    });
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xãy ra trong quá trình xoá " + ex.Message);
            }
        }
    }
}
