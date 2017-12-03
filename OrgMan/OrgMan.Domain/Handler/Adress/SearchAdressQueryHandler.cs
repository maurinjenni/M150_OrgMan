using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.Practices.Unity;
using OrgMan.Common.DynamicSearchService;
using OrgMan.Data.UnitOfWork;
using OrgMan.Domain.Handler.HandlerBase;
using OrgMan.DomainContracts.Adress;
using OrgMan.DomainObjects.Adress;

namespace OrgMan.Domain.Handler.Adress
{
    public class SearchAdressQueryHandler : QueryHandlerBase
    {
        private SearchAdressQuery _query;

        public SearchAdressQueryHandler(SearchAdressQuery query, IUnityContainer unityContainer) : base(unityContainer)
        {
            _query = query;
        }

        public List<AdressSearchDomainModel> Handle()
        {
            OrgManUnitOfWork uow = new OrgManUnitOfWork();

            DynamicSearchService searchService = new DynamicSearchService();
            

            var adresses = uow.AdressRepository.Get(_query.MandatorUID, searchService.GetWhereExpression<DataModel.Adress>(_query.SearchCriterias), null, null, _query.NumberOfRows);

            return Mapper.Map<List<AdressSearchDomainModel>>(adresses);
        }

    }
}