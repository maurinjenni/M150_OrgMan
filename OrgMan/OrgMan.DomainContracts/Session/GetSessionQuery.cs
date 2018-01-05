using System;
using System.Collections.Generic;

namespace OrgMan.DomainContracts.Session
{
    public class GetSessionQuery
    {
        public Guid SessionUID { get; set; }

        public List<Guid> MandatorUID { get; set; }
    }
}
