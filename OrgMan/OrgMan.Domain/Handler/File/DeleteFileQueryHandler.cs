using Microsoft.Practices.Unity;
using OrgMan.Domain.Handler.HandlerBase;
using OrgMan.DomainContracts.File;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.Domain.Handler.File
{
    public class DeleteFileQueryHandler : QueryHandlerBase
    {
        private readonly DeleteFileQuery _query;

        public DeleteFileQueryHandler(DeleteFileQuery query, IUnityContainer unityContainer) : base(unityContainer)
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

                        if (Directory.Exists(fileSavePath))
                        {
                            fileSavePath = Path.Combine(fileSavePath, _query.FilePath);

                            Directory.Delete(fileSavePath);
                        }

                        throw new FileNotFoundException(string.Format("File {0} does not Exists", fileSavePath));
                    }
                    else
                    {
                        throw new UnauthorizedAccessException("File from another Mandator");
                    }
                }
            }
            catch (UnauthorizedAccessException e)
            {
                throw new UnauthorizedAccessException("Internal Server Error", e);
            }
            catch (FileNotFoundException e)
            {
                throw new FileNotFoundException("Internal Server Error", e);
            }
            catch (Exception)
            {
                throw new Exception("Internal Server Error");
            }
        }
    }
}
