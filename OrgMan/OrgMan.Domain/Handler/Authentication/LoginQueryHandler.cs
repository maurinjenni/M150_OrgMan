using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using OrgMan.Data.UnitOfWork;
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
            OrgManUnitOfWork uow = new OrgManUnitOfWork();
            Guid personUid = uow.AuthenticationRepository.Login(_query.Username, _query.Password);

            if (personUid != null)
            {
                return Guid.NewGuid();
            }

            throw new UnauthorizedAccessException("Invalid Userinformation");
        }
    }
}
