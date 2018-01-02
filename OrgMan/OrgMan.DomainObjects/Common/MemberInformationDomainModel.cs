using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
