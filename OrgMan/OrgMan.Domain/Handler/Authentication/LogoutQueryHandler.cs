using Microsoft.Practices.Unity;
using OrgMan.Data.UnitOfWork;
using OrgMan.Domain.Handler.HandlerBase;
using OrgMan.DomainContracts.Authentication;

namespace OrgMan.Domain.Handler.Authentication
{
    public class LogoutQueryHandler : QueryHandlerBase
    {
        private readonly LogoutQuery _query;

        public LogoutQueryHandler(LogoutQuery query, IUnityContainer unityContainer) : base(unityContainer)
        {
            _query = query;
        }

        public void Handle()
        {
            OrgManUnitOfWork uow = new OrgManUnitOfWork();

            //uow.AuthenticationRepository.Logout(_query.SessionUID);
        }
    }
}
