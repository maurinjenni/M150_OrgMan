﻿using AutoMapper;
using Microsoft.Practices.Unity;
using OrgMan.Data.UnitOfWork;
using OrgMan.Domain.Handler.HandlerBase;
using OrgMan.DomainContracts.Adress;
using OrgMan.DomainObjects.Adress;

namespace OrgMan.Domain.Handler.Adress
{
    public class GetAdressQueryHandler : QueryHandlerBase
    {
        private readonly GetAdressQuery _query;

        public GetAdressQueryHandler(GetAdressQuery query, IUnityContainer unityContainer) : base(unityContainer)
        {
            _query = query;
        }

        public AdressManagementDetailDomainModel Handle()
        {
            OrgManUnitOfWork uow = new OrgManUnitOfWork();

            var individualPerson = uow.IndividualPersonRepository.Get(_query.MandatorUIDs, _query.AdressUID);

            return Mapper.Map<AdressManagementDetailDomainModel>(individualPerson);
        }
    }
}
