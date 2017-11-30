using OrgMan.API.Controllers.ControllerBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using OrgMan.DataModel;
using OrgMan.Data;
using OrgMan.Data.UnitOfWork;

namespace OrgMan.API.Controllers
{
    public class PersonController : ApiController
    {
        [HttpGet]
        [Route("person")]
        public HttpResponseMessage Index()
        {
            OrgManUnitOfWork uow = new OrgManUnitOfWork(new OrgManEntities());

            var data = uow.PersonRepository.Get(Guid.Empty,null,null,null,null);

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }
    }
}