using System;
using System.Collections.Generic;

namespace OrgMan.DomainObjects.Session
{
    public class SessionDomainModel
    {
        public Guid SessionUID { get; set; }

        public Guid LoginUID { get; set; }

        public List<Guid> MandatorUIDs { get; set; }

        public DateTimeOffset ExpireDate { get; set; }
    }
}
