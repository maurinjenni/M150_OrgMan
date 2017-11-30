using OrgMan.API.Controllers.ControllerBase;
using System;
using System.Net.Http;
using System.Web.Http;
using OrgMan.DataModel;
using OrgMan.Data.UnitOfWork;

namespace OrgMan.API.Controllers
{
    public class PersonController : ApiControllerBase
    {
        //[HttpGet]
        //[Route("person/{id}]")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            OrgManUnitOfWork uow = new OrgManUnitOfWork(new OrgManEntities());

            var data = uow.PersonRepository.Get(Guid.Empty,null,null,null,null);

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }
    }
}