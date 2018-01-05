using System;

namespace OrgMan.DomainObjects.Meeting
{
    public class MeetingSearchDomainModel
    {
        public Guid UID { get; set; }

        public string Title { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
