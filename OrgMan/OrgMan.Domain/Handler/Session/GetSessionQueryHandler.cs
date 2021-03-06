﻿using AutoMapper;
using Microsoft.Practices.Unity;
using OrgMan.Data.UnitOfWork;
using OrgMan.Domain.Handler.HandlerBase;
using OrgMan.DomainContracts.Session;
using OrgMan.DomainObjects.Session;

namespace OrgMan.Domain.Handler.Session
{
    public class GetSessionQueryHandler : QueryHandlerBase
    {
        private readonly GetSessionQuery _query;

        public GetSessionQueryHandler(GetSessionQuery query, IUnityContainer unityContainer) : base(unityContainer)
        {
            _query = query;
        }

        public SessionDomainModel Handle()
        {
            OrgManUnitOfWork uow = new OrgManUnitOfWork();

            var session = uow.SessionRepository.Get(_query.SessionUID);

            return Mapper.Map<SessionDomainModel>(session);
        }
    }
}
