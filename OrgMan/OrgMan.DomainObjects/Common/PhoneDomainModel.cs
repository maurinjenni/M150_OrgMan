using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.DomainObjects.Common
{
    public class PhoneDomainModel
    {
        public Guid UID { get; set; }

        public Guid CommunicationTypeUID { get; set; }

        public Guid IndividualPersonUID { get; set; }

        public string Number { get; set; }

        public bool IsMain { get; set; }
    }
}
