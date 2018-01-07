using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
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
                //var mandatorUidStrings = HttpContext.Current.Request.ServerVariables.Get("MandatorUID").Split(',');
                var mandatorUidStrings = new List<string>() { "E91019DA-26C8-B201-1385-0011F6C365E9" };

                List<Guid> mandatorUids = new List<Guid>();

                foreach (var mandatorString in mandatorUidStrings)
                {
                    mandatorUids.Add(Guid.Parse(mandatorString));
                }

                return mandatorUids;
            }
        }
    }
}