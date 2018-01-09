using Newtonsoft.Json.Linq;
using OrgMan.API.Controllers.ControllerBase;
using OrgMan.Domain.Handler.Picture;
using OrgMan.DomainContracts.Picture;
using OrgMan.DomainObjects.Picture;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace OrgMan.API.Controllers
{
    public class PictureController : ApiControllerBase
    {
        [HttpGet]
        [Route("picture/{uid}")]
        public HttpResponseMessage Get(Guid uid)
        {
            try
            {
                GetPictureQuery query = new GetPictureQuery()
                {
                    MandatorUIDs = RequestMandatorUIDs,
                    IndividualPersonUID = uid,
                    PictureDirectoryPath = ConfigurationManager.AppSettings["PictureDirectoryPath"]
                };

                GetPictureQueryHandler handler = new GetPictureQueryHandler(query, UnityContainer);

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
            catch (FileNotFoundException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPost]
        [Route("picture")]
        public HttpResponseMessage Post([FromBody] JObject jsonObject)
        {
            try
            {
                PictureDomainModel pictureDomainModel =
                    jsonObject.ToObject<PictureDomainModel>();

                if (pictureDomainModel == null)
                {
                    throw new Exception("Invalid JSON Object");
                }

                UpdatePictureQuery query = new UpdatePictureQuery()
                {
                    MandatorUIDs = RequestMandatorUIDs,
                    PictureDirectoryPath = ConfigurationManager.AppSettings["PictureDirectoryPath"],
                    Picture = pictureDomainModel
                };

                UpdatePictureQueryHandler handler = new UpdatePictureQueryHandler(query, UnityContainer);

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
            catch (FileNotFoundException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPut]
        [Route("picture")]
        public HttpResponseMessage Put([FromBody] JObject jsonObject)
        {
            try
            {
                PictureDomainModel pictureDomainModel =
                    jsonObject.ToObject<PictureDomainModel>();

                if (pictureDomainModel == null)
                {
                    throw new Exception("Invalid JSON Object");
                }

                InsertPictureQuery query = new InsertPictureQuery()
                {
                    MandatorUIDs = RequestMandatorUIDs,
                    PictureDirectoryPath = ConfigurationManager.AppSettings["PictureDirectoryPath"],
                    Picture = pictureDomainModel
                };

                InsertPictureQueryHandler handler = new InsertPictureQueryHandler(query, UnityContainer);

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
            catch (FileNotFoundException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpDelete]
        [Route("picture/{uid}")]
        public HttpResponseMessage Delete(Guid uid)
        {
            try
            {
                DeletePictureQuery query = new DeletePictureQuery()
                {
                    MandatorUIDs = RequestMandatorUIDs,
                    PictureDirectoryPath = ConfigurationManager.AppSettings["PictureDirectoryPath"],
                    IndividualPersonUID = uid
                };

                DeletePictureQueryHandler handler = new DeletePictureQueryHandler(query, UnityContainer);

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
            catch (FileNotFoundException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}