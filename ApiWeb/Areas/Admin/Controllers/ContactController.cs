using System.Web.Http;
using System.Web.Http.Cors;
using DataServices.ContactService;

namespace ApiWeb.Areas.Admin.Controllers
{
    [RoutePrefix("api/Product")]
    /*---Fix(Access-Control-Allow-Origin)----*/
    [EnableCors("*", "*", "*")]
    public class ContactController : ApiController
    {
        private readonly ContactSercive _contactSercive = new ContactSercive();
    }
}