using DataModel.ProductModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices.ProductService
{
    public class ProductService
    {
        UnitOfWork.UnitOfWork _ouw = new UnitOfWork.UnitOfWork();

        /*==Insert -  Store ==*/
        public void Insert(ProductModel _params)
        {
            try
            {
                _ouw.ProductRepo.ExcQuery("exec sp_Product_Insert " +
                  "@Product_Code," +
                  "@Category_Parent_ID," +
                  "@Currency_ID," +
                  "@Product_NameVN," +
                  "@Product_NameEN," +
                  "@Product_UrlOut," +
                  "@Product_Rewrite," +
                  "@Product_SearchVN," +
                  "@Product_SearchEN," +
                  "@Product_ContentVN," +
                  "@Product_ContentEN," +
                  "@Product_DescriptionVN," +
                  "@Product_DescriptionEN," +
                  "@Product_Price," +
                  "@Product_Discount," +
                  "@Product_Img," +
                  "@Img_Width," +
                  "@Img_Unit_Width," +
                  "@Img_Height," +
                  "@Img_Unit_Height," +
                  "@Keyword_Titile," +
                  "@Keyword_Content," +
                  "@Keyword_Description," +
                  "@CreateDate," +
                  "@CreateBy,"+
                  "@UpdateDate," +
                  "@UpdateBy," +
                  "@Product_View," +
                  "@Lock,"+
                  "@Is_Active," +
                  "@Is_HomePage," +
                  "@Is_TopMenu," +
                  "@Is_BottomMenu," +
                  "@Display_Order"
                  ,
                  new SqlParameter("Product_Code", SqlDbType.VarChar, (50))
                  {
                      Value = _params.Product_Code ?? DBNull.Value.ToString()
                  },
                  new SqlParameter("Category_Parent_ID", SqlDbType.Int)
                  {
                      Value = _params.Category_Parent_ID
                  },
                  new SqlParameter("Currency_ID", SqlDbType.Int)
                  {
                      Value = _params.Currency_ID
                  },
                  new SqlParameter("Product_NameVN", SqlDbType.NVarChar, (50))
                  {
                      Value = _params.Product_NameVN
                  },
                  new SqlParameter("Product_NameEN", SqlDbType.NVarChar, (50))
                  {
                      Value = _params.Product_NameEN ?? DBNull.Value.ToString()
                  },
                  new SqlParameter("Product_UrlOut", SqlDbType.NVarChar, (255))
                  {
                      Value = _params.Product_UrlOut ?? DBNull.Value.ToString()
                  },
                  new SqlParameter("Product_Rewrite", SqlDbType.NVarChar, (255))
                  {
                      Value = _params.Product_Rewrite ?? DBNull.Value.ToString()
                  },
                  new SqlParameter("Product_SearchVN", SqlDbType.VarChar, (50))
                  {
                      Value = _params.Product_SearchVN ?? DBNull.Value.ToString()
                  },
                  new SqlParameter("Product_SearchEN", SqlDbType.VarChar, (50))
                  {
                      Value = _params.Product_SearchEN ?? DBNull.Value.ToString()
                  },
                  new SqlParameter("Product_ContentVN", SqlDbType.NVarChar)
                  {
                      Value = _params.Product_ContentVN ?? DBNull.Value.ToString()
                  },
                  new SqlParameter("Product_ContentEN", SqlDbType.NVarChar)
                  {
                      Value = _params.Product_ContentEN ?? DBNull.Value.ToString()
                  },
                  new SqlParameter("Product_DescriptionVN", SqlDbType.NVarChar)
                  {
                      Value = _params.Product_DescriptionVN ?? DBNull.Value.ToString()
                  },
                  new SqlParameter("Product_DescriptionEN", SqlDbType.NVarChar)
                  {
                      Value = _params.Product_DescriptionEN ?? DBNull.Value.ToString()
                  },
                  new SqlParameter("Product_Price", SqlDbType.Float)
                  {
                      Value = _params.Product_Price
                  },
                  new SqlParameter("Product_Discount", SqlDbType.Float)
                  {
                      Value = _params.Product_Discount
                  },
                  new SqlParameter("Product_Img", SqlDbType.VarChar, (50))
                  {
                      Value = _params.Product_Img ?? DBNull.Value.ToString()
                  },
                  new SqlParameter("Img_Width", SqlDbType.Int)
                  {
                      Value = _params.Img_Width ?? 0
                  },
                  new SqlParameter("Img_Unit_Width", SqlDbType.VarChar, (10))
                  {
                      Value = _params.Img_Unit_Width ?? DBNull.Value.ToString()
                  },
                  new SqlParameter("Img_Height", SqlDbType.Int)
                  {
                      Value = _params.Img_Height ?? 0
                  },
                  new SqlParameter("Img_Unit_Height", SqlDbType.VarChar, (10))
                  {
                      Value = _params.Img_Unit_Height ?? DBNull.Value.ToString()
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
                      Value = _params.UpdateDate == null?  DateTime.Now : _params.UpdateDate
                  },
                  new SqlParameter("UpdateBy", SqlDbType.Int)
                  {
                      Value = _params.UpdateBy ?? 1
                  },
                   new SqlParameter("Product_View", SqlDbType.Int)
                   {
                       Value = _params.Product_View ?? 0
                   },
                  new SqlParameter("Lock", SqlDbType.Int)
                  {
                      Value = _params.Lock ?? 0
                  },
                   new SqlParameter("Is_Active", SqlDbType.Bit)
                   {
                       Value = _params.Is_Active == null? true : _params.Is_Active
                   },
                    new SqlParameter("Is_HomePage", SqlDbType.Bit)
                    {
                        Value = _params.Is_HomePage ==null? true : _params.Is_HomePage
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
                throw new Exception("Có lỗi trong quá trình thêm mới " + ex.Message);
            }

        }

        /*==Update -  Store ==*/
        public void Update(ProductModel _params)
        {
            try
            {
                _ouw.ProductRepo.ExcQuery("exec sp_Product_Update " +
                   "@Product_ID,"+
                  "@Product_Code," +
                  "@Category_Parent_ID," +
                  "@Currency_ID," +
                  "@Product_NameVN," +
                  "@Product_NameEN," +
                  "@Product_UrlOut," +
                  "@Product_Rewrite," +
                  "@Product_SearchVN," +
                  "@Product_SearchEN," +
                  "@Product_ContentVN," +
                  "@Product_ContentEN," +
                  "@Product_DescriptionVN," +
                  "@Product_DescriptionEN," +
                  "@Product_Price," +
                  "@Product_Discount," +
                  "@Product_Img," +
                  "@Img_Width," +
                  "@Img_Unit_Width," +
                  "@Img_Height," +
                  "@Img_Unit_Height," +
                  "@Keyword_Titile," +
                  "@Keyword_Content," +
                  "@Keyword_Description," +
                  "@CreateDate," +
                  "@CreateBy," +
                  "@UpdateDate," +
                  "@UpdateBy," +
                  "@Product_View," +
                  "@Lock," +
                  "@Is_Active," +
                  "@Is_HomePage," +
                  "@Is_TopMenu," +
                  "@Is_BottomMenu," +
                  "@Display_Order"
                  ,
                  new SqlParameter("Product_ID", SqlDbType.Int)
                  {
                      Value = _params.Product_ID 
                  },
                  new SqlParameter("Product_Code", SqlDbType.VarChar, (50))
                  {
                      Value = _params.Product_Code ?? DBNull.Value.ToString()
                  },
                  new SqlParameter("Category_Parent_ID", SqlDbType.Int)
                  {
                      Value = _params.Category_Parent_ID
                  },
                  new SqlParameter("Currency_ID", SqlDbType.Int)
                  {
                      Value = _params.Currency_ID
                  },
                  new SqlParameter("Product_NameVN", SqlDbType.NVarChar, (50))
                  {
                      Value = _params.Product_NameVN
                  },
                  new SqlParameter("Product_NameEN", SqlDbType.NVarChar, (50))
                  {
                      Value = _params.Product_NameEN ?? DBNull.Value.ToString()
                  },
                  new SqlParameter("Product_UrlOut", SqlDbType.NVarChar, (255))
                  {
                      Value = _params.Product_UrlOut ?? DBNull.Value.ToString()
                  },
                  new SqlParameter("Product_Rewrite", SqlDbType.NVarChar, (255))
                  {
                      Value = _params.Product_Rewrite ?? DBNull.Value.ToString()
                  },
                  new SqlParameter("Product_SearchVN", SqlDbType.VarChar, (50))
                  {
                      Value = _params.Product_SearchVN ?? DBNull.Value.ToString()
                  },
                  new SqlParameter("Product_SearchEN", SqlDbType.VarChar, (50))
                  {
                      Value = _params.Product_SearchEN ?? DBNull.Value.ToString()
                  },
                  new SqlParameter("Product_ContentVN", SqlDbType.NVarChar)
                  {
                      Value = _params.Product_ContentVN ?? DBNull.Value.ToString()
                  },
                  new SqlParameter("Product_ContentEN", SqlDbType.NVarChar)
                  {
                      Value = _params.Product_ContentEN ?? DBNull.Value.ToString()
                  },
                  new SqlParameter("Product_DescriptionVN", SqlDbType.NVarChar)
                  {
                      Value = _params.Product_DescriptionVN ?? DBNull.Value.ToString()
                  },
                  new SqlParameter("Product_DescriptionEN", SqlDbType.NVarChar)
                  {
                      Value = _params.Product_DescriptionEN ?? DBNull.Value.ToString()
                  },
                  new SqlParameter("Product_Price", SqlDbType.Float)
                  {
                      Value = _params.Product_Price
                  },
                  new SqlParameter("Product_Discount", SqlDbType.Float)
                  {
                      Value = _params.Product_Discount
                  },
                  new SqlParameter("Product_Img", SqlDbType.VarChar, (50))
                  {
                      Value = _params.Product_Img ?? DBNull.Value.ToString()
                  },
                  new SqlParameter("Img_Width", SqlDbType.Int)
                  {
                      Value = _params.Img_Width ?? 0
                  },
                  new SqlParameter("Img_Unit_Width", SqlDbType.VarChar, (10))
                  {
                      Value = _params.Img_Unit_Width ?? DBNull.Value.ToString()
                  },
                  new SqlParameter("Img_Height", SqlDbType.Int)
                  {
                      Value = _params.Img_Height ?? 0
                  },
                  new SqlParameter("Img_Unit_Height", SqlDbType.VarChar, (10))
                  {
                      Value = _params.Img_Unit_Height ?? DBNull.Value.ToString()
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
                   new SqlParameter("Product_View", SqlDbType.Int)
                   {
                       Value = _params.Product_View ?? 0
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
                throw new Exception("Có lỗi trong quá trình cập nhập " + ex.Message);
            }

        }

        /*==Delete -  Store ==*/
        public void Delete(ProductModel _params)
        {
            try
            {
                _ouw.ProductRepo.ExcQuery("exec sp_Product_Delete @Product_ID",
                  new SqlParameter("Product_ID", SqlDbType.Int)
                  {
                      Value = _params.Product_ID
                  }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi trong quá trình xóa " + ex.Message);
            }

        }
    }
}
