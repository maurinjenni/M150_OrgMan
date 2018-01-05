using System;
using System.Collections.Generic;

namespace OrgMan.DomainObjects.Common
{
    public class MemberInformationDomainModel
    {
        public Guid UID { get; set; }

        public DateTime EntryDate { get; set; }

        public DateTime ExitDate { get; set; }

        public List<MemberInformationToMembershipDomainModel> MemberInformationToMemberships { get; set; }
    }
}
