using System;
using System.Collections.Generic;
using OrgMan.Common.DynamicSearchService.DynamicSearchModel;

namespace OrgMan.DomainContracts.Adress
{
    public class SearchAdressQuery
    {
        public List<Guid> MandatorUIDs { get; set; }

        public List<SearchCriteriaDomainModel> SearchCriterias { get; set; }

        public int? NumberOfRows { get; set; }
    }
}
