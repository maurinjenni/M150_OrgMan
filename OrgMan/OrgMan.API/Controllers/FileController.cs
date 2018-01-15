using OrgMan.API.Controllers.ControllerBase;
using OrgMan.Data.UnitOfWork;
using OrgMan.Domain.Handler.File;
using OrgMan.DomainContracts.File;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
        [Route("api/file")]
        public HttpResponseMessage Get()
        {
            try
            {
                GetFileTreeQuery query = new GetFileTreeQuery()
                {
                    MandatorUIDs = RequestMandatorUIDs,
                    DirectoryPath = ConfigurationManager.AppSettings["FileSystemDirectory"]
                };

                GetFileTreeQueryHandler handler = new GetFileTreeQueryHandler(query, UnityContainer);

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
            catch (FileNotFoundException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpGet]
        [Route("api/file")]
        public HttpResponseMessage Get([FromUri]string path)
        {
            try
            {
                GetFileQuery query = new GetFileQuery()
                {
                    MandatorUIDs = RequestMandatorUIDs,
                    FileSystemDirectoryPath = ConfigurationManager.AppSettings["FileSystemDirectory"],
                    Path = path
                };

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
        [Route("api/file")]
        public HttpResponseMessage Upload([FromUri]List<Guid> fileMandatorUids)
        {
            try
            {
                if (HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    var httpUploadedFile = HttpContext.Current.Request.Files["UploadFile"];

                    if (httpUploadedFile != null)
                    {
                        UploadFileQuery query = new UploadFileQuery()
                        {
                            MandatorUIDs = RequestMandatorUIDs,
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
            catch (UnauthorizedAccessException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, e);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }


        [HttpDelete]
        [Route("api/file/{uid}")]
        public HttpResponseMessage Delete([FromUri]List<Guid> fileMandatorUids, [FromUri]string filePath)
        {
            try
            {
                DeleteFileQuery query = new DeleteFileQuery()
                {
                    MandatorUIDs = RequestMandatorUIDs,
                    FilePath = filePath,
                    FileMandatorUIDs = fileMandatorUids,
                    FileSystemDirectoryPath = ConfigurationManager.AppSettings["FileSystemDirectory"]
                };

                DeleteFileQueryHandler handler = new DeleteFileQueryHandler(query, UnityContainer);

                handler.Handle();

                return Request.CreateResponse(HttpStatusCode.Accepted);
            }
            catch (UnauthorizedAccessException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, e);
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