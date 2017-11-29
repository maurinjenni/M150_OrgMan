using OrgMan.Common.DynamicSearchService.DynamicSearchModel;
using OrgMan.Common.DynamicSearchService.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
            catch (Exception e)
            {
                // Cant convert an Value
                throw new Exception("Invalid SearchCriteria... Exception thrown while Convert SearchCriteria", e);
            }

            try
            {

                ParameterExpression parameter = Expression.Parameter(typeof(T), typeof(T).Name);
                Expression expression = ExpressionForSearchCriteriasBuilder.GetExpression(searchCriterias, parameter);
                return expression == null ? null : Expression.Lambda<Func<T, bool>>(expression, parameter);
            }
            catch (Exception e)
            {
                // Cant build the Expression for the SearchCriterias
                throw new Exception("Invalid SearchCriteria... Exception thrown while Building Expression", e);
            }
        }
    }
}
