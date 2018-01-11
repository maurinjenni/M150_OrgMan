using System;

namespace OrgMan.DomainObjects.Common
{
    public class MemberInformationToMembershipDomainModel
    {
        public Guid UID { get; set; }

        public Guid MembershipUID { get; set; }

        public Guid MemberInformationUID { get; set; }

        public MembershipDomainModel Membership { get; set; }
    }
}
