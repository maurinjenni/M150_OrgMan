using Microsoft.Practices.Unity;
using OrgMan.Domain.Handler.HandlerBase;
using OrgMan.DomainContracts.Meeting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.Domain.Handler.Meeting
{
    public class SearchMeetingQueryHandler : QueryHandlerBase
    {
        private SearchMeetingQuery _query;

        public SearchMeetingQueryHandler(SearchMeetingQuery query, IUnityContainer unityContainer) : base(unityContainer)
        {
            _query = query;
        }

        public void Handle()
        {

        }
    }
}
