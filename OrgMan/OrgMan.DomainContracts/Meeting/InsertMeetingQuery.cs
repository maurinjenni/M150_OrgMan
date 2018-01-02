using OrgMan.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.DomainContracts.Meeting
{
    public class InsertMeetingQuery
    {
        public Guid MandatorUID { get; set; }

        public MeetingDetailDomainModel MeetingDetailDomainModel { get; set; }
    }
}
