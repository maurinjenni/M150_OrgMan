﻿using Microsoft.Practices.Unity;
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
    public class DeleteFileQueryHandler : QueryHandlerBase
    {
        private readonly DeleteFileQuery _query;

        public DeleteFileQueryHandler(DeleteFileQuery query, IUnityContainer unityContainer) : base(unityContainer)
        {
            _query = query;
        }

        public void Handle()
        {
            foreach (Guid fileMandatorUid in _query.FileMandatorUIDs)
            {
                if (_query.MandatorUIDs.Contains(fileMandatorUid))
                {
                    string fileSavePath = Path.Combine(_query.FileSystemDirectoryPath, fileMandatorUid.ToString());

                    if (!Directory.Exists(fileSavePath))
                    {
                        return;
                    }

                    fileSavePath = Path.Combine(fileSavePath, _query.FilePath);

                    Directory.Delete(fileSavePath);
                }
            }
        }
    }
}
