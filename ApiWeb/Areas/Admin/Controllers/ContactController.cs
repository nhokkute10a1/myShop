using System.Web.Http;
using System.Web.Http.Cors;
using DataServices.ContactService;
using System.Net.Http;
using System.Threading.Tasks;
using DataModel.ContactModel;
using System;
using LibResponse;
using Newtonsoft.Json;
using System.Net;

namespace ApiWeb.Areas.Admin.Controllers
{
    [RoutePrefix("api/Contact")]
    /*---Fix(Access-Control-Allow-Origin)----*/
    [EnableCors("*", "*", "*")]
    public class ContactController : ApiController
    {
        private readonly ContactSercive _contactSercive = new ContactSercive();
        /*===Get All===*/
        [Route("GetAllAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> GetAllAsync()
        {
            try
            {
                var data = await Task.Run(() => _contactSercive.GetAll());
                var Res = Request.CreateResponse();
                var Result = new Res();
                if (data!=null)
                {
                    Result.Data = data;
                    Result.Status = true;
                    Result.Message = "Call API Success";
                    Result.StatusCode = HttpStatusCode.OK;
                }
                else
                {
                    Result.Data = data;
                    Result.Status = false;
                    Result.Message = "Không tìm thấy dữ liệu";
                    Result.StatusCode = HttpStatusCode.BadRequest;
                
                }
                Res.Content = new StringContent(JsonConvert.SerializeObject(Result));
                return Res;
            }
             catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /*===Get By Id===*/
        [Route("GetByIdAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> GetByIdAsync(ContactModel _params)
        {
            try
            {
                var data = await Task.Run(() => _contactSercive.GetById(_params));
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
                    Result.Data = data;
                    Result.Status = false;
                    Result.Message = "Không tìm thấy dữ liệu";
                    Result.StatusCode = HttpStatusCode.BadRequest;

                }
                Res.Content = new StringContent(JsonConvert.SerializeObject(Result));
                return Res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /*===Insert===*/
        [Route("CreateAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> CreateAsync(ContactModel _params)
        {
            try
            {
                var Res = Request.CreateResponse();
                var Result = new Res();
                {
                    if (_params != null)
                    {
                        if (string.IsNullOrEmpty(_params.Contact_Name))
                        {
                            Result.Status = false;
                            Result.Message = "Tên không được trống " + _params.Contact_Name;
                            Result.StatusCode = HttpStatusCode.BadRequest;
                        }
                        else if (string.IsNullOrEmpty(_params.Contact_Email))
                        {
                            Result.Status = false;
                            Result.Message = "Email không được trống " + _params.Contact_Email;
                            Result.StatusCode = HttpStatusCode.BadRequest;
                        }
                        //else if(string.Equals)
                        //{
                        //    Result.Status = false;
                        //    Result.Message = "Email " + _params.Contact_Email + "đã tồn tại";
                        //    Result.StatusCode = HttpStatusCode.BadRequest;
                        //}
                        else
                        {
                            await Task.Run(() => _contactSercive.Insert(_params));
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
                }
                Res.Content = new StringContent(JsonConvert.SerializeObject(Result));
                return Res;

            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình thêm mới" + ex.Message);
            }
        }

        /*===Update===*/
        [Route("UpdateAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> UpdateAsync(ContactModel _params)
        {
            try
            {
                var Res = Request.CreateResponse();
                var Result = new Res();
                {
                    if (_params != null)
                    {
                        if (string.IsNullOrEmpty(_params.Contact_Name))
                        {
                            Result.Status = false;
                            Result.Message = "Tên không được trống " + _params.Contact_Name;
                            Result.StatusCode = HttpStatusCode.BadRequest;
                        }
                        else if (string.IsNullOrEmpty(_params.Contact_Email))
                        {
                            Result.Status = false;
                            Result.Message = "Email không được trống " + _params.Contact_Email;
                            Result.StatusCode = HttpStatusCode.BadRequest;
                        }
                        //else if(string.Equals)
                        //{
                        //    Result.Status = false;
                        //    Result.Message = "Email " + _params.Contact_Email + "đã tồn tại";
                        //    Result.StatusCode = HttpStatusCode.BadRequest;
                        //}
                        else
                        {
                            await Task.Run(() => _contactSercive.Update(_params));
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
                }
                Res.Content = new StringContent(JsonConvert.SerializeObject(Result));
                return Res;

            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình cập nhập" + ex.Message);
            }
        }

        /*===Delete===*/
        [Route("DeleteAsync")]
        [HttpPost]
        public async Task<HttpResponseMessage> DeleteAsync(ContactModel _params)
        {
            try
            {
                var Res = Request.CreateResponse();
                var Result = new Res();
                {
                    if (_params != null)
                    {
                        await Task.Run(() => _contactSercive.Delete(_params));
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
                }
                Res.Content = new StringContent(JsonConvert.SerializeObject(Result));
                return Res;

            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xóa " + ex.Message);
            }
        }


    }
}