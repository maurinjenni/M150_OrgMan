using Microsoft.Practices.Unity;
using OrgMan.Data.UnitOfWork;
using OrgMan.Domain.Handler.HandlerBase;
using OrgMan.DomainContracts.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.Domain.Handler.Authentication
{
    public class DeleteSessionQueryHandler : QueryHandlerBase
    {
        private DeleteSessionQuery _query;

        public DeleteSessionQueryHandler(DeleteSessionQuery query, IUnityContainer unityContainer) : base(unityContainer)
        {
            _query = query;
        }

        public void Handle()
        {
            OrgManUnitOfWork uow = new OrgManUnitOfWork();

            uow.SessionRepository.Delete(_query.MandatorUIDs, _query.SessionUID);

            uow.Commit();
        }
    }
}
