using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http;
using System.Linq;
using DataServices.SysUserInGroupService;
using System.Web.Configuration;
using System.Collections.Generic;
using System.Web;

namespace ApiWeb.Authentications
{
    public class AuthenticationBasic : AuthorizationFilterAttribute
    {
        private readonly DataServices.UserProfileService.ServiceLogin _serviceLogin = new DataServices.UserProfileService.ServiceLogin();
        private readonly SysUserInGroupService _service = new SysUserInGroupService();
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (SkipAuthorization(actionContext))
            {
                return;
            }
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, new
                {
                    Status = false,
                    StatusCode = 401,
                    Message = "Unauthorized"
                });
            }
            else
            {
                var AuthenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                var decodedAuthenticationToken =  Encoding.UTF8.GetString(Convert.FromBase64String(AuthenticationToken));
                string[] usernamePasswordArray = decodedAuthenticationToken.Split(':');
                var username = usernamePasswordArray[0];
                var passwords = usernamePasswordArray[1];

                if(_serviceLogin.Login(username, passwords))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
                    var _UserDeveloper = WebConfigurationManager.AppSettings["_UserDeveloper"];
                    var result = _service.CheckPermission(username);
                    List<string> listPermission = result.Select(a => a.FunctionCode).ToList();
                    //Lấy tên controller và action
                    var actionName = actionContext.ActionDescriptor.ControllerDescriptor.ControllerName + "-" +
                                        actionContext.ActionDescriptor.ActionName;
                    //if (username != _UserDeveloper)
                    if (HttpContext.Current.User.Identity.Name != _UserDeveloper)
                    {
                        if (!listPermission.Contains(actionName))
                        {
                            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, new
                            {
                                Status = false,
                                StatusCode = 401,
                                Message = "Bạn không có quyền thực hiện chức năng [[" + actionName + "]] này"
                            });
                        }
                    }
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, new
                    {
                        Status = false,
                        StatusCode = 401,
                        Message = "Unauthorized"
                    });
                }
            }
        }
        private static bool SkipAuthorization(HttpActionContext actionContext)
        {
            return actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any()
                   || actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
        }
        public static string GetUsername()
        {
            var Principal = Thread.CurrentPrincipal;
            var Identity = Principal?.Identity;
            return Identity?.Name;
        }
    }
}