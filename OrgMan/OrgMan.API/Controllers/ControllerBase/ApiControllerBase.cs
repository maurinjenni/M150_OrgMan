using Microsoft.Practices.Unity;
using System.Web.Http;

namespace OrgMan.API.Controllers.ControllerBase
{
    public class ApiControllerBase : ApiController
    {
        public static IUnityContainer UnityContainer { get; set; }
    }
}