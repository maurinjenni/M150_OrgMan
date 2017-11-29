using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.Common.DynamicSearchService.DynamicSearchModel.Enums
{
    public enum SearchCriteriaOperationTypeDomainModelEnum
    {
        Equals = 0,

        NotEquals = 1,

        GreaterThan = 2,

        LessThan = 3,

        GreaterThanOrEqual = 4,

        LessThanOrEqual = 5,

        Contains = 6,

        StartsWith = 7,

        EndsWith = 8,

        Between = 9,

        ListContains = 10,

        ListContainsNot = 11
    }
}
