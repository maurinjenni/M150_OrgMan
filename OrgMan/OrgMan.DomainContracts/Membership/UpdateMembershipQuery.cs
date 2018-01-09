using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrgMan.DomainObjects.Common;

namespace OrgMan.DomainContracts.Membership
{
    public class UpdateMembershipQuery
    {
        public List<Guid> MandatorUIDs { get; set; }

        public MembershipDomainModel MembershipDomainModel { get; set; }
    }
}
