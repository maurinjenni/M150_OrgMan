using System;
using System.Collections.Generic;
using System.Web;
using Microsoft.Ajax.Utilities;
using Microsoft.Practices.Unity;
using OrgMan.Domain.Handler.Session;
using OrgMan.DomainContracts.Session;
using Context = System.Runtime.Remoting.Contexts.Context;

namespace OrgMan.API.HttpModule
{
    public class SessionModule : IHttpModule
    {
        private static readonly List<string> controllersToSkip = new List<string>() {"authentication", string.Empty, string.Empty};

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Init(HttpApplication application)
        {
            application.BeginRequest += new EventHandler(SkipAuthentication);
            application.AuthorizeRequest += new EventHandler(Authorize);
        }

        private void SkipAuthentication(object sender, EventArgs e)
        {
            foreach (string skipableControllers in controllersToSkip)
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

            if (!HttpContext.Current.SkipAuthorization)
            {
                HttpCookie cookie = request.Cookies["OrgMan_SessionUid"];

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

                        if (session.ExpireDate < DateTimeOffset.Now.AddHours(-1))
                        {
                            session.ExpireDate = DateTimeOffset.Now.AddDays(1);

                            HttpContext.Current.Response.Cookies["OrgMan_SessionUid"].Expires = session.ExpireDate.DateTime;

                            UpdateSessionQuery updateSessionQuery = new UpdateSessionQuery()
                            {
                                Session = session
                            };

                            UpdateSessionQueryHandler updateSessionQueryHandler = new UpdateSessionQueryHandler(updateSessionQuery, new UnityContainer());
                            updateSessionQueryHandler.Handle();
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