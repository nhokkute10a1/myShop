using DataModel.CategoryModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataServices.CategoryService
{
    public class CategoryService
    {
        private UnitOfWork.UnitOfWork _uow = new UnitOfWork.UnitOfWork();

        /*==GetAll -  Store ==*/
        public List<CategoryModel> GetAll()
        {
            var data = _uow.CategoryRepo
                .SQLQuery<CategoryModel>("sp_Category_GetAll").ToList();
            return data;
        }

        /*==GetAllByParentId -  Store ==*/
        public List<CategoryModel>GetAllByParentId(CategoryModel _params)
        {
            var data = _uow.CategoryRepo.SQLQuery<CategoryModel>("sp_Category_GetAllByIdParent "
                + "@Category_Parent_ID",
                new SqlParameter("Category_Parent_ID", SqlDbType.Int)
                {
                    Value = _params.Category_Parent_ID ?? 0
                }
                    
                ).ToList();
            return data;
        }

        /*==Insert -  Store ==*/
        public void Insert(CategoryModel _params)
        {
            try
            {
                _uow.MenuRepo.ExcQuery("exec sp_Category_Insert " +
                    "@Category_Parent_ID," +
                    "@Category_NameVN," +
                    "@Category_NameEN," +
                    "@Category_UrlOut," +
                    "@Category_Rewrite," +
                    "@Category_SearchVN,"+
                    "@Category_SearchEN," +
                    "@Category_Icon," +
                    "@Category_Img," +
                    "@Keyword_Titile," +
                    "@Keyword_Content," +
                    "@Keyword_Description,"+
                    "@CreateDate," +
                    "@CreateBy,"+
                    "@UpdateDate," +
                    "@UpdateBy,"+
                    "@Lock," +
                    "@Is_Active,"+
                    "@Is_HomePage," +
                    "@Is_TopMenu," +
                    "@Is_BottomMenu," +
                    "@Display_Order"
                    ,
                    new SqlParameter("Category_Parent_ID", SqlDbType.Int)
                    {
                        Value = _params.Category_Parent_ID ?? 0
                    },
                    new SqlParameter("Category_NameVN", SqlDbType.NVarChar, (50))
                    {
                        Size = 8000,
                        Value = _params.Category_NameVN
                    },
                    new SqlParameter("Category_NameEN", SqlDbType.NVarChar, (50))
                    {
                        Value = _params.Category_NameEN
                    },
                    new SqlParameter("Category_UrlOut", SqlDbType.NVarChar, (255))
                    {
                        Value = _params.Category_UrlOut ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Category_Rewrite", SqlDbType.NVarChar, (255))
                    {
                        Value = _params.Category_Rewrite
                    },
                    new SqlParameter("Category_SearchVN", SqlDbType.VarChar, (50))
                    {
                        Value = _params.Category_SearchVN ?? DBNull.Value.ToString()
                    },
                     new SqlParameter("Category_SearchEN", SqlDbType.VarChar, (50))
                     {
                         Value = _params.Category_SearchEN ?? DBNull.Value.ToString()
                     },
                      new SqlParameter("Category_Icon", SqlDbType.VarChar, (255))
                      {
                          Value = _params.Category_Icon ?? DBNull.Value.ToString()
                      },
                      new SqlParameter("Category_Img", SqlDbType.VarChar, (255))
                      {
                          Value = _params.Category_Img ?? DBNull.Value.ToString()
                      },
                      new SqlParameter("Keyword_Titile", SqlDbType.NVarChar, (50))
                      {
                          Value = _params.Keyword_Titile ?? DBNull.Value.ToString()
                      },
                      new SqlParameter("Keyword_Content", SqlDbType.NVarChar)
                      {
                          Value = _params.Keyword_Content ?? DBNull.Value.ToString()
                      },
                      new SqlParameter("Keyword_Description", SqlDbType.NVarChar)
                      {
                          Value = _params.Keyword_Description ?? DBNull.Value.ToString()
                      },
                      new SqlParameter("CreateDate", SqlDbType.Date)
                      {
                          Value = _params.CreateDate ?? DateTime.Now
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
                      },
                      new SqlParameter("Lock", SqlDbType.Int)
                      {
                          Value = _params.Lock ?? 0
                      },
                   new SqlParameter("Is_Active", SqlDbType.Bit)
                   {
                       Value = _params.Is_Active == null ? true : _params.Is_Active
                   },
                    new SqlParameter("Is_HomePage", SqlDbType.Bit)
                    {
                        Value = _params.Is_HomePage == null ? true : _params.Is_HomePage
                    },
                    new SqlParameter("Is_TopMenu", SqlDbType.Bit)
                    {
                        Value = _params.Is_TopMenu == null ? false : _params.Is_TopMenu
                    },
                    new SqlParameter("Is_BottomMenu", SqlDbType.Bit)
                    {
                        Value = _params.Is_BottomMenu == null ? true : _params.Is_TopMenu
                    },
                    new SqlParameter("Display_Order", SqlDbType.Int)
                    {
                        Value = _params.Display_Order ?? 1
                    }
                      );
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xãy ra trong quá trình thêm mới " + ex.Message);
            }
        }

        /*==Update -  Store ==*/
        public void Update(CategoryModel _params)
        {
            try
            {
                _uow.MenuRepo.ExcQuery("exec sp_Category_Update " +
                    "@Category_ID," +
                    "@Category_Parent_ID," +
                    "@Category_NameVN," +
                    "@Category_NameEN," +
                    "@Category_UrlOut," +
                    "@Category_Rewrite," +
                    "@Category_SearchVN," +
                    "@Category_SearchEN," +
                    "@Category_Icon," +
                    "@Category_Img," +
                    "@Keyword_Titile," +
                    "@Keyword_Content," +
                    "@Keyword_Description," +
                    "@CreateDate," +
                    "@CreateBy," +
                    "@UpdateDate," +
                    "@UpdateBy," +
                    "@Lock," +
                    "@Is_Active," +
                    "@Is_HomePage," +
                    "@Is_TopMenu," +
                    "@Is_BottomMenu," +
                    "@Display_Order"
                    ,
                     new SqlParameter("Category_ID", SqlDbType.Int)
                     {
                         Value = _params.Category_ID
                     },
                    new SqlParameter("Category_Parent_ID", SqlDbType.Int)
                    {
                        Value = _params.Category_Parent_ID ?? 0
                    },
                    new SqlParameter("Category_NameVN", SqlDbType.NVarChar, (50))
                    {
                        Size = 8000,
                        Value = _params.Category_NameVN
                    },
                    new SqlParameter("Category_NameEN", SqlDbType.NVarChar, (50))
                    {
                        Value = _params.Category_NameEN
                    },
                    new SqlParameter("Category_UrlOut", SqlDbType.NVarChar, (255))
                    {
                        Value = _params.Category_UrlOut ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Category_Rewrite", SqlDbType.NVarChar, (255))
                    {
                        Value = _params.Category_Rewrite
                    },
                    new SqlParameter("Category_SearchVN", SqlDbType.VarChar, (50))
                    {
                        Value = _params.Category_SearchVN ?? DBNull.Value.ToString()
                    },
                     new SqlParameter("Category_SearchEN", SqlDbType.VarChar, (50))
                     {
                         Value = _params.Category_SearchEN ?? DBNull.Value.ToString()
                     },
                      new SqlParameter("Category_Icon", SqlDbType.VarChar, (255))
                      {
                          Value = _params.Category_Icon ?? DBNull.Value.ToString()
                      },
                      new SqlParameter("Category_Img", SqlDbType.VarChar, (255))
                      {
                          Value = _params.Category_Img ?? DBNull.Value.ToString()
                      },
                      new SqlParameter("Keyword_Titile", SqlDbType.NVarChar, (50))
                      {
                          Value = _params.Keyword_Titile ?? DBNull.Value.ToString()
                      },
                      new SqlParameter("Keyword_Content", SqlDbType.NVarChar)
                      {
                          Value = _params.Keyword_Content ?? DBNull.Value.ToString()
                      },
                      new SqlParameter("Keyword_Description", SqlDbType.NVarChar)
                      {
                          Value = _params.Keyword_Description ?? DBNull.Value.ToString()
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
                          Value = _params.UpdateDate
                      },
                      new SqlParameter("UpdateBy", SqlDbType.Int)
                      {
                          Value = _params.UpdateBy ?? 1
                      },
                      new SqlParameter("Lock", SqlDbType.Int)
                      {
                          Value = _params.Lock ?? 0
                      },
                      new SqlParameter("Is_Active", SqlDbType.Bit)
                      {
                          Value = _params.Is_Active
                      },
                    new SqlParameter("Is_HomePage", SqlDbType.Bit)
                    {
                        Value = _params.Is_HomePage
                    },
                    new SqlParameter("Is_TopMenu", SqlDbType.Bit)
                    {
                        Value = _params.Is_TopMenu
                    },
                    new SqlParameter("Is_BottomMenu", SqlDbType.Bit)
                    {
                        Value = _params.Is_BottomMenu
                    },
                    new SqlParameter("Display_Order", SqlDbType.Int)
                    {
                        Value = _params.Display_Order
                    }
                      );
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xãy ra trong quá trình cập nhập " + ex.Message);
            }
        }

        /*==Delete -  Store ==*/
        public void Delete(CategoryModel _params)
        {
            try
            {
                _uow.MenuRepo.ExcQuery("exec sp_Category_Delete  @Category_ID",
                     new SqlParameter("Category_ID", SqlDbType.Int)
                     {
                         Value = _params.Category_ID
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