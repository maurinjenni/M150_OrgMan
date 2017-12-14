using System;
using System.Collections.Generic;
using System.Web;
using Microsoft.Ajax.Utilities;
using Context = System.Runtime.Remoting.Contexts.Context;

namespace OrgMan.API.HttpModule
{
    public class SessionModule : IHttpModule
    {
        private static readonly List<string> controllersToSkip = new List<string>(){"person","",""};

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
                if (!string.IsNullOrEmpty(skipableControllers) && HttpContext.Current.Request.Url.LocalPath.Contains(skipableControllers))
                {
                    // Bypass
                    HttpContext.Current.SkipAuthorization = true;
                }
            }
        }

        private void Authorize(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            var request = HttpContext.Current.Request;

            if (!HttpContext.Current.SkipAuthorization)
            {
                HttpCookie cookie = request.Cookies.Get("OrgMan_Session_UID");

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
                        SessionUid = Guid.Parse(cookie.Value);

                        //validate SessionUid
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