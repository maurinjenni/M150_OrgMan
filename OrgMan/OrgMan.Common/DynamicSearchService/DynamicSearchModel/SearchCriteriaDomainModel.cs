using OrgMan.Common.DynamicSearchService.DynamicSearchModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.Common.DynamicSearchService.DynamicSearchModel
{
    public class SearchCriteriaDomainModel
    {
        public string Title { get; set; }

        public string FieldName { get; set; }

        public List<object> Values { get; set; }

        public SearchCriteriaDataTypeDomainModelEnum DataType { get; set; }

        public SearchCriteriaOperationTypeDomainModelEnum OperationType { get; set; }
    }
}
