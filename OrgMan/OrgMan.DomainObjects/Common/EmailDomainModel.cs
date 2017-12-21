using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.DomainObjects.Common
{
    public class EmailDomainModel
    {
        public Guid UID { get; set; }

        public Guid CommunicationTypeUID { get; set; }

        public string EmailAdress { get; set; }

        public bool IsMain { get; set; }
    }
}
