using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.DomainContracts.Session
{
    public class GetSessionQuery
    {
        public Guid SessionUID { get; set; }
    }
}
