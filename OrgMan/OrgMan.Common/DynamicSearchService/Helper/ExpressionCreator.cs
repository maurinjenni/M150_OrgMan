using OrgMan.Common.DynamicSearchService.DynamicSearchModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.Common.DynamicSearchService.Helper
{
    public class ExpressionCreator
    {
        public static Expression GetExpression(SearchCriteriaOperationTypeDomainModelEnum searchOperation, Expression member,
            List<ConstantExpression> constants)
        {
            Expression searchCriteria = Expression.Convert(constants[0], member.Type);

            switch (searchOperation)
            {
                case SearchCriteriaOperationTypeDomainModelEnum.Equals:
                    return Expression.Equal(member, searchCriteria);

                case SearchCriteriaOperationTypeDomainModelEnum.NotEquals:
                    {
                        if (member.Type == typeof(string))
                        {
                            return Expression.OrElse(Expression.Equal(member, Expression.Constant(null, member.Type)),
                                Expression.NotEqual(member, searchCriteria));
                        }
                        else
                        {
                            return null;
                        }
                    }

                case SearchCriteriaOperationTypeDomainModelEnum.GreaterThan:
                    return Expression.GreaterThan(member, searchCriteria);

                case SearchCriteriaOperationTypeDomainModelEnum.GreaterThanOrEqual:
                    return Expression.GreaterThanOrEqual(member, searchCriteria);

                case SearchCriteriaOperationTypeDomainModelEnum.LessThan:
                    return Expression.LessThan(member, searchCriteria);

                case SearchCriteriaOperationTypeDomainModelEnum.LessThanOrEqual:
                    return Expression.LessThanOrEqual(member, searchCriteria);

                case SearchCriteriaOperationTypeDomainModelEnum.Contains:
                    return Expression.Call(member, typeof(string).GetMethod("Contains"), searchCriteria);

                case SearchCriteriaOperationTypeDomainModelEnum.StartsWith:
                    return Expression.Call(member, typeof(string).GetMethod("StartsWith", new[] { typeof(string) }), searchCriteria);

                case SearchCriteriaOperationTypeDomainModelEnum.EndsWith:
                    return Expression.Call(member, typeof(string).GetMethod("EndsWith", new[] { typeof(string) }), searchCriteria);

                case SearchCriteriaOperationTypeDomainModelEnum.Between:
                    return Expression.AndAlso(Expression.GreaterThanOrEqual(member, searchCriteria),
                        Expression.LessThanOrEqual(member, Expression.Convert(constants[1], member.Type)));

                case SearchCriteriaOperationTypeDomainModelEnum.ListContains:
                    {
                        var expression = Expression.Equal(member, Expression.Convert(constants[0], member.Type));

                        foreach (ConstantExpression constant in constants)
                        {
                            expression = Expression.Or(expression,
                                Expression.Equal(member, Expression.Convert(constant, member.Type)));
                        }

                        return expression;
                    }

                case SearchCriteriaOperationTypeDomainModelEnum.ListContainsNot:
                    {
                        var expression = Expression.NotEqual(member, Expression.Convert(constants[0], member.Type));

                        foreach (ConstantExpression constant in constants)
                        {
                            expression = Expression.And(expression,
                                Expression.NotEqual(member, Expression.Convert(constant, member.Type)));
                        }

                        if (member.Type == typeof(string))
                        {
                            return Expression.OrElse(Expression.Equal(member, Expression.Constant(null, member.Type)),
                                expression);
                        }

                        return expression;
                    }
            }

            return null;
        }
    }
}
