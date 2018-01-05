using System;
using Microsoft.Practices.Unity;
using OrgMan.Data.UnitOfWork;
using OrgMan.Domain.Handler.HandlerBase;
using OrgMan.DomainContracts.Session;

namespace OrgMan.Domain.Handler.Session
{
    public class UpdateSessionQueryHandler : QueryHandlerBase
    {
        private readonly UpdateSessionQuery _query;

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
            uow.SessionRepository.Update(session);

            uow.Commit();
        }
    }
}
