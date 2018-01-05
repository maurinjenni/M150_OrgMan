using System;
using System.Collections.Generic;

namespace OrgMan.DomainContracts.Meeting
{
    public class GetMeetingQuery
    {
        public Guid MeetingUID { get; set; }

        public List<Guid> MandatorUIDs { get; set; }
    }
}
