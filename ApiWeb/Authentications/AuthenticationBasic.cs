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

namespace ApiWeb.Authentications
{
    public class AuthenticationBasic : AuthorizationFilterAttribute
    {
        private readonly DataServices.UserProfileService.ServiceLogin _serviceLogin = new DataServices.UserProfileService.ServiceLogin();
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
                    //actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.OK, new
                    //{
                    //    Status = true,
                    //    StatusCode = 200,
                    //    Data = new
                    //    {
                    //        Token = "Basic " + AuthenticationToken,
                    //        UserName = username,
                    //        Passwords = passwords
                    //    }
                    //});
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