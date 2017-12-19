using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using OrgMan.Data.UnitOfWork;
using OrgMan.Domain.Handler.HandlerBase;
using OrgMan.DomainContracts.Session;
using OrgMan.DomainObjects.Session;

namespace OrgMan.Domain.Handler.Session
{
    public class UpdateSessionQueryHandler : QueryHandlerBase
    {
        private UpdateSessionQuery _query;

        public UpdateSessionQueryHandler(UpdateSessionQuery query, IUnityContainer unityContainer)
            : base(unityContainer)
        {
            _query = query;
        }

        public void Handle()
        {
            DataModel.Session session = AutoMapper.Mapper.Map<DataModel.Session>(_query.Session);
            session.SysUpdateTime = DateTimeOffset.Now;
            session.SysUpdateAccountUID = Guid.NewGuid();

            OrgManUnitOfWork uow = new OrgManUnitOfWork();
            uow.SessionRepository.Update(Guid.Empty, session);

            uow.Commit();
        }
    }
}
