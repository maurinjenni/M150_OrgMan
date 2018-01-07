using Newtonsoft.Json.Linq;
using OrgMan.API.Controllers.ControllerBase;
using OrgMan.Domain.Handler.Picture;
using OrgMan.DomainContracts.Picture;
using OrgMan.DomainObjects.Picture;
using System;
using System.Collections.Generic;
using System.Configuration;
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

            GetPictureQuery query = new GetPictureQuery()
            {
                MandatorUIDs = RequestMandatorUIDs,
                IndividualPersonUID = uid,
                PictureDirectoryPath = ConfigurationManager.AppSettings["PictureDirectoryPath"]
            };

            try
            {
                GetPictureQueryHandler handler = new GetPictureQueryHandler(query, UnityContainer);

                return Request.CreateResponse(HttpStatusCode.Accepted, handler.Handle());
            }
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpDelete]
        [Route("adress/{uid}")]
        public HttpResponseMessage Delete(Guid uid)
        {
            DeletePictureQuery query = new DeletePictureQuery()
            {
                MandatorUIDs = RequestMandatorUIDs,
                PictureDirectoryPath = ConfigurationManager.AppSettings["PictureDirectoryPath"],
                IndividualPersonUID = uid
            };

            try
            {
                DeletePictureQueryHandler handler = new DeletePictureQueryHandler(query, UnityContainer);

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