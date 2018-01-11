using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.DomainObjects.Common
{
    public class PersonToMandatorDomainModel
    {
        public Guid UID { get; set; }

        public Guid PersonUID { get; set; }

        public Guid MandatorUID { get; set; }
    }
}
