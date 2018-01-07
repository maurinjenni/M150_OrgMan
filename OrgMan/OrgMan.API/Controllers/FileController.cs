using OrgMan.API.Controllers.ControllerBase;
using OrgMan.Data.UnitOfWork;
using OrgMan.Domain.Handler.File;
using OrgMan.DomainContracts.File;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace OrgMan.API.Controllers
{
    public class FileController : ApiControllerBase
    {
        [HttpGet]
        [Route("file")]
        public HttpResponseMessage Get()
        {
            GetFileTreeQuery query = new GetFileTreeQuery()
            {
                MandatorUIDs = RequestMandatorUIDs,
                DirectoryPath = ConfigurationManager.AppSettings["FileSystemDirectory"]
            };

            try
            {
                GetFileTreeQueryHandler handler = new GetFileTreeQueryHandler(query, UnityContainer);

                return Request.CreateResponse(HttpStatusCode.OK, handler.Handle());
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }

        }

        [HttpGet]
        [Route("file")]
        public HttpResponseMessage Get([FromUri]string path)
        {
            //var mandatorUidStrings = HttpContext.Current.Request.ServerVariables.Get("MandatorUID").Split(',');
            var mandatorUidStrings = new List<string>() { "72920FF1-4C81-F677-D5EE-00FD566FAE86" };

            List<Guid> mandatorUids = new List<Guid>();

            foreach (var mandatorString in mandatorUidStrings)
            {
                mandatorUids.Add(Guid.Parse(mandatorString));
            }

            GetFileQuery query = new GetFileQuery()
            {
                MandatorUIDs = mandatorUids,
                FileSystemDirectoryPath = ConfigurationManager.AppSettings["FileSystemDirectory"],
                Path = path
            };

            try
            {
                GetFileQueryHandler handler = new GetFileQueryHandler(query, UnityContainer);

                var response = Request.CreateResponse(HttpStatusCode.OK);

                response.Content = handler.Handle();

                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = Path.GetFileName(query.Path)
                };

                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                return response;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPut]
        [Route("file")]
        public HttpResponseMessage Upload([FromUri]List<Guid> fileMandatorUids)
        {
            //var mandatorUidStrings = HttpContext.Current.Request.ServerVariables.Get("MandatorUID").Split(',');
            var mandatorUidStrings = new List<string>() { "76cb37fc-1128-4a21-ad93-248bf198a857" };

            List<Guid> mandatorUids = new List<Guid>();

            foreach (var mandatorString in mandatorUidStrings)
            {
                mandatorUids.Add(Guid.Parse(mandatorString));
            }

            try
            {
                if (HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    var httpUploadedFile = HttpContext.Current.Request.Files["UploadFile"];

                    if (httpUploadedFile != null)
                    {
                        UploadFileQuery query = new UploadFileQuery()
                        {
                            MandatorUIDs = mandatorUids,
                            FileMandatorUIDs = fileMandatorUids,
                            File = httpUploadedFile,
                            FileSystemDirectoryPath = ConfigurationManager.AppSettings["FileSystemDirectory"]
                        };

                        UploadFileQueryHandler handler = new UploadFileQueryHandler(query, UnityContainer);
                        
                        handler.Handle();

                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        throw new Exception("Invalid File");
                    }
                }
                else
                {
                    throw new Exception("Invalid File");
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Invalid File");
            }
        }


        [HttpDelete]
        [Route("file/{uid}")]
        public HttpResponseMessage Delete([FromUri]List<Guid> fileMandatorUids, [FromUri]string filePath)
        {
            var mandatorUidStrings = new List<string>() { "E91019DA-26C8-B201-1385-0011F6C365E9" };

            List<Guid> mandatorUids = new List<Guid>();

            foreach (var mandatorString in mandatorUidStrings)
            {
                mandatorUids.Add(Guid.Parse(mandatorString));
            }

            DeleteFileQuery query = new DeleteFileQuery()
            {
                MandatorUIDs = mandatorUids,
                FilePath = filePath,
                FileMandatorUIDs = fileMandatorUids,
                FileSystemDirectoryPath = ConfigurationManager.AppSettings["FileSystemDirectory"]
            };

            try
            {
                DeleteFileQueryHandler handler = new DeleteFileQueryHandler(query, UnityContainer);

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