﻿using System;
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
using Newtonsoft.Json.Linq;
using OrgMan.DomainObjects.Common;

namespace OrgMan.API.Controllers
{
    public class AdressController : ApiControllerBase
    {
        [HttpGet]
        [Route("adress")]
        public HttpResponseMessage Get([FromUri] List<SearchCriteriaDomainModel> searchCriterias = null, [FromUri]int? numberOfRows = null)
        {
            numberOfRows = 100;
            //searchCriterias = new List<SearchCriteriaDomainModel>();
            //searchCriterias.Add(new SearchCriteriaDomainModel()
            //{
            //    DataType = Common.DynamicSearchService.DynamicSearchModel.Enums.SearchCriteriaDataTypeDomainModelEnum.String,
            //    OperationType = Common.DynamicSearchService.DynamicSearchModel.Enums.SearchCriteriaOperationTypeDomainModelEnum.Contains,
            //    Values = new List<object>() { "Anna" },
            //    Title = "Firstname",
            //    FieldName = "Person.Firstname"
            //});

            //var mandatorUidStrings = HttpContext.Current.Request.ServerVariables.Get("MandatorUID").Split(',');
            var mandatorUidStrings = new List<string>() { "9C383D13-D557-564F-2060-01CFA1288167" };

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
            //var mandatorUidStrings = HttpContext.Current.Request.ServerVariables.Get("MandatorUID").Split(',');
            var mandatorUidStrings = new List<string>() { "72920FF1-4C81-F677-D5EE-00FD566FAE86" };

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
            
            return Request.CreateResponse(HttpStatusCode.Accepted, handler.Handle());
        }

        [HttpPost]
        [Route("adress")]
        public HttpResponseMessage Post([FromBody] JObject jsonObject)
        {
            //var mandatorUidStrings = HttpContext.Current.Request.ServerVariables.Get("MandatorUID").Split(',');
            var mandatorUidStrings = new List<string>() { "72920FF1-4C81-F677-D5EE-00FD566FAE86" };

            AdressManagementDetailDomainModel adressDomainModel =
                jsonObject.ToObject<AdressManagementDetailDomainModel>();

            var individualPerson = jsonObject["IndividualPerson"];
            
            UpdateAdressQuery query = new UpdateAdressQuery()
            {
                MandatorUID = Guid.Parse(mandatorUidStrings[0]),
                AdressManagementDetailDomainModel = adressDomainModel
            };

            UpdateAdressQueryHandler handler = new UpdateAdressQueryHandler(query, UnityContainer);
            
            return Request.CreateResponse(HttpStatusCode.Accepted, handler.Handle());
        }

        [HttpPut]
        [Route("adress")]
        public HttpResponseMessage Put([FromBody] JObject jsonObject)
        {
            //var mandatorUidStrings = HttpContext.Current.Request.ServerVariables.Get("MandatorUID").Split(',');
            var mandatorUidStrings = new List<string>() { "72920FF1-4C81-F677-D5EE-00FD566FAE86" };

            AdressManagementDetailDomainModel adressDomainModel =
                jsonObject.ToObject<AdressManagementDetailDomainModel>();

            InsertAdressQuery query = new InsertAdressQuery()
            {
                //MandatorUID = Guid.Parse(HttpContext.Current.Request.ServerVariables.Get("MandatorUID")),
                MandatorUID = Guid.Parse(mandatorUidStrings[0]),
                AdressManagementDetailDomainModel = adressDomainModel
            };

            InsertAdressQueryHandler handler = new InsertAdressQueryHandler(query, UnityContainer);

            return Request.CreateResponse(HttpStatusCode.Accepted, handler.Handle());
        }

        [HttpDelete]
        [Route("adress/{uid}")]
        public HttpResponseMessage Delete(Guid uid)
        {
            DeleteAdressQuery query = new DeleteAdressQuery()
            {
                IndividualPersonUID = uid,
                MandatorUID = Guid.Empty,
            };

            DeleteAdressQueryHandler handler = new DeleteAdressQueryHandler(query, UnityContainer);
            handler.Handle();

            return Request.CreateResponse(HttpStatusCode.Accepted);
        }


    }
}