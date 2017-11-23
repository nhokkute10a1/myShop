using DataModel.UserProfileModel;
using DataServices.UserProfileService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using LibResponse;
using Newtonsoft.Json;
using System.Web.Http.Cors;
using DataModel.PagingModel;
using System.Web.Configuration;
using System.Web;
using System.IO;
using LibCommon;
using System.Drawing;
using System.Drawing.Imaging;
using ApiWeb.Authentications;

namespace ApiWeb.Areas.Admin.Controllers
{
    [RoutePrefix("api/UserProfile")]
    /*---Fix(Access-Control-Allow-Origin)----*/
    [EnableCors("*", "*", "*")]
    public class UserProfileController : ApiController
    {
        private readonly UserProfileService _userProfileService = new UserProfileService();
        private readonly ServiceLogin _serviceLogin = new ServiceLogin();

        #region[Define-Width-Hight]
        private string _Path = WebConfigurationManager.AppSettings["UploadFolder"];
        private int _Width = int.Parse(WebConfigurationManager.AppSettings["Width"]);
        private int _Height = int.Parse(WebConfigurationManager.AppSettings["Height"]);
        private int _WidthWeb = int.Parse(WebConfigurationManager.AppSettings["WidthWeb"]);
        private int _HeightWeb = int.Parse(WebConfigurationManager.AppSettings["HeightWeb"]);
        #endregion


        /*==Đăng Nhập==*/
        #region[Login]
        /*==Lấy danh sách người dùng==*/
        [Route("LoginAsync")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<HttpResponseMessage> LoginAsync(UserProfileModel _params)
        {
            var status = false;
            var Message = string.Empty;
            object Data = null;
            var Res = Request.CreateResponse();
            var Result = new Res();
            try
            {
                await Task.Run(() => _serviceLogin.LoginService(_params, out status, out Message, out Data));
                Result.Status = status;
                Result.Message = Message;
                Result.StatusCode = HttpStatusCode.OK;
                Result.Data = Data;
                Res.Content = new StringContent(JsonConvert.SerializeObject(Result));
                return Res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion


        /*==Get All ==*/
        [Route("GetAllAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> GetAllAsync(PagingModel _params)
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            try
            {
                var data = await Task.Run(() => _userProfileService.GetAll(_params));
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

        /*==Lấy danh sách  theo id==*/
        [Route("GetByIdAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> GetByIdAsync(UserProfileModel _params)
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            try
            {
                var data = await Task.Run(() => _userProfileService.GetById(_params));
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
        /*===Thêm mới===*/
        [Route("CreateAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> CreateAsync(UserProfileModel _params)
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
                    if (string.IsNullOrEmpty(_params.UserProfile_FullName))
                    {
                        Result.Status = false;
                        Result.Message = "Tên đầy đủ không được trống " + _params.UserProfile_FullName;
                        Result.StatusCode = HttpStatusCode.BadRequest;
                    }
                    else if (_params.UserProfile_Age < 0 || _params.UserProfile_Age == null)
                    {
                        Result.Status = false;
                        Result.Message = "Tuổi không được trống " + _params.UserProfile_Age;
                        Result.StatusCode = HttpStatusCode.BadRequest;
                    }
                    else if (string.IsNullOrEmpty(_params.UserProfile_Phone))
                    {
                        Result.Status = false;
                        Result.Message = "SĐT không được trống " + _params.UserProfile_Phone;
                        Result.StatusCode = HttpStatusCode.BadRequest;
                    }
                    else if (string.IsNullOrEmpty(_params.UserProfile_Email))
                    {
                        Result.Status = false;
                        Result.Message = "Email không được trống " + _params.UserProfile_Email;
                        Result.StatusCode = HttpStatusCode.BadRequest;
                    }
                    else if (string.IsNullOrEmpty(_params.UserProfile_Pass))
                    {
                        Result.Status = false;
                        Result.Message = "Mật khẩu không được trống " + _params.UserProfile_Pass;
                        Result.StatusCode = HttpStatusCode.BadRequest;
                    }
                    else
                    {

                        if (!string.IsNullOrEmpty(_params.ImageBase64))
                        {
                            UploadImageWithOutResize("YouNameSystem", _params.ImageBase64, "admin", out StatusUpload, out MessageUpload, out OutputFile);
                            if (StatusUpload)
                            {
                                _params.UserProfile_Avatar = OutputFile;//Đường dẫn ảnh khi đã được xử lý thành ảnh  
                                await Task.Run(() => _userProfileService.Insert(_params));
                                Result.Status = true;
                                Result.Message = "Thêm mới thành công có ảnh";
                                Result.StatusCode = HttpStatusCode.OK;

                            }
                        }
                        else
                        {
                            await Task.Run(() => _userProfileService.Insert(_params));
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

        /*===Cập nhập===*/
        [Route("UpdateAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> UpdateAsync(UserProfileModel _params)
        {
            var Res = Request.CreateResponse();
            var StatusUpload = false;
            var query = _userProfileService.GetById(_params);
            var MessageUpload = string.Empty;
            var OutputFile = string.Empty;
            var Result = new Res();
            try
            {
                if (_params != null)
                {
                    if (string.IsNullOrEmpty(_params.UserProfile_FullName))
                    {
                        Result.Status = false;
                        Result.Message = "Tên đầy đủ không được trống " + _params.UserProfile_FullName;
                        Result.StatusCode = HttpStatusCode.BadRequest;
                    }
                    else if (_params.UserProfile_Age < 0 || _params.UserProfile_Age == null)
                    {
                        Result.Status = false;
                        Result.Message = "Tuổi không được trống " + _params.UserProfile_Age;
                        Result.StatusCode = HttpStatusCode.BadRequest;
                    }
                    else if (string.IsNullOrEmpty(_params.UserProfile_Phone))
                    {
                        Result.Status = false;
                        Result.Message = "SĐT không được trống " + _params.UserProfile_Phone;
                        Result.StatusCode = HttpStatusCode.BadRequest;
                    }
                    else if (string.IsNullOrEmpty(_params.UserProfile_Email))
                    {
                        Result.Status = false;
                        Result.Message = "Email không được trống " + _params.UserProfile_Email;
                        Result.StatusCode = HttpStatusCode.BadRequest;
                    }
                    else
                    {

                        if (string.IsNullOrEmpty(_params.ImageBase64))
                        {
                            _params.UserProfile_Avatar = query.UserProfile_Avatar;
                            await Task.Run(() => _userProfileService.Update(_params));
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
                                _params.UserProfile_Avatar = OutputFile;//Đường dẫn ảnh khi đã được xử lý thành ảnh  
                                await Task.Run(() => _userProfileService.Update(_params));
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

        /*===Xóa===*/
        [Route("DeleteAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> DeleteAsync(UserProfileModel _param)
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            try
            {
                if (_param != null)
                {
                    await Task.Run(() => _userProfileService.Delete(_param));
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
