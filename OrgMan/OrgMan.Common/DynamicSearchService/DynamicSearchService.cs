using OrgMan.Common.DynamicSearchService.DynamicSearchModel;
using OrgMan.Common.DynamicSearchService.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OrgMan.Common.DynamicSearchService
{
    public class DynamicSearchService : IDynamicSearchExpressionService
    {
        public Expression<Func<T, bool>> GetWhereExpression<T>(List<SearchCriteriaDomainModel> searchCriterias)
        {
            // 0 criterias return null
            if (!searchCriterias.Any())
            {
                return null;
            }

            try
            {
                // convert all Values from Searchcriterias 
                searchCriterias = SearchCriteriaConverter.Convert(searchCriterias);
            }
            catch(FormatException)
            {
                throw new InvalidOperationException("Invalid SearchCriteria... False Format of SearchCriteria");
            }
            catch (Exception)
            {
                // Cant convert an Value
                throw new InvalidOperationException("Invalid SearchCriteria... Exception thrown while Convert SearchCriteria");
            }

            try
            {

                ParameterExpression parameter = Expression.Parameter(typeof(T), typeof(T).Name);
                Expression expression = ExpressionForSearchCriteriasBuilder.GetExpression(searchCriterias, parameter);

                return expression == null ? null : Expression.Lambda<Func<T, bool>>(expression, parameter);
            }
            catch (Exception)
            {
                // Cant build the Expression for the SearchCriterias
                throw new InvalidOperationException("Invalid SearchCriteria... Exception thrown while Building Expression");
            }
        }
    }
}
