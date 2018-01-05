using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using OrgMan.Domain.Handler.Session;
using OrgMan.DomainContracts.Session;
using System.Configuration;

namespace OrgMan.API.HttpModule
{
    public class SessionModule : IHttpModule
    {
        private static readonly List<string> ControllersToSkip = ConfigurationManager.AppSettings["WhitelistedControllers"].Split(',').ToList();

        public void Dispose()
        {

        }

        public void Init(HttpApplication application)
        {
            application.BeginRequest += (SkipAuthentication);
            application.AuthorizeRequest += (Authorize);
        }

        private void SkipAuthentication(object sender, EventArgs e)
        {
            foreach (string skipableControllers in ControllersToSkip)
            {
                if (!string.IsNullOrEmpty(skipableControllers) &&
                    HttpContext.Current.Request.Url.LocalPath.Contains(skipableControllers))
                {
                    // Bypass
                    HttpContext.Current.SkipAuthorization = true;
                }
            }
        }

        private void Authorize(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication) sender;
            var request = HttpContext.Current.Request;
            var response = HttpContext.Current.Response;

            if (!HttpContext.Current.SkipAuthorization)
            {
                HttpCookie cookie = request.Cookies[ConfigurationManager.AppSettings["SessionCookieName"]];

                if (cookie == null)
                {
                    // Loginpage
                    UnAuthorized(app);
                }
                else
                {
                    Guid SessionUid = Guid.Empty;

                    if (Guid.TryParse(cookie.Value, out SessionUid))
                    {
                        GetSessionQuery getSessionQuery = new GetSessionQuery()
                        {
                            SessionUID = SessionUid
                        };

                        GetSessionQueryHandler getSessionQueryHandler = new GetSessionQueryHandler(getSessionQuery, new UnityContainer());
                        var session = getSessionQueryHandler.Handle();

                        if (session == null || session.ExpireDate < DateTimeOffset.Now)
                        {
                            // Loginpage
                            UnAuthorized(app);
                        }
                        else
                        {
                            if (session.MandatorUIDs == null || !session.MandatorUIDs.Any())
                            {
                                throw new Exception("No Mandator found to Session");
                            }
                            else
                            {
                                string serverVariableValue = string.Empty;

                                foreach (Guid mandatorUid in session.MandatorUIDs)
                                {
                                    if (string.IsNullOrEmpty(serverVariableValue))
                                    {
                                        serverVariableValue += mandatorUid.ToString();
                                    }
                                    else
                                    {
                                        serverVariableValue += "," + mandatorUid.ToString();
                                    }
                                }

                                request.ServerVariables.Add("MandatorUID", serverVariableValue);
                            }

                            if (session.ExpireDate < DateTimeOffset.Now.AddHours(-1))
                            {
                                session.ExpireDate = DateTimeOffset.Now.AddDays(1);

                                var sessioncookie = response.Cookies[ConfigurationManager.AppSettings["SessionCookieName"]];

                                if (sessioncookie != null)
                                {
                                    sessioncookie.Expires = session.ExpireDate.DateTime;
                                }

                                UpdateSessionQuery updateSessionQuery = new UpdateSessionQuery()
                                {
                                    Session = session
                                };

                                UpdateSessionQueryHandler updateSessionQueryHandler = new UpdateSessionQueryHandler(updateSessionQuery, new UnityContainer());
                                updateSessionQueryHandler.Handle();
                            }
                        }                                 
                    }
                    else
                    {
                        UnAuthorized(app);
                    }
                }
            }
        }

        private void UnAuthorized(HttpApplication application)
        {
            HttpContext context = application.Context;

            context.Response.Redirect("http://LoginPage");
        }
    }
}