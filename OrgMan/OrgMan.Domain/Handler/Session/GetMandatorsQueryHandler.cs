using Microsoft.Practices.Unity;
using OrgMan.Data.UnitOfWork;
using OrgMan.Domain.Handler.HandlerBase;
using OrgMan.DomainContracts.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.Domain.Handler.Session
{
    public class GetMandatorsQueryHandler : QueryHandlerBase
    {
        private GetMandatorsQuery _query;

        public GetMandatorsQueryHandler (GetMandatorsQuery query, IUnityContainer unityContainer) : base(unityContainer)
        {
            _query = query;
        }

        public List<Guid> Handle()
        {
            OrgManUnitOfWork uow = new OrgManUnitOfWork();

            return uow.SessionRepository.Get(_query.SessionUID).MandatorUIDs.ToList();
        }
    }
}
