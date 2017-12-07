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
using System.Linq.Expressions;

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

            List<AdressSearchDomainModel> adresses = null;

            Expression<Func<DataModel.Adress, bool>> whereExpression = null;

            if (_query.SearchCriterias != null)
            {
                whereExpression = searchService.GetWhereExpression<DataModel.Adress>(_query.SearchCriterias);
            }

            var items = uow.AdressRepository.Get(_query.MandatorUID, whereExpression, null, "person", _query.NumberOfRows);
            
            adresses = Mapper.Map<List<AdressSearchDomainModel>>(items);

            return adresses;
        }

    }
}