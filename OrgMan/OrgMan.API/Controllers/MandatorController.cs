using OrgMan.API.Controllers.ControllerBase;
using OrgMan.Common.DynamicSearchService.DynamicSearchModel;
using OrgMan.Data.UnitOfWork;
using OrgMan.DomainObjects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace OrgMan.API.Controllers
{
    public class MandatorController : ApiControllerBase
    {
        [HttpGet]
        [Route("api/mandator")]
        public HttpResponseMessage Get()
        {
            try
            {
                List<MandatorDomainModel> result = new List<MandatorDomainModel>();
                OrgManUnitOfWork uow = new OrgManUnitOfWork();

                foreach (Guid uid in RequestMandatorUIDs)
                {
                    result.Add(AutoMapper.Mapper.Map<MandatorDomainModel>(uow.MandatorRepository.Get(uid)));
                }
             
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}