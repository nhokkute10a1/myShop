using DataModel.PageSettingModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataServices.PageSettingService
{
    public class PageSettingService
    {
        private UnitOfWork.UnitOfWork _uow = new UnitOfWork.UnitOfWork();

        /*===Get All===*/
        public List<PageSettingModel> GetAll()
        {
            var data = _uow.PageSettingRepo.SQLQuery<PageSettingModel>("sp_PageSetting_GetAll").ToList();
            return data;
        }
        /*===Get All By Id*/
        public PageSettingModel GetById(PageSettingModel _params)
        {
            var data=_uow.PageSettingRepo.SQLQuery<PageSettingModel>("sp_PageSetting_GetAllById "+
                "@PageSetting_ID",
                 new SqlParameter("PageSetting_ID", SqlDbType.Int)
                 {
                     Value = _params.PageSetting_ID
                 }).FirstOrDefault();
            return data;
            
        }
        /*===Insert===*/
        public void Insert(PageSettingModel _params)
        {
            try
            {
                _uow.PageSettingRepo.ExcQuery("exec sp_PageSetting_Insert " +
                    "@PageSetting_NameVN," +
                    "@PageSetting_NameEN, " +
                    "@PageSetting_UrlOut," +
                    "@PageSetting_Rewrite," +
                       "@PageSetting_SearchVN," +
                       "@PageSetting_SearchEN," +
                       "@PageSetting_Img," +
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
                       "@Lock," +
                       "@Is_Active," +
                       "@Is_TopPage," +
                       "@Is_LeftPage," +
                       "@Is_RightPage," +
                       "@Is_BottomPage," +
                       "@Display_Order"

                    ,
                    new SqlParameter("PageSetting_NameVN", SqlDbType.NVarChar, (50))
                    {
                        Value = _params.PageSetting_NameVN
                    },
                    new SqlParameter("PageSetting_NameEN", SqlDbType.NVarChar, (50))
                    {
                        Value = _params.PageSetting_NameEN
                    },
                    new SqlParameter("PageSetting_UrlOut", SqlDbType.NVarChar, (255))
                    {
                        Value = _params.PageSetting_UrlOut ?? DBNull.Value.ToString()
                    },
                     new SqlParameter("PageSetting_Rewrite", SqlDbType.NVarChar, (255))
                     {
                         Value = _params.PageSetting_Rewrite
                     },
                     new SqlParameter("PageSetting_SearchVN", SqlDbType.VarChar, (50))
                     {
                         Value = _params.PageSetting_SearchVN ?? DBNull.Value.ToString()
                     },
                     new SqlParameter("PageSetting_SearchEN", SqlDbType.VarChar, (50))
                     {
                         Value = _params.PageSetting_SearchEN ?? DBNull.Value.ToString()
                     },
                      new SqlParameter("PageSetting_Img", SqlDbType.VarChar)
                      {
                          Value = _params.PageSetting_Img ?? DBNull.Value.ToString()
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
                         Value = _params.CreateBy == null ? 1 : _params.CreateBy
                     },
                      new SqlParameter("UpdateDate", SqlDbType.Date)
                      {
                          Value = _params.UpdateDate == null ? DateTime.Now : _params.UpdateDate
                      },
                     new SqlParameter("UpdateBy", SqlDbType.Int)
                     {
                         Value = _params.UpdateBy == null ? 1 : _params.UpdateBy
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
                      new SqlParameter("Is_BottomPage", SqlDbType.Bit)
                      {
                          Value = _params.Is_BottomPage == null ? true : _params.Is_BottomPage
                      },
                     new SqlParameter("Is_LeftPage", SqlDbType.Bit)
                     {
                         Value = _params.Is_LeftPage == null ? false : _params.Is_LeftPage
                     },
                     new SqlParameter("Is_RightPage", SqlDbType.Bit)
                     {
                         Value = _params.Is_RightPage == null ? false : _params.Is_RightPage
                     },
                     new SqlParameter("Display_Order", SqlDbType.Int)
                     {
                         Value = _params.Display_Order == null ? 1 : _params.Display_Order
                     }
                    );

            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình thêm mới" + ex.Message);
            }
        }

        /*===Update===*/
        public void Update(PageSettingModel _params)
        {
            try
            {
                _uow.PageSettingRepo.ExcQuery("exec sp_PageSetting_Update " +
                    "@PageSetting_ID," +
                    "@PageSetting_NameVN," +
                    "@PageSetting_NameEN, " +
                    "@PageSetting_UrlOut," +
                    "@PageSetting_Rewrite," +
                       "@PageSetting_SearchVN," +
                       "@PageSetting_SearchEN," +
                       "@PageSetting_Img," +
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
                       "@Lock," +
                       "@Is_Active," +
                       "@Is_TopPage," +
                       "@Is_LeftPage," +
                       "@Is_RightPage," +
                       "@Is_BottomPage," +
                       "@Display_Order"

                    ,
                    new SqlParameter("PageSetting_ID", SqlDbType.Int)
                    {
                        Value = _params.PageSetting_ID
                    },
                    new SqlParameter("PageSetting_NameVN", SqlDbType.NVarChar, (50))
                    {
                        Value = _params.PageSetting_NameVN
                    },
                    new SqlParameter("PageSetting_NameEN", SqlDbType.NVarChar, (50))
                    {
                        Value = _params.PageSetting_NameEN
                    },
                    new SqlParameter("PageSetting_UrlOut", SqlDbType.NVarChar, (255))
                    {
                        Value = _params.PageSetting_UrlOut ?? DBNull.Value.ToString()
                    },
                     new SqlParameter("PageSetting_Rewrite", SqlDbType.NVarChar, (255))
                     {
                         Value = _params.PageSetting_Rewrite
                     },
                     new SqlParameter("PageSetting_SearchVN", SqlDbType.VarChar, (50))
                     {
                         Value = _params.PageSetting_SearchVN ?? DBNull.Value.ToString()
                     },
                     new SqlParameter("PageSetting_SearchEN", SqlDbType.VarChar, (50))
                     {
                         Value = _params.PageSetting_SearchEN ?? DBNull.Value.ToString()
                     },
                      new SqlParameter("PageSetting_Img", SqlDbType.VarChar)
                      {
                          Value = _params.PageSetting_Img ?? DBNull.Value.ToString()
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
                         Value = _params.CreateDate 
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
                      new SqlParameter("Is_BottomPage", SqlDbType.Bit)
                      {
                          Value = _params.Is_BottomPage == null ? true : _params.Is_BottomPage
                      },
                     new SqlParameter("Is_LeftPage", SqlDbType.Bit)
                     {
                         Value = _params.Is_LeftPage == null ? false : _params.Is_LeftPage
                     },
                     new SqlParameter("Is_RightPage", SqlDbType.Bit)
                     {
                         Value = _params.Is_RightPage == null ? false : _params.Is_RightPage
                     },
                     new SqlParameter("Display_Order", SqlDbType.Int)
                     {
                         Value = _params.Display_Order == null ? 1 : _params.Display_Order
                     }
                    );

            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình cập nhập" + ex.Message);
            }
        }

        /*===Delete===*/
        public void Delete(PageSettingModel _params)
        {
            try
            {
                _uow.PageSettingRepo.ExcQuery("exec sp_PageSetting_Delete " +
                    "@PageSetting_ID" 

                    ,
                    new SqlParameter("PageSetting_ID", SqlDbType.Int)
                    {
                        Value = _params.PageSetting_ID
                    }
                    );

            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xóa" + ex.Message);
            }
        }
    }
}