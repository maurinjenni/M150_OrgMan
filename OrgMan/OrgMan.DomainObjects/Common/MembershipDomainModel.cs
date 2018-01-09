using System;
using System.Collections.Generic;

namespace OrgMan.DomainObjects.Common
{
    public class MembershipDomainModel
    {
        public Guid UID { get; set; }

        public List<Guid> MandatorUIDs { get; set; }

        public string Title { get; set; }

        public string Code { get; set; }
    }
}
