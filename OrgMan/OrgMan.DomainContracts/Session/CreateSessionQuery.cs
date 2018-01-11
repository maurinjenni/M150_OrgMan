using OrgMan.DomainObjects.Session;
using System;
using System.Collections.Generic;

namespace OrgMan.DomainContracts.Session
{
    public class CreateSessionQuery
    {
        public SessionDomainModel Session { get; set; }
    }
}
