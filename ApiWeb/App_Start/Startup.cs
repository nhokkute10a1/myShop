using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using System.Configuration;
using Microsoft.Owin.Security.DataHandler.Encoder;
using System.Net.Http.Formatting;
using Newtonsoft.Json.Serialization;
using System.Linq;

[assembly: OwinStartup(typeof(ApiWeb.App_Start.Startup))]

namespace ApiWeb.App_Start
{
    public class Startup
    {
        public object ApplicationDbContext { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            //HttpConfiguration httpConfig = new HttpConfiguration();

            //ConfigureOAuthTokenGeneration(app);

            //ConfigureWebApi(httpConfig);

            //app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            //app.UseWebApi(httpConfig);
        }

        //private void ConfigureOAuthTokenGeneration(IAppBuilder app)
        //{
        //    // Configure the db context and user manager to use a single instance per request
        //    //app.CreatePerOwinContext(ApplicationDbContext.Create);
        //    //app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

        //    // Plugin the OAuth bearer JSON Web Token tokens generation and Consumption will be here

        //}

        //private void ConfigureWebApi(HttpConfiguration config)
        //{
        //    config.MapHttpAttributeRoutes();

        //    var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
        //    jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        //}
    }
}
