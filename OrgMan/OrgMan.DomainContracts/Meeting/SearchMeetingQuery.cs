using System;
using System.Collections.Generic;
using OrgMan.Common.DynamicSearchService.DynamicSearchModel;

namespace OrgMan.DomainContracts.Meeting
{
    public class SearchMeetingQuery
    {
        public List<Guid> MandatorUIDs { get; set; }

        public List<SearchCriteriaDomainModel> SearchCriterias { get; set; }

        public int? NumberOfRows { get; set; }
    }
}
