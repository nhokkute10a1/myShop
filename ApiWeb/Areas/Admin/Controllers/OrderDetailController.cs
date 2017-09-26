using DataModel.OrderDetailModel;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using LibResponse;
using DataServices.OrderDetailService;
using System.Net;
using Newtonsoft.Json;

namespace ApiWeb.Areas.Admin.Controllers
{
    [RoutePrefix("api/OrderDetail")]
    public class OrderDetailController : ApiController
    {
        private readonly OrderDetailService _orderDetailService = new OrderDetailService();

        /*===Thêm mới===*/
        [Route("CreateAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> CreateAsync(OrderDetailModel _params)
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            try
            {
                if (_params != null)
                {
                    await Task.Run(() => _orderDetailService.Insert(_params));
                    Result.Status = true;
                    Result.Message = "Thêm mới thành công";
                    Result.StatusCode = HttpStatusCode.OK;
                }
                else
                {
                    Result.Status = false;
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

        /*===Xóa===*/
        [Route("DeleteAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> DeleteAsync(OrderDetailModel _params)
        {
            var Res = Request.CreateResponse();
            var Result = new Res();
            try
            {
                if (_params != null)
                {
                    await Task.Run(() => _orderDetailService.Delete(_params));
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