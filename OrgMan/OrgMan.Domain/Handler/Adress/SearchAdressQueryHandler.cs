using System;
using System.Collections.Generic;
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

        public List<AdressManagementSearchDomainModel> Handle()
        {
            try
            {
                OrgManUnitOfWork uow = new OrgManUnitOfWork();

                DynamicSearchService searchService = new DynamicSearchService();

                List<AdressManagementSearchDomainModel> adresses = null;

                Expression<Func<DataModel.IndividualPerson, bool>> whereExpression = null;

                if (_query.SearchCriterias != null)
                {
                    try
                    {
                        whereExpression = searchService.GetWhereExpression<DataModel.IndividualPerson>(_query.SearchCriterias);
                    }
                    catch(Exception e)
                    {
                        throw new InvalidOperationException("Exception thrown while Building Search Expression from SearchCriteria");
                    }
                }

                var items = uow.IndividualPersonRepository.Get(_query.MandatorUID, whereExpression, null, "Person, Person.PersonToMandators, MemberInformation, Adress", _query.NumberOfRows);

                adresses = Mapper.Map<List<AdressManagementSearchDomainModel>>(items);

                return adresses;
            }
            catch (InvalidOperationException e)
            {
                throw new Exception("Internal Server Error", e);
            }
            catch (Exception e)
            {
                throw new Exception("Internal Server Error");
            }
        }
    }
}