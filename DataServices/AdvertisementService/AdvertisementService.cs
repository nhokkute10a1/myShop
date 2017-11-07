using DataModel.AdvertisementModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices.AdvertisementService
{
    public class AdvertisementService
    {
        private readonly UnitOfWork.UnitOfWork _uow = new UnitOfWork.UnitOfWork();
        /*==GetAll==*/
        public List<AdvertisementModel> GetAll()
        {
            var data = _uow.AdvertisementRepo.SQLQuery<AdvertisementModel>("sp_Advertisement_GetAll").ToList();
            return data;
        }
        /*==Get By Id==*/
        public AdvertisementModel GetById(AdvertisementModel _params)
        {
            var data = _uow.PromotionRepo.SQLQuery<AdvertisementModel>("sp_Advertisement_GetById " +
                "@Advertisement_ID",
                 new SqlParameter("Advertisement_ID", SqlDbType.Int)
                 {
                     Value = _params.Advertisement_ID
                 }).FirstOrDefault();
            return data;
        }
        /*==Insert==*/
        public void Insert(AdvertisementModel _params)
        {
            try
            {
                _uow.AdvertisementRepo.ExcQuery("exec sp_Advertisement_Insert " +
                    "@Advertisement_NameVN," +
                    "@Advertisement_NameEN," +
                    "@Advertisement_UrlOut," +
                    "@Advertisement_Rewrite," +
                    "@Advertisement_SearchVN," +
                    "@Advertisement_SearchEN," +
                    "@Advertisement_ContentVN," +
                    "@Advertisement_ContentEN," +
                    "@Advertisement_DescriptionVN," +
                    "@Advertisement_DescriptionEN," +
                    "@Advertisement_Img," +
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
                    "@Is_TopPage ," +
                    "@Is_LeftPage ," +
                    "@Is_RightPage ," +
                    "@Is_BottomPage ," +
                    "@Display_Order"
                    ,
                    new SqlParameter("Advertisement_NameVN", SqlDbType.NVarChar, (50))
                    {
                        Value = _params.Advertisement_NameVN
                    },
                    new SqlParameter("Advertisement_NameEN", SqlDbType.NVarChar, (50))
                    {
                        Value = _params.Advertisement_NameEN
                    },
                    new SqlParameter("Advertisement_UrlOut", SqlDbType.NVarChar, (255))
                    {
                        Value = _params.Advertisement_UrlOut ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Advertisement_Rewrite", SqlDbType.NVarChar, (255))
                    {
                        Value = _params.Advertisement_Rewrite
                    },
                    new SqlParameter("Advertisement_SearchVN", SqlDbType.VarChar, (50))
                    {
                        Value = _params.Advertisement_SearchVN ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Advertisement_SearchEN", SqlDbType.VarChar, (50))
                    {
                        Value = _params.Advertisement_SearchEN ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Advertisement_ContentVN", SqlDbType.NVarChar)
                    {
                        Value = _params.Advertisement_ContentVN ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Advertisement_ContentEN", SqlDbType.NVarChar)
                    {
                        Value = _params.Advertisement_ContentEN ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Advertisement_DescriptionVN", SqlDbType.NVarChar)
                    {
                        Value = _params.Advertisement_DescriptionVN ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Advertisement_DescriptionEN", SqlDbType.NVarChar)
                    {
                        Value = _params.Advertisement_DescriptionEN ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Advertisement_Img", SqlDbType.VarChar)
                    {
                        Value = _params.Advertisement_Img ?? DBNull.Value.ToString()
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
                        Value = _params.CreateDate == null ? DateTime.Now : _params.CreateDate
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
                    new SqlParameter("Is_TopPage", SqlDbType.Bit)
                    {
                        Value = _params.Is_TopPage == null ? true : _params.Is_TopPage
                    },
                    new SqlParameter("Is_LeftPage", SqlDbType.Bit)
                    {
                        Value = _params.Is_LeftPage == null ? false : _params.Is_LeftPage

                    },
                    new SqlParameter("Is_RightPage", SqlDbType.Bit)
                    {
                        Value = _params.Is_RightPage == null ? false : _params.Is_RightPage
                    },
                    new SqlParameter("Is_BottomPage", SqlDbType.Bit)
                    {
                        Value = _params.Is_BottomPage == null ? true : _params.Is_BottomPage
                    },
                    new SqlParameter("Display_Order", SqlDbType.Int)
                    {
                        Value = _params.Display_Order ?? 1
                    });
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra khi thêm mới " + ex.Message);
            }
        }

        /*==Update==*/
        public void Update(AdvertisementModel _params)
        {
            try
            {
                _uow.AdvertisementRepo.ExcQuery("exec sp_Advertisement_Update " +
                    "@Advertisement_ID," +
                    "@Advertisement_NameVN," +
                    "@Advertisement_NameEN," +
                    "@Advertisement_UrlOut," +
                    "@Advertisement_Rewrite," +
                    "@Advertisement_SearchVN," +
                    "@Advertisement_SearchEN," +
                    "@Advertisement_ContentVN," +
                    "@Advertisement_ContentEN," +
                    "@Advertisement_DescriptionVN," +
                    "@Advertisement_DescriptionEN," +
                    "@Advertisement_Img," +
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
                    "@Is_TopPage ," +
                    "@Is_LeftPage ," +
                    "@Is_RightPage ," +
                    "@Is_BottomPage ," +
                    "@Display_Order"
                    ,
                     new SqlParameter("Advertisement_ID", SqlDbType.Int)
                     {
                         Value = _params.Advertisement_ID
                     },
                    new SqlParameter("Advertisement_NameVN", SqlDbType.NVarChar, (50))
                    {
                        Value = _params.Advertisement_NameVN
                    },
                    new SqlParameter("Advertisement_NameEN", SqlDbType.NVarChar, (50))
                    {
                        Value = _params.Advertisement_NameEN
                    },
                    new SqlParameter("Advertisement_UrlOut", SqlDbType.NVarChar, (255))
                    {
                        Value = _params.Advertisement_UrlOut ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Advertisement_Rewrite", SqlDbType.NVarChar, (255))
                    {
                        Value = _params.Advertisement_Rewrite
                    },
                    new SqlParameter("Advertisement_SearchVN", SqlDbType.VarChar, (50))
                    {
                        Value = _params.Advertisement_SearchVN ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Advertisement_SearchEN", SqlDbType.VarChar, (50))
                    {
                        Value = _params.Advertisement_SearchEN ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Advertisement_ContentVN", SqlDbType.NVarChar)
                    {
                        Value = _params.Advertisement_ContentVN ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Advertisement_ContentEN", SqlDbType.NVarChar)
                    {
                        Value = _params.Advertisement_ContentEN ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Advertisement_DescriptionVN", SqlDbType.NVarChar)
                    {
                        Value = _params.Advertisement_DescriptionVN ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Advertisement_DescriptionEN", SqlDbType.NVarChar)
                    {
                        Value = _params.Advertisement_DescriptionEN ?? DBNull.Value.ToString()
                    },
                    new SqlParameter("Advertisement_Img", SqlDbType.VarChar)
                    {
                        Value = _params.Advertisement_Img ?? DBNull.Value.ToString()
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
                        Value = _params.CreateDate == null ? DateTime.Now : _params.CreateDate
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
                    new SqlParameter("Is_TopPage", SqlDbType.Bit)
                    {
                        Value = _params.Is_TopPage == null ? true : _params.Is_TopPage
                    },
                    new SqlParameter("Is_LeftPage", SqlDbType.Bit)
                    {
                        Value = _params.Is_LeftPage == null ? false : _params.Is_LeftPage

                    },
                    new SqlParameter("Is_RightPage", SqlDbType.Bit)
                    {
                        Value = _params.Is_RightPage == null ? false : _params.Is_RightPage
                    },
                    new SqlParameter("Is_BottomPage", SqlDbType.Bit)
                    {
                        Value = _params.Is_BottomPage == null ? true : _params.Is_BottomPage
                    },
                    new SqlParameter("Display_Order", SqlDbType.Int)
                    {
                        Value = _params.Display_Order ?? 1
                    });
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra khi cập nhập" + ex.Message);
            }
        }

        /*==Delete==*/
        public void Delete(AdvertisementModel _params)
        {
            try
            {
                _uow.AdvertisementRepo.ExcQuery("exec sp_Advertisement_Delete " +
                    "@Advertisement_ID" 
                    ,
                     new SqlParameter("Advertisement_ID", SqlDbType.Int)
                     {
                         Value = _params.Advertisement_ID
                     });
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra khi xóa" + ex.Message);
            }
        }
    }
}
