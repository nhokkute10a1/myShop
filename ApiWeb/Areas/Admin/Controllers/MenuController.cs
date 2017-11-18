using DataModel.Menu;
using DataServices.MenuService;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using LibResponse;
using Newtonsoft.Json;

namespace ApiWeb.Areas.Admin.Controllers
{
    [RoutePrefix("api/Menu")]
    public class MenuController : ApiController
    {
        private readonly MenuService _menuService = new MenuService();

        /*==Lấy danh sách Menu==*/
        /// <summary>
        /// Theo linq
        /// </summary>
        /// <returns></returns>
        //[Route("api/GetListCategoryAsync")]
        //[HttpPost]
        //public async Task<HttpResponseMessage> GetListCategoryAsync()
        //{
        //    var Res = Request.CreateResponse();
        //    var Result = new Res();
        //    try
        //    {
        //        var data = await Task.Run(() => _categoryService.GetAll());
        //        if (data != null)
        //        {
        //            Result.Data = data;
        //            Result.Status = true;
        //            Result.Message = "Call API Success";
        //            Result.StatusCode = HttpStatusCode.OK;
        //        }
        //        else
        //        {
        //            Result.Data = null;
        //            Result.Status = false;
        //            Result.Message = "Không tìm dữ liệu";
        //            Result.StatusCode = HttpStatusCode.InternalServerError;
        //        }
        //        Res.Content = new StringContent(JsonConvert.SerializeObject(Result));
        //        return Res;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        /// <summary>
        /// Theo Store
        /// </summary>
        /// <returns></returns>
        [Route("GetListMenuAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> GetListMenuAsync()
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            try
            {
                var data = await Task.Run(() => _menuService.GetAll());
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

        [Route("GetAllByParentIdAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> GetAllByParentIdAsync(MenuModel _param)
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            try
            {
                var data = await Task.Run(() => _menuService.GetByIdParent(_param));
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
        [Route("CreateAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> CreateAsync(MenuModel _param)
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            try
            {
                if (_param != null)
                {
                    await Task.Run(() => _menuService.Insert(_param));
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
        public async Task<HttpResponseMessage> UpdateAsync(MenuModel _param)
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            try
            {
                if (_param != null)
                {
                    await Task.Run(() => _menuService.Update(_param));
                    Result.Status = true;
                    Result.Message = "Cập nhật thành công";
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
                Result.Message = "Có lỗi xảy ra trong quá trình cập nhật " + ex.Message;
                Result.StatusCode = HttpStatusCode.BadRequest;
                throw new Exception(ex.Message);
            }
        }

        /*==Xóa Category==*/
        [Route("DeleteAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> DeleteAsync(MenuModel _param)
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            try
            {
                if (_param != null)
                {
                    await Task.Run(() => _menuService.Delete(_param));
                    Result.Status = true;
                    Result.Message = "Xoá thành công";
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
                Result.Message = "Có lỗi xảy ra trong quá trình xoá " + ex.Message;
                Result.StatusCode = HttpStatusCode.BadRequest;
                throw new Exception(ex.Message);
            }
        }
    }
}