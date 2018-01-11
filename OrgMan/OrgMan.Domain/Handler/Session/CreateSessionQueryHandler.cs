using System;
using AutoMapper;
using Microsoft.Practices.Unity;
using OrgMan.Data.UnitOfWork;
using OrgMan.Domain.Handler.HandlerBase;
using OrgMan.DomainContracts.Session;

namespace OrgMan.Domain.Handler.Session
{
    public class CreateSessionQueryHandler : QueryHandlerBase
    {
        private readonly CreateSessionQuery _query;

        public CreateSessionQueryHandler(CreateSessionQuery query, IUnityContainer unityContainer)
            : base(unityContainer)
        {
            _query = query;
        }

        public Guid Handle()
        {
            DataModel.Session session = Mapper.Map<DataModel.Session>(_query.Session);

            session.UID = Guid.NewGuid();
            session.SysInsertTime = DateTimeOffset.Now;
            session.SysInsertAccountUID = Guid.NewGuid();            

            OrgManUnitOfWork uow = new OrgManUnitOfWork();
            uow.SessionRepository.Insert(session);
            uow.Commit();
            return session.UID;
        }
    }
}
