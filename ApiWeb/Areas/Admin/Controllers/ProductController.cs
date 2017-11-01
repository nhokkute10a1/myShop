using DataModel.ProductModel;
using DataServices.ProductService;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using LibResponse;
using System.Net;
using System;
using Newtonsoft.Json;
using System.Web.Http.Cors;
using System.Web.Configuration;
using System.IO;
using System.Web;
using System.Drawing;
using LibCommon;
using System.Drawing.Imaging;

namespace ApiWeb.Areas.Admin.Controllers
{
    [RoutePrefix("api/Product")]
    /*---Fix(Access-Control-Allow-Origin)----*/
    [EnableCors("*", "*", "*")]
    public class ProductController : ApiController
    {
        private readonly ProductService _productService = new ProductService();

        #region[Define-Width-Hight]
        private string _Path = WebConfigurationManager.AppSettings["UploadFolder"];
        private int _Width = int.Parse(WebConfigurationManager.AppSettings["Width"]);
        private int _Height = int.Parse(WebConfigurationManager.AppSettings["Height"]);
        private int _WidthWeb = int.Parse(WebConfigurationManager.AppSettings["WidthWeb"]);
        private int _HeightWeb = int.Parse(WebConfigurationManager.AppSettings["HeightWeb"]);
        #endregion

        /*===Lấy toàn bộ danh sách sản phẩm===*/
        [Route("GetAllProductAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> GetAllProductAsync()
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            try
            {
                var data = await Task.Run(() => _productService.GetAll());
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

        /*===Lấy toàn bộ danh sách sản phẩm theo id===*/
        [Route("GetAllByIdAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> GetAllByIdAsync(ProductModel _param)
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            try
            {
                var data = await Task.Run(() => _productService.GetById(_param));
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

        /*===Thêm mới Product===*/
        [Route("CreateAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> CreateAsync(ProductModel _params)
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
                    if (string.IsNullOrEmpty(_params.Product_Code.Trim()))
                    {
                        Result.Status = false;
                        Result.Message = "Mã sản phẩm không được trống " + _params.Product_Code;
                        Result.StatusCode = HttpStatusCode.BadRequest;
                    }
                    else if (string.IsNullOrEmpty(_params.Product_NameVN.Trim()))
                    {
                        Result.Status = false;
                        Result.Message = "Tên sản phẩm không được trống " + _params.Product_NameVN;
                        Result.StatusCode = HttpStatusCode.BadRequest;
                    }
                    else if (_params.Category_Parent_ID == 0 || _params.Category_Parent_ID <= -1)
                    {
                        Result.Status = false;
                        Result.Message = "Danh mục không được trống " + _params.Category_Parent_ID;
                        Result.StatusCode = HttpStatusCode.BadRequest;
                    }
                    else if (string.IsNullOrEmpty(_params.Product_SearchVN.Trim()))
                    {
                        Result.Status = false;
                        Result.Message = "Tìm kiếm tiếng việt không được trống " + _params.Product_SearchVN;
                        Result.StatusCode = HttpStatusCode.BadRequest;
                    }
                    else
                    {

                        if (!string.IsNullOrEmpty(_params.ImageBase64))
                        {
                            UploadImageWithOutResize("YouNameSystem", _params.ImageBase64, "admin", out StatusUpload, out MessageUpload, out OutputFile);
                            if (StatusUpload)
                            {
                                _params.Product_Img = OutputFile;//Đường dẫn ảnh khi đã được xử lý thành ảnh  
                                await Task.Run(() => _productService.Insert(_params));
                                Result.Status = true;
                                Result.Message = "Thêm mới thành công có ảnh";
                                Result.StatusCode = HttpStatusCode.OK;

                            }
                        }
                        else
                        {
                            await Task.Run(() => _productService.Insert(_params));
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

        /*===Cập Nhập Product===*/
        [Route("UpdateAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> UpdateAsync(ProductModel _params)
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            var query = _productService.GetById(_params);
            var StatusUpload = false;
            var MessageUpload = string.Empty;
            var OutputFile = string.Empty;
            try
            {

                if (_params != null)
                {
                    //if (string.IsNullOrEmpty(_params.Product_Code))
                    //{
                    //    Result.Status = false;
                    //    Result.Message = "Mã sản phẩm không được trống " + _params.Product_Code;
                    //    Result.StatusCode = HttpStatusCode.BadRequest;
                    //}
                    //else if (string.IsNullOrEmpty(_params.Product_NameVN))
                    //{
                    //    Result.Status = false;
                    //    Result.Message = "Tên sản phẩm không được trống " + _params.Product_NameVN;
                    //    Result.StatusCode = HttpStatusCode.BadRequest;
                    //}
                    //else if (_params.Category_Parent_ID == 0 || _params.Category_Parent_ID <= -1)
                    //{
                    //    Result.Status = false;
                    //    Result.Message = "Danh mục không được trống " + _params.Category_Parent_ID;
                    //    Result.StatusCode = HttpStatusCode.BadRequest;
                    //}
                    //else if (string.IsNullOrEmpty(_params.Product_SearchVN))
                    //{
                    //    Result.Status = false;
                    //    Result.Message = "Tìm kiếm tiếng việt không được trống " + _params.Product_SearchVN;
                    //    Result.StatusCode = HttpStatusCode.BadRequest;
                    //}
                    //else
                    //{
                        if (string.IsNullOrEmpty(_params.ImageBase64))
                        {
                            _params.Product_Img = query.Product_Img;
                            await Task.Run(() => _productService.Update(_params));
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
                                _params.Product_Img = OutputFile;//Đường dẫn ảnh khi đã được xử lý thành ảnh  
                                await Task.Run(() => _productService.Update(_params));
                                Result.Status = true;
                                Result.Message = "Cập nhập thành công có ảnh";
                                Result.StatusCode = HttpStatusCode.OK;

                            }
                        }
                    //}
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

        /*===Xóa Product===*/
        [Route("DeleteAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> DeleteAsync(ProductModel _param)
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            try
            {
                if (_param != null)
                {
                    await Task.Run(() => _productService.Delete(_param));
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