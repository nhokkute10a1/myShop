using DataModel.OrderMasterModel;
using DataServices.OrderMasterService;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using LibResponse;
using System.Net;
using Newtonsoft.Json;

namespace ApiWeb.Areas.Admin.Controllers
{
    [RoutePrefix("api/OrderMaster")]
    public class OrderMasterController : ApiController
    {
        private readonly OrderMasterService _orderMasterService = new OrderMasterService();
        /*==Thêm mới===*/
        [Route("CreateAsyn")]
        [HttpPost]
        public async Task<HttpResponseMessage> CreateAsyn(OrderMasterModel _param)
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            try
            {
                if (_param != null)
                {
                    await Task.Run(() => _orderMasterService.Insert(_param));
                    Result.Status = true;
                    Result.Message = "Thêm mới thành công";
                    Result.StatusCode = HttpStatusCode.OK;
                }
                else
                {
                    Result.Status = true;
                    Result.Message = "Thêm mới thất bại";
                    Result.StatusCode = HttpStatusCode.InternalServerError;
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

        /*==Cập nhập===*/
        [Route("UpdateAsyn")]
        [HttpPost]
        public async Task<HttpResponseMessage> UpdateAsyn(OrderMasterModel _param)
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            try
            {
                await Task.Run(() => _orderMasterService.Update(_param));
                if (_param != null)
                {
                    Result.Status = true;
                    Result.Message = "Cập nhập thành công";
                    Result.StatusCode = HttpStatusCode.OK;

                }
                else
                {
                    Result.Status = false;
                    Result.Message = "Cập nhập thất bại";
                    Result.StatusCode = HttpStatusCode.InternalServerError;
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

        /*==Xóa===*/
        [Route("DeleteAsyn")]
        [HttpPost]
        public async Task<HttpResponseMessage> DeleteAsyn(OrderMasterModel _param)
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            try
            {
                await Task.Run(() => _orderMasterService.Delete(_param));
                if (_param != null)
                {
                    Result.Status = true;
                    Result.Message = "Xóa thành công";
                    Result.StatusCode = HttpStatusCode.OK;

                }
                else
                {
                    Result.Status = false;
                    Result.Message = "Xóa thất bại";
                    Result.StatusCode = HttpStatusCode.InternalServerError;
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