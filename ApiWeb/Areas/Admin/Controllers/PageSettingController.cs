using DataServices.PageSettingService;
using LibCommon;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Cors;
using LibResponse;
using System.Net;
using Newtonsoft.Json;
using DataModel.PageSettingModel;

namespace ApiWeb.Areas.Admin.Controllers
{
    [RoutePrefix("api/PageSetting")]
    /*---Fix(Access-Control-Allow-Origin)----*/
    [EnableCors("*", "*", "*")]
    public class PageSettingController : ApiController
    {
        private readonly PageSettingService _pageSettingService = new PageSettingService();
        #region[Define-Width-Hight]
        private string _Path = WebConfigurationManager.AppSettings["UploadFolder"];
        private int _Width = int.Parse(WebConfigurationManager.AppSettings["Width"]);
        private int _Height = int.Parse(WebConfigurationManager.AppSettings["Height"]);
        private int _WidthWeb = int.Parse(WebConfigurationManager.AppSettings["WidthWeb"]);
        private int _HeightWeb = int.Parse(WebConfigurationManager.AppSettings["HeightWeb"]);
        #endregion

        /*==Get All==*/
        [Route("GetAllAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> GetAllAsync()
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            try
            {
                var data = await Task.Run(() => _pageSettingService.GetAll());
                if (data != null)
                {
                    Result.Data = data;
                    Result.Status = true;
                    Result.Message = "Call API Success";
                    Result.StatusCode = HttpStatusCode.OK;
                }
                else
                {
                    Result.Data = null;
                    Result.Status = false;
                    Result.Message = "Không tìm thấy dữ liệu";
                    Result.StatusCode = HttpStatusCode.InternalServerError;
                }
                Res.Content = new StringContent(JsonConvert.SerializeObject(Result));
                return Res;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /*==Get by ID==*/
        [Route("GetAllByIdAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> GetAllByIdAsync(PageSettingModel _params)
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            try
            {
                var data = await Task.Run(() => _pageSettingService.GetById(_params));
                if (data != null)
                {
                    Result.Data = data;
                    Result.Status = true;
                    Result.Message = "Call API Success";
                    Result.StatusCode = HttpStatusCode.OK;
                }
                else
                {
                    Result.Data = null;
                    Result.Status = false;
                    Result.Message = "Không tìm thấy dữ liệu";
                    Result.StatusCode = HttpStatusCode.InternalServerError;
                }
                Res.Content = new StringContent(JsonConvert.SerializeObject(Result));
                return Res;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /*==Insert==*/
        [Route("CreateAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> CreateAsync(PageSettingModel _params)
        {
            var Res = Request.CreateResponse();
            var StatusUpload = false;
            var MessageUpload = string.Empty;
            var OutputFile = string.Empty;
            var Result = new Res();

            try
            {
                if (_params != null)
                {
                    if (string.IsNullOrEmpty(_params.PageSetting_NameVN))
                    {
                        Result.Status = false;
                        Result.Message = "Tiêu đề tiếng việt không được trống " + _params.PageSetting_NameVN;
                        Result.StatusCode = HttpStatusCode.BadRequest;
                    }
                    else if (string.IsNullOrEmpty(_params.PageSetting_NameEN))
                    {
                        Result.Status = false;
                        Result.Message = "Tên tiêu đề tiếng anh không được trống " + _params.PageSetting_NameEN;
                        Result.StatusCode = HttpStatusCode.BadRequest;
                    }
                    else if (string.IsNullOrEmpty(_params.PageSetting_Rewrite))
                    {
                        Result.Status = false;
                        Result.Message = "Đường dẫn thân thiện không được trống " + _params.PageSetting_Rewrite;
                        Result.StatusCode = HttpStatusCode.BadRequest;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(_params.ImageBase64))
                        {
                            UploadImageWithOutResize("YouNameSystem", _params.ImageBase64, "admin", out StatusUpload, out MessageUpload, out OutputFile);
                            if (StatusUpload)
                            {
                                _params.PageSetting_Img = OutputFile;
                                await Task.Run(() => _pageSettingService.Insert(_params));
                                Result.Status = true;
                                Result.Message = "Thêm mới thành công có ảnh";
                                Result.StatusCode = HttpStatusCode.OK;
                            }
                        }
                        else
                        {
                            await Task.Run(() => _pageSettingService.Insert(_params));
                            Result.Status = true;
                            Result.Message = "Thêm mới thành công";
                            Result.StatusCode = HttpStatusCode.OK;
                        }


                    }
                }
                else
                {
                    Result.Status = false;
                    Result.Message = "Thêm mới thất bại";
                    Result.StatusCode = HttpStatusCode.BadRequest;
                }
                Res.Content = new StringContent(JsonConvert.SerializeObject(Result));
                return Res;
            }
            catch (Exception ex)
            {
                Result.Status = false;
                Result.Message = "Có lỗi xảy ra trong quá trình thêm mới " + ex.Message;
                Result.StatusCode = HttpStatusCode.BadRequest;
                throw new Exception(ex.Message);
            }
        }

        /*===Update===*/
        [Route("UpdateAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> UpdateAsync(PageSettingModel _params)
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            var query = _pageSettingService.GetById(_params);
            var StatusUpload = false;
            var MessageUpload = string.Empty;
            var OutputFile = string.Empty;
            try
            {

                if (_params != null)
                {
                    if (string.IsNullOrEmpty(_params.PageSetting_NameVN))
                    {
                        Result.Status = false;
                        Result.Message = "Tiêu đề tiếng việt không được trống " + _params.PageSetting_NameVN;
                        Result.StatusCode = HttpStatusCode.BadRequest;
                    }
                    else if (string.IsNullOrEmpty(_params.PageSetting_NameEN))
                    {
                        Result.Status = false;
                        Result.Message = "Tên tiêu đề tiếng anh không được trống " + _params.PageSetting_NameEN;
                        Result.StatusCode = HttpStatusCode.BadRequest;
                    }
                    else if (string.IsNullOrEmpty(_params.PageSetting_Rewrite))
                    {
                        Result.Status = false;
                        Result.Message = "Đường dẫn thân thiện không được trống " + _params.PageSetting_Rewrite;
                        Result.StatusCode = HttpStatusCode.BadRequest;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(_params.ImageBase64))
                        {
                            _params.PageSetting_Img = query.PageSetting_Img;
                            await Task.Run(() => _pageSettingService.Update(_params));
                            Result.Status = true;
                            Result.Message = "Cập nhập thành công";
                            Result.StatusCode = HttpStatusCode.OK;
                        }
                        else
                        {
                            //Viet ham upload vao day
                            UploadImageWithOutResize("YouNameSystem", _params.ImageBase64, "admin", out StatusUpload, out MessageUpload, out OutputFile);
                            if (StatusUpload)
                            {
                                _params.PageSetting_Img = OutputFile;//Đường dẫn ảnh khi đã được xử lý thành ảnh  
                                await Task.Run(() => _pageSettingService.Update(_params));
                                Result.Status = true;
                                Result.Message = "Cập nhập thành công có ảnh";
                                Result.StatusCode = HttpStatusCode.OK;

                            }
                        }
                    }
                }
                else
                {
                    Result.Status = false;
                    Result.Message = "Cập nhập thất bại";
                    Result.StatusCode = HttpStatusCode.BadRequest;
                }
                Res.Content = new StringContent(JsonConvert.SerializeObject(Result));
                return Res;
            }
            catch (Exception ex)
            {
                Result.Status = false;
                Result.Message = "Có lỗi xảy ra trong quá trình cập nhập " + ex.Message;
                Result.StatusCode = HttpStatusCode.BadRequest;
                throw new Exception(ex.Message);
            }
        }

        /*===Delete===*/
        [Route("DeleteAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> DeleteAsync(PageSettingModel _param)
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            try
            {
                if (_param != null)
                {
                    await Task.Run(() => _pageSettingService.Delete(_param));
                    Result.Status = true;
                    Result.Message = "Xóa thành công";
                    Result.StatusCode = HttpStatusCode.OK;
                }
                else
                {
                    Result.Status = false;
                    Result.Message = "Xóa thất bại";
                    Result.StatusCode = HttpStatusCode.BadRequest;
                }
                Res.Content = new StringContent(JsonConvert.SerializeObject(Result));
                return Res;
            }
            catch (Exception ex)
            {
                Result.Status = false;
                Result.Message = "Có lỗi xảy ra trong quá trình xóa " + ex.Message;
                Result.StatusCode = HttpStatusCode.BadRequest;
                throw new Exception(ex.Message);
            }
        }

        /*===Upload ảnh ===*/
        #region[Upload-Image]

        private void UploadImage(string FolderName, string ImageBase64String, string UserName, out bool StatusUpload, out string MessageUpload, out string OutputFile)
        {
            MessageUpload = string.Empty;
            OutputFile = string.Empty;
            StatusUpload = false;
            var FileNameAvatar = string.Empty;
            if (!Directory.Exists(HttpContext.Current.Server.MapPath(_Path + FolderName)))
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(_Path + FolderName));
                if (!string.IsNullOrEmpty(ImageBase64String))
                {
                    using (Image image = Common.Base64ToImage(ImageBase64String))
                    {
                        string strFileName = _Path + FolderName + "/" + UserName + "_" + Guid.NewGuid() + ".jpg";
                        var iresize = Common.ResizeImage(image, _Width, _Height);
                        iresize.Save(HttpContext.Current.Server.MapPath(strFileName), ImageFormat.Jpeg);
                        FileNameAvatar = strFileName;
                        OutputFile = strFileName;
                        StatusUpload = true;
                        MessageUpload = "Tải ảnh lên thành công";
                    };
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(ImageBase64String))
                {
                    using (Image image = Common.Base64ToImage(ImageBase64String))
                    {
                        string strFileName = _Path + FolderName + "/" + UserName + "_" + Guid.NewGuid() + ".jpg";
                        var iresize = Common.ResizeImage(image, _Width, _Height);
                        iresize.Save(HttpContext.Current.Server.MapPath(strFileName), ImageFormat.Jpeg);
                        FileNameAvatar = strFileName;
                        OutputFile = strFileName;
                        StatusUpload = true;
                        MessageUpload = "Tải ảnh lên thành công";
                    };
                }
            }
        }

        private void UploadImageWithOutResize(string FolderName, string ImageBase64String, string UserName, out bool StatusUpload, out string MessageUpload, out string OutputFile)
        {
            MessageUpload = string.Empty;
            OutputFile = string.Empty;
            StatusUpload = false;
            var FileNameAvatar = string.Empty;
            if (!Directory.Exists(HttpContext.Current.Server.MapPath(_Path + FolderName)))
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(_Path + FolderName));
                if (!string.IsNullOrEmpty(ImageBase64String))
                {
                    using (Image image = Common.Base64ToImage(ImageBase64String))
                    {
                        string strFileName = _Path + FolderName + "/" + UserName + "_" + Guid.NewGuid() + ".jpg";
                        var iresize = Common.ResizeImage(image, _WidthWeb, _HeightWeb); ;
                        iresize.Save(HttpContext.Current.Server.MapPath(strFileName), ImageFormat.Jpeg);
                        FileNameAvatar = strFileName;
                        OutputFile = strFileName;
                        StatusUpload = true;
                        MessageUpload = "Tải ảnh lên thành công";
                    };
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(ImageBase64String))
                {
                    using (Image image = Common.Base64ToImage(ImageBase64String))
                    {
                        string strFileName = _Path + FolderName + "/" + UserName + "_" + Guid.NewGuid() + ".jpg";
                        var iresize = Common.ResizeImage(image, _WidthWeb, _HeightWeb); ;
                        iresize.Save(HttpContext.Current.Server.MapPath(strFileName), ImageFormat.Jpeg);
                        FileNameAvatar = strFileName;
                        OutputFile = strFileName;
                        StatusUpload = true;
                        MessageUpload = "Tải ảnh lên thành công";
                    };
                }
            }
        }

        #endregion
    }
}