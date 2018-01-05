using System;

namespace OrgMan.DomainObjects.Common
{
    public class EmailDomainModel
    {
        public Guid UID { get; set; }

        public Guid CommunicationTypeUID { get; set; }

        public Guid IndividualPersonUID { get; set; }

        public string EmailAdress { get; set; }

        public bool IsMain { get; set; }
    }
}
