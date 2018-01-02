using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.DomainContracts.Meeting
{
    public class DeleteMeetingQuery
    {
        public Guid MeetingUID { get; set; }
    }
}
