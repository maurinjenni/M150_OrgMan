using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Practices.Unity;
using OrgMan.Data.UnitOfWork;
using OrgMan.Domain.Handler.HandlerBase;
using OrgMan.DomainContracts.Adress;
using OrgMan.DomainObjects.Adress;

namespace OrgMan.Domain.Handler.Adress
{
    public class GetAdressQueryHandler : QueryHandlerBase
    {
        private GetAdressQuery _query;

        public GetAdressQueryHandler(GetAdressQuery query, IUnityContainer unityContainer) : base(unityContainer)
        {
            _query = query;
        }

        public AdressSearchDomainModel Handle()
        {
            OrgManUnitOfWork uow = new OrgManUnitOfWork();

            var adresse = uow.AdressRepository.Get(_query.MandatorUID,_query.AdressUID);

            return Mapper.Map<AdressSearchDomainModel>(adresse);
        }

    }
}
