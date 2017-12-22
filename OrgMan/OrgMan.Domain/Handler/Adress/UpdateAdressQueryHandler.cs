using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Practices.Unity;
using OrgMan.Common.DynamicSearchService;
using OrgMan.Data.UnitOfWork;
using OrgMan.Domain.Handler.HandlerBase;
using OrgMan.DomainContracts.Adress;
using OrgMan.DomainObjects.Adress;

namespace OrgMan.Domain.Handler.Adress
{
    public class UpdateAdressQueryHandler : QueryHandlerBase
    {
        private UpdateAdressQuery _query;

        public UpdateAdressQueryHandler(UpdateAdressQuery query, IUnityContainer unityContainer) : base(unityContainer)
        {
            _query = query;
        }

        public void Handle()
        {
            OrgManUnitOfWork uow = new OrgManUnitOfWork();

           uow.AdressRepository.Update(_query.MandatorUID, Mapper.Map<DataModel.Adress>(_query.AdressManagementDetailDomainModel));
        }
    }
}
