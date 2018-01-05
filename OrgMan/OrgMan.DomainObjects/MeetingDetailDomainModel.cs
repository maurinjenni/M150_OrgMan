using OrgMan.DomainObjects.Common;
using System;

namespace OrgMan.DomainObjects
{
    public class MeetingDetailDomainModel
    {
        public Guid UID { get; set; }

        public Guid MandatorUID { get; set; }

        public MandatorDomainModel Mandator { get; set; }       

        public string Title { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }
    }
}
