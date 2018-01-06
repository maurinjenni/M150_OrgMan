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

        public void Handle()
        {

        }
    }
}
