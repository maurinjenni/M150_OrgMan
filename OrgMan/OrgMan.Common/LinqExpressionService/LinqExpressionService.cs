using System;
using System.Linq.Expressions;

namespace OrgMan.Common.LinqExpressionService
{
    public class LinqExpressionService<T> : ILinqExpressionService<T>
    {
        // https://www.codeproject.com/Articles/1079028/Build-Lambda-Expressions-Dynamically
        public Expression<Func<T, object>> GetParameterExpression(Type type, string property)
        {
            ParameterExpression parameter =  Expression.Parameter(type, type.Name);

            MemberExpression member =  Expression.Property(parameter, property);

            LambdaExpression lambda = Expression.Lambda(typeof(T), member);

            return (Expression<Func<T, object>>)lambda;
        }
    }
}
