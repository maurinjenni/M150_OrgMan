using Microsoft.Practices.Unity;
using OrgMan.Domain.Handler.HandlerBase;
using OrgMan.DomainContracts.File;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.Domain.Handler.File
{
    public class UploadFileQueryHandler : QueryHandlerBase
    {
        private UploadFileQuery _query;

        public UploadFileQueryHandler(UploadFileQuery query, IUnityContainer unityContainer) : base(unityContainer)
        {
            _query = query;
        }

        public void Handle()
        {
            try
            {
                foreach (Guid fileMandatorUid in _query.FileMandatorUIDs)
                {
                    if (_query.MandatorUIDs.Contains(fileMandatorUid))
                    {
                        string fileSavePath = Path.Combine(_query.FileSystemDirectoryPath, fileMandatorUid.ToString());

                        if (!Directory.Exists(fileSavePath))
                        {
                            Directory.CreateDirectory(fileSavePath);
                        }

                        fileSavePath = Path.Combine(fileSavePath, _query.File.FileName);

                        _query.File.SaveAs(fileSavePath);
                    }
                    else
                    {
                        throw new UnauthorizedAccessException("File from another Mandator");
                    }
                }
            }
            catch (UnauthorizedAccessException e)
            {
                throw new Exception("Unauthorized Access", e);
            }
            catch (Exception)
            {
                throw new Exception("Internal Server Error");
            }
        }
    }
}

