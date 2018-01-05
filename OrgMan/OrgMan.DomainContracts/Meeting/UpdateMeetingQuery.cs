using OrgMan.DomainObjects;
using System;
using System.Collections.Generic;

namespace OrgMan.DomainContracts.Meeting
{
    public class UpdateMeetingQuery
    {
        public List<Guid> MandatorUIDs { get; set; }

        public MeetingDetailDomainModel MeetingDetailDomainModel { get; set; }
    }
}
