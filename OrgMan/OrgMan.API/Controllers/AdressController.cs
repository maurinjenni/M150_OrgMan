using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OrgMan.API.Controllers.ControllerBase;
using OrgMan.Common.DynamicSearchService.DynamicSearchModel;
using OrgMan.Domain.Handler.Adress;
using OrgMan.DomainContracts.Adress;
using OrgMan.DomainObjects.Adress;
using Newtonsoft.Json.Linq;

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

            SearchAdressQuery qurey = new SearchAdressQuery()
            {
                MandatorUID = RequestMandatorUIDs,
                SearchCriterias = searchCriterias,
                NumberOfRows = numberOfRows
            };

            try
            {
                SearchAdressQueryHandler handler = new SearchAdressQueryHandler(qurey, UnityContainer);


                return Request.CreateResponse(HttpStatusCode.OK, handler.Handle());
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }         
        }

        [HttpGet]
        [Route("adress")]
        public HttpResponseMessage Get([FromUri]string searchString)
        {
            FullTextSearchAdressQuery query = new FullTextSearchAdressQuery()
            {
                MandatorUids = RequestMandatorUIDs,
                SeachText = searchString
            };

            try
            {
                FullTextSearchAdressQueryHandler handler = new FullTextSearchAdressQueryHandler(query, UnityContainer);

                return Request.CreateResponse(handler.Handle());
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError,e);
            }
        }

        [HttpGet]
        [Route("adress/{uid}")]
        public HttpResponseMessage Get(Guid uid)
        {
            GetAdressQuery query = new GetAdressQuery()
            {
                MandatorUID = RequestMandatorUIDs,
                AdressUID = uid,
            };

            try
            {
                GetAdressQueryHandler handler = new GetAdressQueryHandler(query, UnityContainer);

                return Request.CreateResponse(HttpStatusCode.Accepted, handler.Handle());
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPost]
        [Route("adress")]
        public HttpResponseMessage Post([FromBody] JObject jsonObject)
        {
            try
            {
                AdressManagementDetailDomainModel adressDomainModel =
                    jsonObject.ToObject<AdressManagementDetailDomainModel>();

                if(adressDomainModel == null)
                {
                    throw new Exception("Invalid JSON Object");
                }

                UpdateAdressQuery query = new UpdateAdressQuery()
                {
                    MandatorUID = RequestMandatorUIDs[0],
                    AdressManagementDetailDomainModel = adressDomainModel
                };

                UpdateAdressQueryHandler handler = new UpdateAdressQueryHandler(query, UnityContainer);

                return Request.CreateResponse(HttpStatusCode.Accepted, handler.Handle());
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPut]
        [Route("adress")]
        public HttpResponseMessage Put([FromBody] JObject jsonObject)
        {
            try
            {
                AdressManagementDetailDomainModel adressDomainModel =
                    jsonObject.ToObject<AdressManagementDetailDomainModel>();

                if(adressDomainModel == null)
                {
                    throw new Exception("Invalid JSON Object");
                }

                InsertAdressQuery query = new InsertAdressQuery()
                {
                    MandatorUID = RequestMandatorUIDs[0],
                    AdressManagementDetailDomainModel = adressDomainModel
                };

                InsertAdressQueryHandler handler = new InsertAdressQueryHandler(query, UnityContainer);

                return Request.CreateResponse(HttpStatusCode.Accepted, handler.Handle());
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
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

            try
            {
                DeleteAdressQueryHandler handler = new DeleteAdressQueryHandler(query, UnityContainer);

                handler.Handle();

                return Request.CreateResponse(HttpStatusCode.Accepted);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}