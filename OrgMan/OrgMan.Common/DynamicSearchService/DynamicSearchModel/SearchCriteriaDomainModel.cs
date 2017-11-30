using OrgMan.Common.DynamicSearchService.DynamicSearchModel.Enums;
using System.Collections.Generic;

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
