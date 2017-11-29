using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
