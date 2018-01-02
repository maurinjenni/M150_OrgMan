using Newtonsoft.Json.Linq;
using OrgMan.API.Controllers.ControllerBase;
using OrgMan.Common.DynamicSearchService.DynamicSearchModel;
using OrgMan.Domain.Handler.Meeting;
using OrgMan.DomainContracts.Meeting;
using OrgMan.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace OrgMan.API.Controllers
{
    public class MeetingController : ApiControllerBase
    {
        [HttpGet]
        [Route("meeting")]
        public HttpResponseMessage Get([FromUri] List<SearchCriteriaDomainModel> searchCriterias = null, [FromUri]int? numberOfRows = null)
        {
            return null;
        }

        [HttpGet]
        [Route("adress/{uid}")]
        public HttpResponseMessage Get(Guid uid)
        {
            GetMeetingQuery query = new GetMeetingQuery()
            {
                MeetingUID = uid
            };            

            try
            {
                GetMeetingQueryHandler handler = new GetMeetingQueryHandler(query, UnityContainer);
                return Request.CreateResponse(HttpStatusCode.OK, handler.Handle());
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
            //var mandatorUidStrings = HttpContext.Current.Request.ServerVariables.Get("MandatorUID").Split(',');
            var mandatorUidStrings = new List<string>() { "72920FF1-4C81-F677-D5EE-00FD566FAE86" };

            try
            {
                MeetingDetailDomainModel meetinDomainModel = jsonObject.ToObject<MeetingDetailDomainModel>();

                if(meetinDomainModel == null)
                {
                    throw new Exception("Invalid JSON Object");
                }

                UpdateMeetingQuery query = new UpdateMeetingQuery()
                {
                    MandatorUID = Guid.Parse(mandatorUidStrings[0]),
                    MeetingDetailDomainModel = meetinDomainModel
                };

                UpdateMeetingQueryHandler handler = new UpdateMeetingQueryHandler(query, UnityContainer);

                return Request.CreateResponse(HttpStatusCode.OK, handler.Handle());                
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
            //var mandatorUidStrings = HttpContext.Current.Request.ServerVariables.Get("MandatorUID").Split(',');
            var mandatorUidStrings = new List<string>() { "72920FF1-4C81-F677-D5EE-00FD566FAE86" };

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
                    MandatorUID = Guid.Parse(mandatorUidStrings[0]),
                    MeetingDetailDomainModel = meetingDomainModel
                };

                InsertMeetingQueryHandler handler = new InsertMeetingQueryHandler(query, UnityContainer);

                return Request.CreateResponse(HttpStatusCode.Accepted, handler.Handle());
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }

        }

        [HttpDelete]
        [Route("adress/{uid}")]
        public HttpResponseMessage Delete(Guid uid)
        {
            DeleteMeetingQuery query = new DeleteMeetingQuery()
            {
                MeetingUID = uid
            };

            try
            {
                DeleteMeetingQueryHandler handler = new DeleteMeetingQueryHandler(query, UnityContainer);

                handler.Handle();

                return Request.CreateResponse(HttpStatusCode.Accepted);
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}