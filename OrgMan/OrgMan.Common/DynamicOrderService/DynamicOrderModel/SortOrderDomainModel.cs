using OrgMan.Common.DynamicOrderService.DynamicOrderModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.Common.DynamicOrderService.DynamicOrderModel
{
    public class SortOrderDomainModel
    {
        public string Field { get; set; }

        public OrderCriteriaDirectionEnum Direction { get; set; }
    }
}
