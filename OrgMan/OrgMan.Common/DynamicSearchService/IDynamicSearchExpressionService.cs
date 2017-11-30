using OrgMan.Common.DynamicSearchService.DynamicSearchModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OrgMan.Common.DynamicSearchService
{
    public interface IDynamicSearchExpressionService
    {
        Expression<Func<T, bool>> GetWhereExpression<T>(List<SearchCriteriaDomainModel> searchCriterias);
    }
}
