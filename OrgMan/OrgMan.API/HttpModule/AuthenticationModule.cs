using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace OrgMan.API.HttpModule
{
    public class AuthenticationModule : IHttpModule
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
            var request = HttpContext.Current.Request;
            string header = request.Headers["HTTP_AUTHORIZATION"];

            if (header != null && header.StartsWith("Basic "))
            {
                // Header is good, let's check username and password
                string username = DecodeFromHeader(header, "username");
                string password = DecodeFromHeader(header, "password");

                if (Validate(username, password))
                {
                    // Create a custom IPrincipal object to carry the user's identity
                    HttpContext.Current.User = new BasicPrincipal(username);
                }
                else
                {
                    UnAuthorized();
                }
            }
            else
            {
                UnAuthorized();
            }
        }

        private void UnAuthorized()
        {
            var response = HttpContext.Current.Response;
            response.StatusCode = 401;
            response.Headers.Add("WWW-Authenticate", "Basic realm=\"Test\"");
            response.Write("You must authenticate");
            response.End();
        }

        private string DecodeFromHeader(string header, string property)
        {
            // Figure this out based on spec
            // It's basically base 64 decode and split on the :
            throw new NotImplementedException();
        }

        private bool Validate(string username, string password)
        {
            return (username == "foo" && password == "bar");
        }
    }

    public class BasicPrincipal : IPrincipal
    {
        private string username;

        public BasicPrincipal(string username)
        {
            this.username = username;
        }

        // Implement simple class to hold the user's identity
        public IIdentity Identity => throw new NotImplementedException();

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }
}