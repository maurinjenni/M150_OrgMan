using OrgMan.DomainObjects.Session;
using System;
using System.Collections.Generic;

namespace OrgMan.DomainContracts.Session
{
    public class UpdateSessionQuery
    {
        public List<Guid> MandatorUIDs { get; set; }

        public SessionDomainModel Session { get; set; }
    }
}
