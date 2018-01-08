using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using OrgMan.Data.UnitOfWork;
using OrgMan.Domain.Handler.HandlerBase;
using OrgMan.DomainContracts.Adress;
using OrgMan.DomainObjects.Adress;

namespace OrgMan.Domain.Handler.Adress
{
    public class FullTextSearchAdressQueryHandler : QueryHandlerBase
    {
        private FullTextSearchAdressQuery _query;

        public FullTextSearchAdressQueryHandler(FullTextSearchAdressQuery query, IUnityContainer unityContainer)
            : base(unityContainer)
        {
            _query = query;
        }

        public List<AdressManagementSearchDomainModel> Handle()
        {
            OrgManUnitOfWork uow = new OrgManUnitOfWork();

            return AutoMapper.Mapper.Map<List<AdressManagementSearchDomainModel>>(uow.IndividualPersonRepository.Get(_query.MandatorUids, _query.SeachText));
        }
    }
}
