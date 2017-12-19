using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.DomainObjects.Session
{
    public class SessionDomainModel
    {
        public Guid SessionUID { get; set; }

        public Guid LoginUID { get; set; }

        public DateTimeOffset ExpireDate { get; set; }
    }
}
