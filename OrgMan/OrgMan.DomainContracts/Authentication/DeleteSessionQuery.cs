using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.DomainContracts.Authentication
{
    public class DeleteSessionQuery
    {
        public List<Guid> MandatorUIDs { get; set; }

        public Guid SessionUID { get; set; }
    }
}
