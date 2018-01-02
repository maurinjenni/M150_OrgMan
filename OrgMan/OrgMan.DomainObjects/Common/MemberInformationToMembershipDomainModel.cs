using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.DomainObjects.Common
{
    public class MemberInformationToMembershipDomainModel
    {
        public Guid UID { get; set; }

        public MembershipDomainModel Membership { get; set; }
    }
}
