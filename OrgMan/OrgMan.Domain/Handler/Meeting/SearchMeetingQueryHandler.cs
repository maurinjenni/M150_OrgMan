using Microsoft.Practices.Unity;
using OrgMan.Domain.Handler.HandlerBase;
using OrgMan.DomainContracts.Meeting;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using OrgMan.Common.DynamicSearchService;
using OrgMan.Data.UnitOfWork;
using OrgMan.DomainObjects.Meeting;
using System.Linq;
using OrgMan.Common.DynamicOrderService;
using OrgMan.Common.DynamicOrderService.DynamicOrderModel;

namespace OrgMan.Domain.Handler.Meeting
{
    public class SearchMeetingQueryHandler : QueryHandlerBase
    {
        private readonly SearchMeetingQuery _query;

        public SearchMeetingQueryHandler(SearchMeetingQuery query, IUnityContainer unityContainer) : base(unityContainer)
        {
            _query = query;
        }

        public List<MeetingSearchDomainModel> Handle()
        {
            OrgManUnitOfWork uow = new OrgManUnitOfWork();

            DynamicSearchService searchService = new DynamicSearchService();

            Expression<Func<DataModel.Meeting, bool>> whereExpression = null;

            if (_query.SearchCriterias != null)
            {
                try
                {
                    whereExpression = searchService.GetWhereExpression<DataModel.Meeting>(_query.SearchCriterias);
                }
                catch (Exception)
                {
                    throw new InvalidOperationException("Exception thrown while Building Search Expression from SearchCriteria");
                }
            }

            DynamicOrderService orderService = new DynamicOrderService();

            SortOrderDomainModel orderDomainModel = new SortOrderDomainModel()
            {
                Direction = Common.DynamicOrderService.DynamicOrderModel.Enums.OrderCriteriaDirectionEnum.OrderByDescending,
                Field = "StartDate"
            };

            var orderQuery = orderService.GetOrderBy<DataModel.Meeting>(orderDomainModel);

            var meetings = uow.MeetingRepository.Get(_query.MandatorUIDs, whereExpression, orderQuery, null,_query.NumberOfRows);

            return AutoMapper.Mapper.Map<List<MeetingSearchDomainModel>>(meetings);
        }
    }
}
 