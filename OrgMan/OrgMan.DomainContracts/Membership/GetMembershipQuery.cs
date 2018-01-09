using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.DomainContracts.Membership
{
    public class GetMembershipQuery
    {
        public List<Guid> MandatorUIDs { get; set; }

        public Guid MembershipUID { get; set; }
    }
}
