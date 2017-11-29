using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.Common.LinqExpressionService
{
    public interface ILinqExpressionService<T>
    {
        Expression<Func<T, object>> GetParameterExpression(Type type, string property);
    }
}
