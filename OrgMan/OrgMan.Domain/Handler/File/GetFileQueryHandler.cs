using Microsoft.Practices.Unity;
using OrgMan.Domain.Handler.HandlerBase;
using OrgMan.DomainContracts.File;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.Domain.Handler.File
{
    public class GetFileQueryHandler : QueryHandlerBase
    {
        private readonly GetFileQuery _query;

        public GetFileQueryHandler(GetFileQuery query, IUnityContainer unityContainer) : base(unityContainer)
        {
            _query = query;
        }

        public StreamContent Handle()
        {
            try
            {
                string fileMandatorUidString = _query.Path.Split('\\')[0];
                Guid fileMandatorUid = Guid.Empty;

                if (Guid.TryParse(fileMandatorUidString, out fileMandatorUid))
                {
                    if (_query.MandatorUIDs.Contains(fileMandatorUid))
                    {
                        string combinedPath = Path.Combine(_query.FileSystemDirectoryPath, _query.Path);

                        if (System.IO.File.Exists(combinedPath))
                        {
                            StreamContent stream = new StreamContent(new FileStream(combinedPath, FileMode.Open, FileAccess.Read));

                            return stream;
                        }

                        throw new FileNotFoundException(string.Format("File {0} does not Exists", combinedPath));
                    }
                    else
                    {
                        throw new UnauthorizedAccessException("File from another Mandator");
                    }
                }
                else
                {
                    throw new FormatException("Invalid Guid Format from file path");
                }
            }
            catch (UnauthorizedAccessException e)
            {
                throw new Exception("Unauthorized Access", e);
            }
            catch(InvalidOperationException e)
            {
                throw new Exception("Internal Server Error during loading the File", e);
            }
            catch(FormatException e)
            {
                throw new Exception("Internal Server Error during loading the File", e);
            }
            catch (Exception)
            {
                throw new Exception("Internal Server Error");
            }
        }
    }
}
