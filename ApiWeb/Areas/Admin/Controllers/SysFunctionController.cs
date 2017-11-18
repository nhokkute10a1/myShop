using DataModel.SysFunctionGroupModel;
using DataModel.SysFunctionModel;
using DataServices.SysFunctionService;
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

namespace ApiWeb.Areas.Admin.Controllers
{
    [RoutePrefix("api/SysFunction")]
    /*---Fix(Access-Control-Allow-Origin)----*/
    [EnableCors("*", "*", "*")]
    public class SysFunctionController : ApiController
    {
        private readonly SysFunctionService _sysFunctionService = new SysFunctionService();

        /*==Get All ==*/
        [Route("GetAllAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> GetAllAsync(PagingModel _params)
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            try
            {
                var data = await Task.Run(() => _sysFunctionService.GetAll(_params));
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
        public async Task<HttpResponseMessage> GetByIdAsync(SysFunctionModel _params)
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            try
            {
                var data = await Task.Run(() => _sysFunctionService.GetById(_params));
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
        public async Task<HttpResponseMessage> CreateAsync(SysFunctionModel _param)
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            try
            {
                if (_param != null)
                {
                    if(_param.SysFunctionGroupId < 0 || _param.SysFunctionGroupId == null)
                    {
                        Result.Status = false;
                        Result.Message = "Nhóm chức năng không được trống" + _param.SysFunctionGroupId;
                        Result.StatusCode = HttpStatusCode.BadRequest;
                    }
                    else if(string.IsNullOrEmpty(_param.FunctionName))
                    {
                        Result.Status = false;
                        Result.Message = "Tên chức năng không được trống" + _param.FunctionName;
                        Result.StatusCode = HttpStatusCode.BadRequest;
                    }
                    else
                    {
                        await Task.Run(() => _sysFunctionService.Insert(_param));
                        Result.Status = true;
                        Result.Message = "Thêm mới thành công";
                        Result.StatusCode = HttpStatusCode.OK;
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

        /*==Update==*/
        [Route("UpdateAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> UpdateAsync(SysFunctionModel _param)
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            try
            {
                if (_param != null)
                {
                    if (_param.SysFunctionGroupId < 0 || _param.SysFunctionGroupId == null)
                    {
                        Result.Status = false;
                        Result.Message = "Nhóm chức năng không được trống" + _param.SysFunctionGroupId;
                        Result.StatusCode = HttpStatusCode.BadRequest;
                    }
                    else if (string.IsNullOrEmpty(_param.FunctionName))
                    {
                        Result.Status = false;
                        Result.Message = "Tên chức năng không được trống" + _param.FunctionName;
                        Result.StatusCode = HttpStatusCode.BadRequest;
                    }
                    else
                    {
                        await Task.Run(() => _sysFunctionService.Update(_param));
                        Result.Status = true;
                        Result.Message = "Cập nhập thành công";
                        Result.StatusCode = HttpStatusCode.OK;
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

        /*==Delete==*/
        [Route("DeleteAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> DeleteAsync(SysFunctionModel _param)
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            try
            {
                if (_param != null)
                {
                    await Task.Run(() => _sysFunctionService.Delete(_param));
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
