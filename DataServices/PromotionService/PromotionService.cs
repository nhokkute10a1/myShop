using DataModel.PromotionModel;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataServices.PromotionService
{
    public class PromotionService
    {
        private readonly UnitOfWork.UnitOfWork _uow = new UnitOfWork.UnitOfWork();

        /*==Insert==*/
        public void Insert(PromotionModel _params)
        {
            try
            {
                _uow.ProductRepo.ExcQuery("exec sp_Promotion_Insert " +
                    "@Promotion_NameVN," +
                    "@Promotion_NameEN," +
                    "@Promotion_UrlOut ," +
                    "@Promotion_Rewrite ," +
                    "@Promotion_SearchVN ," +
                    "@Promotion_SearchEN," +
                    "@Promotion_ContentVN," +
                    "@Promotion_ContentEN," +
                    "@Promotion_DescriptionVN," +
                    "@Promotion_DescriptionEN," +
                    "@Promotion_Img," +
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
                    "@Lock ," +
                    "@Is_Active ," +
                    "@Is_LeftPage," +
                    "@Is_RightPage," +
                    "@Display_Order"
                    ,
                    new SqlParameter("Promotion_NameVN", SqlDbType.NVarChar,(50))
                    {
                        Value=_params.Promotion_NameVN
                    },
                    new SqlParameter("Promotion_NameEN", SqlDbType.NVarChar,(50))
                    {
                        Value = _params.Promotion_NameEN ??DBNull.Value.ToString()
                    },
                    new SqlParameter("Promotion_UrlOut", SqlDbType.NVarChar,(255))
                    {
                        Value = _params.Promotion_UrlOut ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Promotion_Rewrite", SqlDbType.NVarChar,(255))
                    {
                        Value = _params.Promotion_Rewrite
                    },
                    new SqlParameter("Promotion_SearchVN", SqlDbType.VarChar,(50))
                    {
                        Value = _params.Promotion_SearchVN ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Promotion_SearchEN", SqlDbType.VarChar, (50))
                    {
                        Value = _params.Promotion_SearchEN ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Promotion_ContentVN", SqlDbType.NVarChar)
                    {
                        Value = _params.Promotion_ContentVN ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Promotion_ContentEN", SqlDbType.NVarChar)
                    {
                        Value = _params.Promotion_ContentEN ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Promotion_DescriptionVN", SqlDbType.NVarChar)
                    {
                        Value = _params.Promotion_DescriptionVN ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Promotion_DescriptionEN", SqlDbType.NVarChar)
                    {
                        Value = _params.Promotion_DescriptionEN ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Promotion_Img", SqlDbType.VarChar)
                    {
                        Value = _params.Promotion_Img ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Img_Width", SqlDbType.Int)
                    {
                        Value = _params.Img_Width ??0
                    },
                    new SqlParameter("Img_Unit_Width", SqlDbType.VarChar)
                    {
                        Value = _params.Img_Unit_Width ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Img_Height", SqlDbType.Int)
                    {
                        Value = _params.Img_Height ??0
                    },
                    new SqlParameter("Img_Unit_Height", SqlDbType.VarChar)
                    {
                        Value = _params.Img_Unit_Height?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Keyword_Titile", SqlDbType.NVarChar,(50))
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
                        Value = _params.CreateDate == null ?DateTime.Now : _params.CreateDate
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
                        Value = _params.UpdateBy??1
                    },
                    new SqlParameter("Lock", SqlDbType.Int)
                    {
                        Value = _params.Lock ??0 
                    },
                    new SqlParameter("Is_Active", SqlDbType.Bit)
                    {
                        Value = _params.Is_Active==null?true: _params.Is_Active
                    },
                    new SqlParameter("Is_LeftPage", SqlDbType.Bit)
                    {
                        Value = _params.Is_LeftPage == null ? false : _params.Is_LeftPage
                    },
                    new SqlParameter("Is_RightPage", SqlDbType.Bit)
                    {
                        Value = _params.Is_RightPage==null ?false:_params.Is_RightPage
                    },
                    new SqlParameter("Display_Order", SqlDbType.Int)
                    {
                        Value = _params.Display_Order ??1
                    }
                );
            }
            catch(Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình thêm mới " + ex.Message);
            }
        }
    }
}