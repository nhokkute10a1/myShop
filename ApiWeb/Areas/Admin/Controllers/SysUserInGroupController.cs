using DataModel.SysUserInGroupModel;
using DataServices.SysUserInGroupService;
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
    [RoutePrefix("api/SysUserInGroup")]
    /*---Fix(Access-Control-Allow-Origin)----*/
    [EnableCors("*", "*", "*")]
    public class SysUserInGroupController : ApiController
    {
        private readonly SysUserInGroupService _sysUserInGroupService = new SysUserInGroupService();

        /*==Lấy toàn bộ danh sách==*/

        [Route("GetAllAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> GetAllAsync(PagingModel _params)
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            try
            {
                var data = await Task.Run(() => _sysUserInGroupService.GetAll(_params));
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
        [Route("GetAllByIdAsync ")]
        [HttpPost]
        public async Task<HttpResponseMessage> GetAllByIdAsync(SysUserInGroupModel _params)
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            try
            {
                var data = await Task.Run(() => _sysUserInGroupService.GetById(_params));
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
        public async Task<HttpResponseMessage> CreateAsync(SysUserInGroupModel _param)
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            try
            {
                if (_param != null)
                {
                    if (_param.GroupRolesId < 0 || _param.GroupRolesId == null)
                    {
                        Result.Status = false;
                        Result.Message = "Nhóm quyền không được trống " + _param.SysUserInGroupId;
                        Result.StatusCode = HttpStatusCode.OK;
                    }
                    else if (_param.UserId < 0 || _param.UserId == null)
                    {
                        Result.Status = false;
                        Result.Message = "Tên người dùng không được trống " + _param.SysUserInGroupId;
                        Result.StatusCode = HttpStatusCode.OK;
                    }
                    else
                    {
                        await Task.Run(() => _sysUserInGroupService.Insert(_param));
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

        /*==Cập nhập ==*/
        [Route("UpdateAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> UpdateAsync(SysUserInGroupModel _param)
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            try
            {
                if (_param != null)
                {
                    if (_param.GroupRolesId < 0 || _param.GroupRolesId == null)
                    {
                        Result.Status = false;
                        Result.Message = "Nhóm quyền không được trống " + _param.SysUserInGroupId;
                        Result.StatusCode = HttpStatusCode.OK;
                    }
                    else if (_param.UserId < 0 || _param.UserId == null)
                    {
                        Result.Status = false;
                        Result.Message = "Tên người dùng không được trống " + _param.SysUserInGroupId;
                        Result.StatusCode = HttpStatusCode.OK;
                    }
                    else
                    {
                        await Task.Run(() => _sysUserInGroupService.Update(_param));
                        Result.Status = true;
                        Result.Message = "Cập nhật thành công";
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
                Result.Message = "Có lỗi xảy ra trong quá trình cập nhật " + ex.Message;
                Result.StatusCode = HttpStatusCode.BadRequest;
                throw new Exception(ex.Message);
            }
        }

        /*==Xóa ==*/
        [Route("DeleteAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> DeleteAsync(SysUserInGroupModel _param)
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            try
            {
                if (_param != null)
                {
                    await Task.Run(() => _sysUserInGroupService.Delete(_param));
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
