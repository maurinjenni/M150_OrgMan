using System;
using System.Web;

namespace OrgMan.API.HttpModule
{
    public class SessionModule : IHttpModule
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Init(HttpApplication application)
        {
            application.AuthenticateRequest += new EventHandler(Authenticate);
        }

        private void Authenticate(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            var request = HttpContext.Current.Request;

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
                }
                else
                {
                    UnAuthorized(app);
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