using OrgMan.API.Controllers.ControllerBase;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OrgMan.DataModel;
using OrgMan.Data.UnitOfWork;
using OrgMan.Domain.Handler.Person;
using OrgMan.DomainContracts.Person;

namespace OrgMan.API.Controllers
{
    public class PersonController : ApiControllerBase
    {
        [HttpGet]
        [Route("person/{uid}")]
        public HttpResponseMessage Get(Guid uid)
        {
            GetPersonQuery query = new GetPersonQuery()
            {
                PersonUID = uid
            };

            GetPersonQueryHandler handler = new GetPersonQueryHandler(query, UnityContainer);

            return Request.CreateResponse(HttpStatusCode.OK, handler.Handle());
        }
    }
}