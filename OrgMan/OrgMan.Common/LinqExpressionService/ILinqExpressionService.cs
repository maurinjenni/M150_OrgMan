using System;
using System.Linq.Expressions;

namespace OrgMan.Common.LinqExpressionService
{
    public interface ILinqExpressionService<T>
    {
        Expression<Func<T, object>> GetParameterExpression(Type type, string property);
    }
}
