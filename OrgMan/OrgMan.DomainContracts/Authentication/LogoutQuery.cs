using System;

namespace OrgMan.DomainContracts.Authentication
{
    public class LogoutQuery
    {
        public Guid SessionUID { get; set; }
    }
}
