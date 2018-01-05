using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
