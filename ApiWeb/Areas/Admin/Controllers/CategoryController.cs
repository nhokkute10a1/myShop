using DataModel.CategoryModel;
using DataServices.CategoryService;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using LibResponse;
using Newtonsoft.Json;

namespace ApiWeb.Areas.Admin.Controllers
{
    [RoutePrefix("api/Category")]
    public class CategoryController : ApiController
    {
        private readonly CategoryService _cateService = new CategoryService();

        /*==Lấy toàn bộ danh sách Category==*/
        [Route("GetAllCateAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> GetAllCateAsync()
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            try
            {
                var data = await Task.Run(()=>_cateService.GetAll());
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
            catch(Exception ex)
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
                if(data!=null)
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
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /*==Thêm mới Category==*/
        [Route("CreateAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> CreateAsync(CategoryModel _param)
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            try
            {
                if (_param != null)
                {
                    await Task.Run(() => _cateService.Insert(_param));
                    Result.Status = true;
                    Result.Message = "Thêm mới thành công";
                    Result.StatusCode = HttpStatusCode.OK;
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
            try
            {
                if (_param != null)
                {
                    await Task.Run(() => _cateService.Update(_param));
                    Result.Status = true;
                    Result.Message = "Cập nhập thành công";
                    Result.StatusCode = HttpStatusCode.OK;
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
    }
}