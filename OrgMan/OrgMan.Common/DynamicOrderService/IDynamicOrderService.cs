using OrgMan.Common.DynamicOrderService.DynamicOrderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.Common.DynamicOrderService
{
    interface IDynamicOrderService
    {
        Func<IQueryable<T>, IOrderedQueryable<T>> GetOrderBy<T>(SortOrderDomainModel sortOrder);
    }
}
