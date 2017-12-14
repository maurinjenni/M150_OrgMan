using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using OrgMan.Domain.Handler.HandlerBase;
using OrgMan.DomainContracts.Authentication;

namespace OrgMan.Domain.Handler.Authentication
{
    public class LogoutQueryHandler : QueryHandlerBase
    {
        private LogoutQuery _query;
        public LogoutQueryHandler(LogoutQuery query, IUnityContainer unityContainer) : base(unityContainer)
        {
            _query = query;
        }

        public void Handle()
        {
            return;
        }
    }
}
