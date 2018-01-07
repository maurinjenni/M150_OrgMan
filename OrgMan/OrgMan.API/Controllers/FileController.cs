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
            //var mandatorUidStrings = HttpContext.Current.Request.ServerVariables.Get("MandatorUID").Split(',');
            var mandatorUidStrings = new List<string>() { "E91019DA-26C8-B201-1385-0011F6C365E9" };

            List<Guid> mandatorUids = new List<Guid>();

            foreach (var mandatorString in mandatorUidStrings)
            {
                mandatorUids.Add(Guid.Parse(mandatorString));
            }

            GetFileTreeQuery query = new GetFileTreeQuery()
            {
                MandatorUIDs = mandatorUids,
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
                Path = path
            };

            try
            {
                string fileMandatorUidString = query.Path.Split('\\')[0];
                Guid fileMandatorUid = Guid.Empty;

                if (Guid.TryParse(fileMandatorUidString, out fileMandatorUid))
                {
                    if (query.MandatorUIDs.Contains(fileMandatorUid))
                    {
                        OrgManUnitOfWork uow = new OrgManUnitOfWork();

                        string combinedPath = Path.Combine(ConfigurationManager.AppSettings["FileSystemDirectory"], query.Path);

                        if (!File.Exists(combinedPath))
                        {
                            throw new Exception("The file does not exist.");
                        }

                        HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK)
                        {
                            Content = new StreamContent(new FileStream(combinedPath, FileMode.Open, FileAccess.Read))
                        };

                        result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                        {
                            FileName = Path.GetFileName(combinedPath)
                        };

                        result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                        return result;
                    }
                }

                return null;
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
                }

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Invalid File");
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