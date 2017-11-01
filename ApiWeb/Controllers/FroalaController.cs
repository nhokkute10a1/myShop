using Newtonsoft.Json;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Cors;
namespace EShopPoCo.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("FroalaApi/api")]
    public class FroalaController : ApiController
    {
        private readonly string _pathImg = WebConfigurationManager.AppSettings["UploadImage"];
        private readonly string _pathFile = WebConfigurationManager.AppSettings["Uploadfile"];
        private readonly string _pathVideo = WebConfigurationManager.AppSettings["Uploadvideo"];

        #region[Image]
        /*--Image-Manager--*/
        [Route("LoadImagesAsync")]
        [HttpGet]
        public IHttpActionResult LoadImagesAsync()
        {
            string uploadPath = _pathImg;
            try
            {
                var data = FroalaEditor.Image.List(uploadPath, null, true);
                return Json(data);
            }
            catch (Exception e)
            {
                return Json(e);
            }
        }
        /*--Upload-Image--*/
        [Route("UploadImagesAsync")]
        [HttpPost]
        public IHttpActionResult UploadImagesAsync()
        {
            string uploadPath = _pathImg;
            try
            {
                FroalaEditor.ImageOptions options = new FroalaEditor.ImageOptions
                {
                    Fieldname = "file",
                    Validation = new FroalaEditor.ImageValidation(new string[] { "gif", "jpeg", "jpg", "png", "svg", "blob" }, new string[] { "image/gif", "image/jpeg", "image/pjpeg", "image/x-png", "image/png", "image/svg+xml" })
                };
                var response = FroalaEditor.Image.Upload(HttpContext.Current, uploadPath, options, true);
                //var obj = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + response;
                return Json(response);
            }
            catch (Exception e)
            {
                return Json(e);
            }
        }
        /*--Delete-Image--*/
        [Route("DeleteImagesAsync")]
        [HttpPost]
        public IHttpActionResult DeleteImagesAsync()
        {
            string uploadPath = _pathImg;
            try
            {
                FroalaEditor.Image.Delete(HttpContext.Current.Request.Form["src"],false);
                return Json(true);
            }
            catch (Exception e)
            {
                return Json(e);
            }
        }
        #endregion

        #region[File]
        [Route("UploadFileAsync")]
        [HttpPost]
        public IHttpActionResult UploadFileAsync()
        {
            string uploadPath = _pathFile;
            FroalaEditor.FileOptions options = new FroalaEditor.FileOptions
            {
                Fieldname = "file",
                Validation = new FroalaEditor.FileValidation(
                    new string[]
                    {
                        "txt",
                        "pdf",
                        "doc",
                        "docx",
                        "xls",
                        "xlsx"
                    },
                    new string[]
                    {
                        "text/plain",
                        "application/msword",
                        "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                        "application/x-pdf",
                        "application/pdf",
                        "application/x-excel",
                        "application/xls",
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "application/vnd.ms-powerpoint",
                        "application/vnd.openxmlformats-officedocument.presentationml.presentation"
                    })
            };
            try
            {
                return Json(FroalaEditor.File.Upload(System.Web.HttpContext.Current, uploadPath, options));
            }
            catch (Exception e)
            {
                return Json(e);
            }
        }
        #endregion

        #region[Video]
        [Route("UploadVideoAsync")]
        [HttpPost]
        public IHttpActionResult UploadVideoAsync()
        {
            string message = string.Empty;
            var status = false;
            if (HttpContext.Current.Request.Files["file"] != null)
            {
                var MyFile = HttpContext.Current.Request.Files["file"];
                /*--Setting-location-upload-file--*/
                string TargetLocation = HttpContext.Current.Server.MapPath(_pathVideo);
                try
                {
                    /*--Check-File-Exist--*/
                    if (MyFile.ContentLength > 0)
                    {
                        /*--Get File Extension--*/
                        string Extension = Path.GetExtension(MyFile.FileName);
                        /*--Determining file name. You can format it as you wish--*/
                        string FileName = Path.GetFileName(MyFile.FileName);
                        FileName = Guid.NewGuid().ToString().Substring(0, 8);
                        /*--Determining file size--*/
                        int FileSize = MyFile.ContentLength;
                        /*--Creating a byte array corresponding to file size--*/
                        byte[] FileByteArray = new byte[FileSize];
                        /*--Basic validation for file extension--*/
                        string[] AllowedExtension = { ".mp4", ".webm", ".ogg" };
                        string[] AllowedMimeType = { "video/mp4", "video/webm", "video/ogg" };
                        if (AllowedExtension.Contains(Extension) && AllowedMimeType.Contains(MimeMapping.GetMimeMapping(MyFile.FileName)))
                        {
                            /*--Posted file is being pushed into byte array--*/
                            MyFile.InputStream.Read(FileByteArray, 0, FileSize);
                            /*--Uploading properly formatted file to server--*/
                            MyFile.SaveAs(TargetLocation + FileName + Extension);
                            string json = "";
                            Hashtable resp = new Hashtable();
                            string urlPath = MapURL(TargetLocation) + FileName + Extension;
                            /*--Make the response an json object--*/
                            resp.Add("link", urlPath);
                            json = JsonConvert.SerializeObject(resp);
                            /*--Clear and send the response back to the browser--*/
                            HttpContext.Current.Response.Clear();
                            HttpContext.Current.Response.ContentType = "application/json; charset=utf-8";
                            HttpContext.Current.Response.Write(json);
                            HttpContext.Current.Response.End();
                            status = true;
                            message = "Tải tệp tin thành công";
                        }
                        else
                        {
                            status = false;
                            message = "Tệp tin không đúng định dạng";
                        }
                    }
                }
                catch (Exception ex)
                {
                    status = false;
                    message = ex.Message;
                }
            }
            return Json(new { status, message });
        }
        #endregion

        /*--Common--*/
        private string MapURL(string path)
        {
            string appPath = HttpContext.Current.Server.MapPath("/").ToLower();
            return string.Format("/{0}", path.ToLower().Replace(appPath, "").Replace(@"\", "/"));
        }

    }
    public class ImageList { public string Url { get; set; } }
}