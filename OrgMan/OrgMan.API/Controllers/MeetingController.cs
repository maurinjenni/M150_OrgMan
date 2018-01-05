using Newtonsoft.Json.Linq;
using OrgMan.API.Controllers.ControllerBase;
using OrgMan.Common.DynamicSearchService.DynamicSearchModel;
using OrgMan.Domain.Handler.Meeting;
using OrgMan.DomainContracts.Meeting;
using OrgMan.DomainObjects;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrgMan.API.Controllers
{
    public class MeetingController : ApiControllerBase
    {
        [HttpGet]
        [Route("meeting")]
        public HttpResponseMessage Get([FromUri] List<SearchCriteriaDomainModel> searchCriterias = null, [FromUri]int? numberOfRows = null)
        {
            //var mandatorUidStrings = HttpContext.Current.Request.ServerVariables.Get("MandatorUID").Split(',');
            var mandatorUidStrings = new List<string>() { "E91019DA-26C8-B201-1385-0011F6C365E9" };

            List<Guid> mandatorUids = new List<Guid>();

            foreach (var mandatorString in mandatorUidStrings)
            {
                mandatorUids.Add(Guid.Parse(mandatorString));
            }

            SearchMeetingQuery query = new SearchMeetingQuery()
            {
                MandatorUIDs = mandatorUids,
                SearchCriterias = searchCriterias,
                NumberOfRows = numberOfRows
            };

            try
            {
                SearchMeetingQueryHandler handler = new SearchMeetingQueryHandler(query, UnityContainer);
                return Request.CreateResponse(HttpStatusCode.OK, handler.Handle());
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }

        }

        [HttpGet]
        [Route("meeting/{uid}")]
        public HttpResponseMessage Get(Guid uid)
        {
            //var mandatorUidStrings = HttpContext.Current.Request.ServerVariables.Get("MandatorUID").Split(',');
            var mandatorUidStrings = new List<string>() { "72920FF1-4C81-F677-D5EE-00FD566FAE86" };

            List<Guid> mandatorUids = new List<Guid>();

            foreach (var mandatorString in mandatorUidStrings)
            {
                mandatorUids.Add(Guid.Parse(mandatorString));
            }

            GetMeetingQuery query = new GetMeetingQuery()
            {
                MandatorUIDs = mandatorUids,
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
        [Route("meeting")]
        public HttpResponseMessage Post([FromBody] JObject jsonObject)
        {
            //var mandatorUidStrings = HttpContext.Current.Request.ServerVariables.Get("MandatorUID").Split(',');
            var mandatorUidStrings = new List<string>() { "72920FF1-4C81-F677-D5EE-00FD566FAE86" };


            List<Guid> mandatorUids = new List<Guid>();

            foreach (var mandatorString in mandatorUidStrings)
            {
                mandatorUids.Add(Guid.Parse(mandatorString));
            }

            try
            {
                MeetingDetailDomainModel meetinDomainModel = jsonObject.ToObject<MeetingDetailDomainModel>();

                if(meetinDomainModel == null)
                {
                    throw new Exception("Invalid JSON Object");
                }

                UpdateMeetingQuery query = new UpdateMeetingQuery()
                {
                    MandatorUIDs = mandatorUids,
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
        [Route("meeting")]
        public HttpResponseMessage Put([FromBody] JObject jsonObject)
        {
            //var mandatorUidStrings = HttpContext.Current.Request.ServerVariables.Get("MandatorUID").Split(',');
            var mandatorUidStrings = new List<string>() { "72920FF1-4C81-F677-D5EE-00FD566FAE86" };


            List<Guid> mandatorUids = new List<Guid>();

            foreach (var mandatorString in mandatorUidStrings)
            {
                mandatorUids.Add(Guid.Parse(mandatorString));
            }

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
                    MandatorUIDs = mandatorUids,
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
        [Route("meeting/{uid}")]
        public HttpResponseMessage Delete(Guid uid)
        {
            var mandatorUidStrings = new List<string>() { "E91019DA-26C8-B201-1385-0011F6C365E9" };

            List<Guid> mandatorUids = new List<Guid>();

            foreach (var mandatorString in mandatorUidStrings)
            {
                mandatorUids.Add(Guid.Parse(mandatorString));
            }

            DeleteMeetingQuery query = new DeleteMeetingQuery()
            {
                MandatorUIDs = mandatorUids,
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