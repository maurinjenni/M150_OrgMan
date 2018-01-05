using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.DomainContracts.Meeting
{
    public class GetMeetingQuery
    {
        public Guid MeetingUID { get; set; }

        public List<Guid> MandatorUIDs { get; set; }
    }
}
