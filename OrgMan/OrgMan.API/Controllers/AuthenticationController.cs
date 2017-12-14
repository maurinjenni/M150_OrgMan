using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OrgMan.API.Controllers.ControllerBase;
using OrgMan.Domain.Handler.Authentication;
using OrgMan.DomainContracts.Authentication;

namespace OrgMan.API.Controllers
{
    public class AuthenticationController : ApiControllerBase
    {
        [HttpPost]
        [Route("authentication/login")]
        public HttpResponseMessage Login(string username, string password)
        {

            LoginQuery query = new LoginQuery()
            {
                Username = username,
                Password = password
            };

            LoginQueryHandler handler = new LoginQueryHandler(query, UnityContainer);
            

            return Request.CreateResponse(HttpStatusCode.OK, handler.Handle());
        }

        [HttpDelete]
        [Route("authentication/logout")]
        public HttpResponseMessage Logout(Guid sessionUid)
        {
            LogoutQuery query = new LogoutQuery()
            {
                SessionUID = sessionUid
            };

            LogoutQueryHandler handler = new LogoutQueryHandler(query, UnityContainer);
            handler.Handle();

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}