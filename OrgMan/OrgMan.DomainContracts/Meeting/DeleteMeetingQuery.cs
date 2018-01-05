using System;
using System.Collections.Generic;

namespace OrgMan.DomainContracts.Meeting
{
    public class DeleteMeetingQuery
    {
        public List<Guid> MandatorUIDs { get; set; }

        public Guid MeetingUID { get; set; }
    }
}
