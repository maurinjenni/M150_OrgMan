using Newtonsoft.Json.Linq;
using OrgMan.API.Controllers.ControllerBase;
using OrgMan.Common.DynamicSearchService.DynamicSearchModel;
using OrgMan.Domain.Handler.Meeting;
using OrgMan.DomainContracts.Meeting;
using OrgMan.DomainObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrgMan.API.Controllers
{
    public class MeetingController : ApiControllerBase
    {
        [HttpGet]
        [Route("api/meeting")]
        public HttpResponseMessage Get([FromUri] List<SearchCriteriaDomainModel> searchCriterias = null, [FromUri]int? numberOfRows = null)
        {
            try
            {
                SearchMeetingQuery query = new SearchMeetingQuery()
                {
                    MandatorUIDs = RequestMandatorUIDs,
                    SearchCriterias = searchCriterias,
                    NumberOfRows = numberOfRows
                };

                SearchMeetingQueryHandler handler = new SearchMeetingQueryHandler(query, UnityContainer);
                return Request.CreateResponse(HttpStatusCode.OK, handler.Handle());
            }
            catch (UnauthorizedAccessException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, e);
            }
            catch (DataException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpGet]
        [Route("api/meeting/{uid}")]
        public HttpResponseMessage Get(Guid uid)
        {
            try
            {
                GetMeetingQuery query = new GetMeetingQuery()
                {
                    MandatorUIDs = RequestMandatorUIDs,
                    MeetingUID = uid
                };

                GetMeetingQueryHandler handler = new GetMeetingQueryHandler(query, UnityContainer);
                return Request.CreateResponse(HttpStatusCode.OK, handler.Handle());
            }
            catch (UnauthorizedAccessException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, e);
            }
            catch (DataException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPost]
        [Route("api/meeting")]
        public HttpResponseMessage Post([FromBody] JObject jsonObject)
        {
            try
            {
                MeetingDetailDomainModel meetinDomainModel = jsonObject.ToObject<MeetingDetailDomainModel>();

                if(meetinDomainModel == null)
                {
                    throw new Exception("Invalid JSON Object");
                }

                UpdateMeetingQuery query = new UpdateMeetingQuery()
                {
                    MandatorUIDs = RequestMandatorUIDs,
                    MeetingDetailDomainModel = meetinDomainModel
                };

                UpdateMeetingQueryHandler handler = new UpdateMeetingQueryHandler(query, UnityContainer);

                return Request.CreateResponse(HttpStatusCode.OK, handler.Handle());                
            }
            catch (UnauthorizedAccessException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, e);
            }
            catch (DataException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPut]
        [Route("api/meeting")]
        public HttpResponseMessage Put([FromBody] JObject jsonObject)
        {
            try
            {
                MeetingDetailDomainModel meetingDomainModel =
                    jsonObject.ToObject<MeetingDetailDomainModel>();

                if (meetingDomainModel == null)
                {
                    throw new Exception("Invalid JSON Object");
                }

                InsertMeetingQuery query = new InsertMeetingQuery()
                {
                    MandatorUIDs = RequestMandatorUIDs,
                    MeetingDetailDomainModel = meetingDomainModel
                };

                InsertMeetingQueryHandler handler = new InsertMeetingQueryHandler(query, UnityContainer);

                return Request.CreateResponse(HttpStatusCode.Accepted, handler.Handle());
            }
            catch (UnauthorizedAccessException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, e);
            }
            catch (DataException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpDelete]
        [Route("api/meeting/{uid}")]
        public HttpResponseMessage Delete(Guid uid)
        {
            try
            {
                DeleteMeetingQuery query = new DeleteMeetingQuery()
                {
                    MandatorUIDs = RequestMandatorUIDs,
                    MeetingUID = uid
                };

                DeleteMeetingQueryHandler handler = new DeleteMeetingQueryHandler(query, UnityContainer);

                handler.Handle();

                return Request.CreateResponse(HttpStatusCode.Accepted);
            }
            catch (UnauthorizedAccessException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, e);
            }
            catch (DataException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}