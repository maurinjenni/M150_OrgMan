using System;
using System.Collections.Generic;

namespace OrgMan.DomainContracts.Adress
{
    public class DeleteAdressQuery
    {
        public Guid IndividualPersonUID { get; set; }

        public List<Guid> MandatorUIDs { get; set; }
    }
}