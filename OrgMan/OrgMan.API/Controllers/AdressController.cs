using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using OrgMan.API.Controllers.ControllerBase;
using OrgMan.Common.DynamicSearchService.DynamicSearchModel;
using OrgMan.Domain.Handler.Adress;
using OrgMan.DomainContracts.Adress;
using OrgMan.DomainObjects;
using OrgMan.DomainObjects.Adress;

namespace OrgMan.API.Controllers
{
    public class AdressController : ApiControllerBase
    {
        [HttpGet]
        [Route("adress")]
        public HttpResponseMessage Get([FromUri] List<SearchCriteriaDomainModel> searchCriterias = null, [FromUri]int? numberOfRows = null)
        {
            var mandatorUidStrings = HttpContext.Current.Request.ServerVariables.Get("MandatorUID").Split(',');

            List<Guid> mandatorUids = new List<Guid>();

            foreach (var mandatorString in mandatorUidStrings)
            {
                mandatorUids.Add(Guid.Parse(mandatorString));
            }

            SearchAdressQuery qurey = new SearchAdressQuery()
            {
                MandatorUID = mandatorUids,
                SearchCriterias = searchCriterias,
                NumberOfRows = numberOfRows
            };

            SearchAdressQueryHandler handler = new SearchAdressQueryHandler(qurey, UnityContainer);

            return Request.CreateResponse(HttpStatusCode.OK, handler.Handle());
        }

        [HttpGet]
        [Route("adress/{uid}")]
        public HttpResponseMessage Get(Guid uid)
        {
            var mandatorUidStrings = HttpContext.Current.Request.ServerVariables.Get("MandatorUID").Split(',');

            List<Guid> mandatorUids = new List<Guid>();

            foreach (var mandatorString in mandatorUidStrings)
            {
                mandatorUids.Add(Guid.Parse(mandatorString));
            }

            GetAdressQuery query = new GetAdressQuery()
            {
                MandatorUID = mandatorUids,
                AdressUID = uid,
            };

            GetAdressQueryHandler handler = new GetAdressQueryHandler(query, UnityContainer);
            
            return Request.CreateResponse(HttpStatusCode.Accepted);
        }

        [HttpPost]
        [Route("adress")]
        public HttpResponseMessage Post(AdressDetailDomainModel adress)
        {
            UpdateAdressQuery query = new UpdateAdressQuery()
            {
                MandatorUID = Guid.Parse(HttpContext.Current.Request.ServerVariables.Get("MandatorUID")),
                Adress = adress
            };

            UpdateAdressQueryHandler handler = new UpdateAdressQueryHandler(query, UnityContainer);
            
            return Request.CreateResponse(HttpStatusCode.Accepted);
        }

        [HttpPut]
        [Route("adress")]
        public HttpResponseMessage Put(AdressDetailDomainModel adress)
        {
            InsertAdressQuery query = new InsertAdressQuery()
            {
                MandatorUID = Guid.Parse(HttpContext.Current.Request.ServerVariables.Get("MandatorUID")),
                Adress = adress                
            };

            InsertAdressQueryHandler handler = new InsertAdressQueryHandler(query, UnityContainer);
            return Request.CreateResponse(HttpStatusCode.Accepted);
        }

        [HttpDelete]
        [Route("adress/{uid}")]
        public HttpResponseMessage Delete(Guid uid)
        {
            DeleteAdressQuery query = new DeleteAdressQuery()
            {
                AdressUID = uid,
                MandatorUID = Guid.Empty,
            };

            DeleteAdressQueryHandler handler = new DeleteAdressQueryHandler(query, UnityContainer);
            handler.Handle();

            return Request.CreateResponse(HttpStatusCode.Accepted);
        }


    }
}