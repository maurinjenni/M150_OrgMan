using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.Practices.Unity;
using Newtonsoft.Json.Linq;
using OrgMan.API.Controllers.ControllerBase;
using OrgMan.Domain.Handler.Authentication;
using OrgMan.Domain.Handler.Session;
using OrgMan.DomainContracts.Authentication;
using OrgMan.DomainContracts.Session;
using OrgMan.DomainObjects.Session;
using System.Configuration;

namespace OrgMan.API.Controllers
{
    public class AuthenticationController : ApiControllerBase
    {
        [HttpPost]
        [Route("authentication/login")]
        public HttpResponseMessage Login([FromBody] JObject data)
        {
            JToken parameterUsername = data["Username"];
            JToken parameterPassword = data["Password"];

            try
            {
                if (string.IsNullOrEmpty(parameterUsername.ToString()))
                {
                    throw new ArgumentNullException(nameof(parameterUsername));
                }

                if (string.IsNullOrEmpty(parameterPassword.ToString()))
                {
                    throw new ArgumentNullException(nameof(parameterPassword));
                }

                LoginQuery loginQuery = new LoginQuery()
                {
                    Username = parameterUsername.ToString(),
                    Password = parameterPassword.ToString()
                };

                LoginQueryHandler loginQueryHandler = new LoginQueryHandler(loginQuery, UnityContainer);

                Guid personUid = loginQueryHandler.Handle();

                HttpCookie requestCookie = HttpContext.Current.Request.Cookies.Get(ConfigurationManager.AppSettings["SessionCookieName"]);

                if (requestCookie == null)
                {
                    CreateSessionQuery createSessionQuery = new CreateSessionQuery()
                    {
                        Session = new SessionDomainModel()
                        {
                            LoginUID = personUid,
                            ExpireDate = DateTimeOffset.Now.AddDays(1)
                        }
                    };

                    CreateSessionQueryHandler createSessionQueryHandler = new CreateSessionQueryHandler(createSessionQuery,new UnityContainer());

                    HttpCookie cookie = new HttpCookie(ConfigurationManager.AppSettings["SessionCookieName"])
                    {
                        Value = createSessionQueryHandler.Handle().ToString(),
                        Domain = HttpContext.Current.Request.Url.Host,
                        Expires = DateTime.Now.AddDays(1),
                        HttpOnly = false,
                    };

                    HttpContext.Current.Response.AppendCookie(cookie);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpDelete]
        [Route("authentication/logout")]
        public HttpResponseMessage Logout()
        {
            try
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(ConfigurationManager.AppSettings["SessionCookieName"]);

                if (cookie != null)
                {
                    Guid sessionUid;
                    if (Guid.TryParse(cookie.Value, out sessionUid))
                    {
                        DeleteSessionQuery query = new DeleteSessionQuery()
                        {
                            SessionUID = sessionUid
                        };

                        DeleteSessionQueryHandler handler = new DeleteSessionQueryHandler(query, UnityContainer);
                        handler.Handle();

                        cookie.Expires = DateTime.Now.AddDays(-1);

                        HttpContext.Current.Response.Cookies.Set(cookie);

                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
                else
                {
                    throw new Exception("Could not find the Cookie");
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}