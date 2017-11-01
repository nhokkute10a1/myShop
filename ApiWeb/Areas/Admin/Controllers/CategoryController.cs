using DataModel.CategoryModel;
using DataServices.CategoryService;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using LibResponse;
using Newtonsoft.Json;
using System.Web.Http.Cors;
using System.IO;
using System.Web;
using System.Drawing;
using LibCommon;
using System.Drawing.Imaging;
using System.Web.Configuration;
using DataModel.UploadImage;

namespace ApiWeb.Areas.Admin.Controllers
{
    [RoutePrefix("api/Category")]
    /*---Fix(Access-Control-Allow-Origin)----*/
    [EnableCors("*", "*", "*")]
    public class CategoryController : ApiController
    {
        private readonly CategoryService _cateService = new CategoryService();

        #region[Define-Width-Hight]
        private string _Path = WebConfigurationManager.AppSettings["UploadFolder"];
        private int _Width = int.Parse(WebConfigurationManager.AppSettings["Width"]);
        private int _Height = int.Parse(WebConfigurationManager.AppSettings["Height"]);
        private int _WidthWeb = int.Parse(WebConfigurationManager.AppSettings["WidthWeb"]);
        private int _HeightWeb = int.Parse(WebConfigurationManager.AppSettings["HeightWeb"]);
        #endregion

        /*==Lấy toàn bộ danh sách Category==*/
        [Route("GetAllCateAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> GetAllCateAsync()
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            try
            {
                var data = await Task.Run(() => _cateService.GetAll());
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

        /*==Lấy danh sách Category theo id==*/
        [Route("GetAllByIdAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> GetAllByIdAsync(CategoryModel _params)
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            try
            {
                var data = await Task.Run(() => _cateService.GetById(_params));
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

        /*==Lấy toàn bộ danh sách Category theo ParentID==*/
        [Route("GetAllByIdParentAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> GetAllByIdParentAsync(CategoryModel _params)
        {
            try
            {
                var data = await Task.Run(() => _cateService.GetAllByParentId(_params));
                var Res = Request.CreateResponse();
                var Result = new Res();
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

        /*==Thêm mới Category==*/
        [Route("CreateAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> CreateAsync(CategoryModel _params)
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
                    if (!string.IsNullOrEmpty(_params.ImageBase64))
                    {
                        UploadImageWithOutResize("YouNameSystem", _params.ImageBase64, "admin", out StatusUpload, out MessageUpload, out OutputFile);
                        if (StatusUpload)
                        {
                            _params.Category_Icon = OutputFile;//Đường dẫn ảnh khi đã được xử lý thành ảnh  
                            _params.Category_Img = OutputFile;
                            await Task.Run(() => _cateService.Insert(_params));
                            Result.Status = true;
                            Result.Message = "Thêm mới thành công có ảnh";
                            Result.StatusCode = HttpStatusCode.OK;
                            //if (_params.Msg == 0)
                            //{
                            //    Result.Status = false;
                            //    Result.Message = "Có lỗi xảy ra trong quá trình cập nhật";
                            //    Result.StatusCode = HttpStatusCode.BadRequest;
                            //}
                            //else
                            //{
                            //    Result.Status = true;
                            //    Result.Message = "Cập nhật thành công thông tin";
                            //    Result.StatusCode = HttpStatusCode.OK;
                            //}
                        }
                    }
                    else
                    {
                        await Task.Run(() => _cateService.Insert(_params));
                        Result.Status = true;
                        Result.Message = "Thêm mới thành công";
                        Result.StatusCode = HttpStatusCode.OK;
                        //if (_params.Msg == 0)
                        //{
                        //    Result.Status = false;
                        //    Result.Message = "Có lỗi xảy ra trong quá trình cập nhật";
                        //    Result.StatusCode = HttpStatusCode.BadRequest;
                        //}
                        //else
                        //{
                        //    Result.Status = true;
                        //    Result.Message = "Cập nhật thành công thông tin";
                        //    Result.StatusCode = HttpStatusCode.OK;
                        //}
                    }
                    //await Task.Run(() => _cateService.Insert(_param));
                    //Result.Status = true;
                    //Result.Message = "Thêm mới thành công";
                    //Result.StatusCode = HttpStatusCode.OK;
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

        /*==Cập nhập Category==*/
        [Route("UpdateAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> UpdateAsync(CategoryModel _param)
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            var query = _cateService.GetById(_param);
            var StatusUpload = false;
            var MessageUpload = string.Empty;
            var OutputFile = string.Empty;
            try
            {
                if (_param != null)
                {
                    if (string.IsNullOrEmpty(_param.ImageBase64))
                    {
                        _param.Category_Icon = query.Category_Icon;
                        _param.Category_Img = query.Category_Img;
                        await Task.Run(() => _cateService.Update(_param));
                        Result.Status = true;
                        Result.Message = "Cập nhập thành công";
                        Result.StatusCode = HttpStatusCode.OK;
                    }
                    else
                    {
                        //Viet ham upload vao day
                        UploadImageWithOutResize("YouNameSystem", _param.ImageBase64, "admin", out StatusUpload, out MessageUpload, out OutputFile);
                        if (StatusUpload)
                        {
                            _param.Category_Icon = OutputFile;//Đường dẫn ảnh khi đã được xử lý thành ảnh  
                            _param.Category_Img = OutputFile;
                            await Task.Run(() => _cateService.Update(_param));
                            Result.Status = true;
                            Result.Message = "Cập nhập thành công có ảnh";
                            Result.StatusCode = HttpStatusCode.OK;

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

        /*==Xóa Category==*/
        [Route("DeleteAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> DeleteAsync(CategoryModel _param)
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            try
            {
                if (_param != null)
                {
                    await Task.Run(() => _cateService.Delete(_param));
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



        /*==Test Update==*/
        [Route("UploadImageAsync")]
        [HttpPost]
        public HttpResponseMessage UploadImageAsync(AvatarProfile model)
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            var FolderName = "YouNameSystem";
            var FileNameAvatar = string.Empty;
            try
            {
                if (!Directory.Exists(HttpContext.Current.Server.MapPath(_Path + FolderName)))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(_Path + FolderName));
                    if (!string.IsNullOrEmpty(model.ImageBase64String))
                    {
                        using (Image image = Common.Base64ToImage(model.ImageBase64String))
                        {
                            string strFileName = _Path + FolderName + "/" + model.UserName + "_" + Guid.NewGuid() + ".jpg";
                            var iresize = Common.ResizeImage(image, _Width, _Height);
                            iresize.Save(HttpContext.Current.Server.MapPath(strFileName), ImageFormat.Jpeg);
                            FileNameAvatar = strFileName;

                            Result.Status = true;
                            Result.Message = "Tải ảnh lên thành công";
                            Result.StatusCode = HttpStatusCode.OK;
                        };
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(model.ImageBase64String))
                    {
                        using (Image image = Common.Base64ToImage(model.ImageBase64String))
                        {
                            string strFileName = _Path + FolderName + "/" + model.UserName + "_" + Guid.NewGuid() + ".jpg";
                            var iresize = Common.ResizeImage(image, _Width, _Height);
                            iresize.Save(HttpContext.Current.Server.MapPath(strFileName), ImageFormat.Jpeg);
                            FileNameAvatar = strFileName;

                            Result.Status = true;
                            Result.Message = "Tải ảnh lên thành công";
                            Result.StatusCode = HttpStatusCode.OK;
                        };
                    }
                }
                Res.Content = new StringContent(JsonConvert.SerializeObject(Result));
                return Res;
            }
            catch (Exception ex)
            {
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