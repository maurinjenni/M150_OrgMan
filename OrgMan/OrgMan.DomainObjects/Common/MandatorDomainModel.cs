using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.DomainObjects.Common
{
    public class MandatorDomainModel
    {
        public Guid UID { get; set; }

        public string Title { get; set; }

        public string Code { get; set; }
    }
}
