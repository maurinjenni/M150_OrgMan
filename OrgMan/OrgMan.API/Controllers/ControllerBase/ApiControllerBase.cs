using Microsoft.Practices.Unity;
using OrgMan.Domain.Handler.Session;
using OrgMan.DomainContracts.Session;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Http;

namespace OrgMan.API.Controllers.ControllerBase
{
    public class ApiControllerBase : ApiController
    {
        public static IUnityContainer UnityContainer { get; set; }

        public List<Guid> RequestMandatorUIDs
        {
            get
            {
                if (HttpContext.Current.Request.ServerVariables != null)
                {
                    var header = HttpContext.Current.Request.Headers.Get(ConfigurationManager.AppSettings["SessionCookieName"]);

                    //var cookie = HttpContext.Current.Request.Cookies.Get(ConfigurationManager.AppSettings["SessionCookieName"]);

                    if (header != null)
                    {
                        var sessionUidString = header;

                        if (string.IsNullOrEmpty(sessionUidString))
                        {
                            throw new InvalidOperationException("Header" + ConfigurationManager.AppSettings["SessionCookieName"] + "is null or empty");
                        }

                        Guid sessionUid = Guid.Empty;

                        sessionUidString = sessionUidString.Trim('\"');

                        if (Guid.TryParse(sessionUidString, out sessionUid))
                        {
                            GetMandatorsQuery query = new GetMandatorsQuery()
                            {
                                SessionUID = Guid.Parse(sessionUidString)
                            };

                            GetMandatorsQueryHandler handler = new GetMandatorsQueryHandler(query, UnityContainer);

                            return handler.Handle();
                        }
                        else
                        {
                            throw new InvalidOperationException("The Header" + ConfigurationManager.AppSettings["SessionCookieName"] + "is not a Guid. The value is : " + sessionUidString);
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException(string.Format("No Cookie with the Key {0} is available", ConfigurationManager.AppSettings["SessionCookieName"]));
                    }
                }
                else
                {
                    throw new InvalidOperationException("No Cookies are available");
                }

            }
        }

        //public List<Guid> RequestMandatorUIDs
        //{
        //    get
        //    {
        //        var mandatorUidStrings = new List<string>() { "E91019DA-26C8-B201-1385-0011F6C365E9" };

        //        List<Guid> mandatorUids = new List<Guid>();

        //        foreach (var mandatorString in mandatorUidStrings)
        //        {
        //            mandatorUids.Add(Guid.Parse(mandatorString));
        //        }

        //        return mandatorUids;
        //    }
        //}
    }
}