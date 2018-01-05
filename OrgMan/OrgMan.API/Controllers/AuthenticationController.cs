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
            JToken parameterUsername = data["username"];
            JToken parameterPassword = data["password"];

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

                string username = parameterUsername.ToString();
                string password = parameterPassword.ToString();

                LoginQuery loginQuery = new LoginQuery()
                {
                    Username = username,
                    Password = password
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
                    Guid sessionUid = createSessionQueryHandler.Handle();

                    HttpCookie cookie = new HttpCookie(ConfigurationManager.AppSettings["SessionCookieName"])
                    {
                        Value = sessionUid.ToString(),
                        Domain = HttpContext.Current.Request.Url.Host,
                        Expires = DateTime.Now.AddDays(1),
                        HttpOnly = false,
                    };

                    HttpContext.Current.Response.AppendCookie(cookie);
                }

                // else
                // {
                // HttpCookie responseCookie = HttpContext.Current.Response.Cookies.Get(ConfigurationManager.AppSettings["SessionCookieName"]);

                // if (responseCookie != null)
                // {
                // responseCookie.Value = sessionUid.ToString();
                // }
                // else
                // {
                // throw new NullReferenceException(nameof(responseCookie));
                // }
                // }
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
                        LogoutQuery query = new LogoutQuery()
                        {
                            SessionUID = sessionUid
                        };

                        LogoutQueryHandler handler = new LogoutQueryHandler(query, UnityContainer);
                        handler.Handle();

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