using System;
using System.Collections.Generic;

namespace OrgMan.DomainObjects.Common
{
    public class PersonDomainModel
    {
        public Guid UID { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public Guid SalutationUID { get; set; }

        public List<PersonToMandatorDomainModel> PersonToMandators { get; set; }
    }
}
