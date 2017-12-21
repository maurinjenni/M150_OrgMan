using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.DomainObjects.Common
{
    public class IndividualPersonDomainModel
    {
        public Guid UID { get; set; }

        public PersonDomainModel Person { get; set; }

        public string Company { get; set; }

        public DateTime BirthDate { get; set; }

        public string Comment { get; set; }

        public string Picture { get; set; }
    }
}
