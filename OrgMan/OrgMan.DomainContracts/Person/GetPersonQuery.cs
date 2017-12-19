using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.DomainContracts.Person
{
    public class GetPersonQuery
    {
        public Guid PersonUID { get; set; }

        public List<Guid> MandatorUID { get; set; }

        public Guid PermissionUID { get; set; }
    }
}
