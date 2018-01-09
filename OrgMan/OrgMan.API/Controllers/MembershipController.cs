using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.Practices.Unity;
using Newtonsoft.Json.Linq;
using OrgMan.API.Controllers.ControllerBase;
using OrgMan.Common.DynamicSearchService.DynamicSearchModel;
using OrgMan.Domain.Handler.Membership;
using OrgMan.DomainContracts.Membership;
using OrgMan.DomainObjects.Common;

namespace OrgMan.API.Controllers
{
    public class MembershipController : ApiControllerBase
    {
        [HttpGet]
        [Route("membership")]
        public HttpResponseMessage Get()
        {
            try
            {
                GetAllMembershipsQuery qurey = new GetAllMembershipsQuery()
                {
                    MandatorUIDs = RequestMandatorUIDs
                };

                GetAllMembershipsQueryHandler handler = new GetAllMembershipsQueryHandler(qurey, UnityContainer);

                return Request.CreateResponse(HttpStatusCode.OK, handler.Handle());
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpGet]
        [Route("membership/{uid}")]
        public HttpResponseMessage Get(Guid uid)
        {
            try
            {
                GetMembershipQuery query = new GetMembershipQuery()
                {
                    MandatorUIDs = RequestMandatorUIDs,
                    MembershipUID = uid,
                };

                GetMembershipQueryHandler handler = new GetMembershipQueryHandler(query, UnityContainer);

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

        [HttpPost]
        [Route("membership")]
        public HttpResponseMessage Post([FromBody] JObject jsonObject)
        {
            try
            {
                MembershipDomainModel membershipDomainModel = jsonObject.ToObject<MembershipDomainModel>();

                if (membershipDomainModel == null)
                {
                    throw new Exception("Invalid JSON Object");
                }

                UpdateMembershipQuery query = new UpdateMembershipQuery()
                {
                    MandatorUIDs = RequestMandatorUIDs,
                    MembershipDomainModel = membershipDomainModel
                };

                UpdateMembershipQueryHandler handler = new UpdateMembershipQueryHandler(query, UnityContainer);

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

        [HttpPut]
        [Route("membership")]
        public HttpResponseMessage Put([FromBody] JObject jsonObject)
        {
            try
            {
                MembershipDomainModel membershipDomainModel = jsonObject.ToObject<MembershipDomainModel>();

                if (membershipDomainModel == null)
                {
                    throw new Exception("Invalid JSON Object");
                }

                InsertMembershipQuery query = new InsertMembershipQuery()
                {
                    MandatorUIDs = RequestMandatorUIDs,
                    MembershipDomainModel = membershipDomainModel
                };

                InsertMembershipQueryHandler handler = new InsertMembershipQueryHandler(query, UnityContainer);

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
        [Route("membership/{uid}")]
        public HttpResponseMessage Delete(Guid uid)
        {
            try
            {
                DeleteMembershipQuery query = new DeleteMembershipQuery()
                {
                    MandatorUIDs = RequestMandatorUIDs,
                    MembershipUID = uid,
                };

                DeleteMembershipQueryHandler handler = new DeleteMembershipQueryHandler(query, UnityContainer);

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