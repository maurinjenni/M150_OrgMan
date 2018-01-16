using OrgMan.Common.DynamicOrderService.DynamicOrderModel;
using OrgMan.Common.DynamicOrderService.DynamicOrderModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.Common.DynamicOrderService
{
    public class DynamicOrderService : IDynamicOrderService
    {
        public Func<IQueryable<T>, IOrderedQueryable<T>> GetOrderBy<T>(SortOrderDomainModel sortOrder)
        {
            Type typeQueryable = typeof(IQueryable<T>);
            ParameterExpression argQueryable = Expression.Parameter(typeQueryable, "p");
            var outerExpression = Expression.Lambda(argQueryable, argQueryable);
            string[] props = sortOrder.Field.Split('.');
            IQueryable<T> query = new List<T>().AsQueryable<T>();
            Type type = typeof(T);
            ParameterExpression arg = Expression.Parameter(type, "x");

            Expression expr = arg;
            foreach (string prop in props)
            {
                PropertyInfo pi = type.GetProperty(prop, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            }
            LambdaExpression lambda = Expression.Lambda(expr, arg);
            string methodName = sortOrder.Direction == OrderCriteriaDirectionEnum.OrderBy ? "OrderBy" : "OrderByDescending";

            MethodCallExpression resultExp =
                Expression.Call(typeof(Queryable), methodName, new Type[] { typeof(T), type }, outerExpression.Body, Expression.Quote(lambda));
            var finalLambda = Expression.Lambda(resultExp, argQueryable);
            return (Func<IQueryable<T>, IOrderedQueryable<T>>)finalLambda.Compile();
        }
    }
}
