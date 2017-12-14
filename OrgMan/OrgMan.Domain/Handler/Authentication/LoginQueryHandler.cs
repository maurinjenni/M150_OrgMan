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
    public class LoginQueryHandler : QueryHandlerBase
    {
        private LoginQuery _query;

        public LoginQueryHandler(LoginQuery query, IUnityContainer unityContainer) : base(unityContainer)
        {
            _query = query;
        }

        public Guid Handle()
        {
            return Guid.NewGuid();
        }
    }
}
