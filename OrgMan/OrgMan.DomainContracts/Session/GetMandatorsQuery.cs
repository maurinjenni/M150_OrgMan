using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.DomainContracts.Session
{
    public class GetMandatorsQuery
    {
        public Guid SessionUID { get; set; }
    }
}
