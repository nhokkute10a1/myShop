using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using LibResponse;
using DataServices;
using DataModel;

namespace ApiWeb.Areas.Admin.Controllers
{
    public class AdminCategoryController : ApiController
    {

        private readonly CategoryService _categoryService = new CategoryService();
        /*==Lấy danh sách Category==*/
        /// <summary>
        /// Theo linq
        /// </summary>
        /// <returns></returns>
        [Route("api/GetListCategoryAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> GetListCategoryAsync()
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            try
            {
                var data = await Task.Run(() => _categoryService.GetAll());
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
                    Result.Message = "Không tìm dữ liệu";
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

        /// <summary>
        /// Theo Store
        /// </summary>
        /// <returns></returns>
        [Route("api/GetListCategoryStoreAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> GetListCategoryStoreAsync()
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            try
            {
                var data = await Task.Run(() => _categoryService.GetAll_Store());
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
                    Result.Message = "Không tìm dữ liệu";
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
        [Route("api/AddCateAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> AddCateAsync(CategoryModelAdd categoryModel)
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            try
            {
                if(categoryModel != null)
                {
                   await Task.Run(() => _categoryService.Add(categoryModel));
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
    }
}