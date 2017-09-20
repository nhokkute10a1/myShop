using DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
namespace DataServices
{
    //step 5
    public class CategoryService
    {
        /*==Define-UnitOfWork==*/
        UnitOfWork.UnitOfWork _uow = new UnitOfWork.UnitOfWork();
        /*==GetAll -  Linq ==*/
        public List<CategoryModel> GetAll()
        {
            var query = _uow.CategoryRepo.GetAll()
                .Select(x => new CategoryModel
                {
                    Category_ID = x.Category_ID
                }).ToList();
            return query;
        }


        /*==GetAll -  Store ==*/
        public List<CategoryModel> GetAll_Store()
        {
            var data = _uow.CategoryRepo
                .SQLQuery<CategoryModel>("sp_GetAllCate_Get").ToList();
            return data;
        }

        /*==Add Category-  Store ==*/
        public void Add(CategoryModelAdd categoryModel)
        {
            try
            {
                
                _uow.CategoryRepo.ExcQuery("exec sp_AddCate " +
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
                    "@Display_Order",
                    new SqlParameter("Category_Parent_ID", SqlDbType.Int)
                    {
                        Value = categoryModel.Category_Parent_ID
                    },
                    new SqlParameter("Category_NameVN", SqlDbType.NVarChar,50)
                    {
                        Value = categoryModel.Category_NameVN ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Category_NameEN", SqlDbType.NVarChar, 50)
                    {
                        Value = categoryModel.Category_NameEN ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Category_UrlOut", SqlDbType.NVarChar)
                    {
                        Value = categoryModel.Category_UrlOut ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Category_Rewrite", SqlDbType.NVarChar)
                    {
                        Value = categoryModel.Category_Rewrite
                    },
                    new SqlParameter("Category_SearchVN", SqlDbType.VarChar)
                    {
                        Value = categoryModel.Category_SearchVN ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Category_SearchEN", SqlDbType.VarChar)
                    {
                        Value = categoryModel.Category_SearchEN ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Category_Icon", SqlDbType.VarChar)
                    {
                        Value = categoryModel.Category_Icon ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Category_Img", SqlDbType.VarChar)
                    {
                        Value = categoryModel.Category_Img ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Keyword_Titile", SqlDbType.NVarChar)
                    {
                        Value = categoryModel.Keyword_Titile ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Keyword_Content", SqlDbType.NVarChar)
                    {
                        Value = categoryModel.Keyword_Content ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Keyword_Description", SqlDbType.NVarChar)
                    {
                        Value = categoryModel.Keyword_Description ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("CreateDate", SqlDbType.Date)
                    {
                        Value = categoryModel.CreateDate 
                    },
                    new SqlParameter("CreateBy", SqlDbType.Int)
                    {
                        Value = categoryModel.CreateBy
                    },
                    new SqlParameter("UpdateDate", SqlDbType.Date)
                    {
                        Value = categoryModel.UpdateDate
                    },
                    new SqlParameter("UpdateBy", SqlDbType.Int)
                    {
                        Value = categoryModel.UpdateBy
                    },
                    new SqlParameter("Lock", SqlDbType.Int)
                    {
                        Value = categoryModel.Lock
                    },
                    new SqlParameter("Is_Active", SqlDbType.Bit)
                    {
                        Value = categoryModel.Is_Active
                    },
                    new SqlParameter("Is_HomePage", SqlDbType.Bit)
                    {
                        Value = categoryModel.Is_HomePage
                    },
                    new SqlParameter("Is_TopMenu", SqlDbType.Bit)
                    {
                        Value = categoryModel.Is_TopMenu
                    },
                    new SqlParameter("Is_BottomMenu", SqlDbType.Bit)
                    {
                        Value = categoryModel.Is_BottomMenu
                    },
                    new SqlParameter("Display_Order", SqlDbType.Int)
                    {
                        Value = categoryModel.Display_Order
                    }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xãy ra trong quá trình thêm mới " + ex.Message);
            }
        }
    }
}