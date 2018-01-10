using System;
using System.Collections.Generic;

namespace OrgMan.DomainContracts.Adress
{
    public class GetAdressQuery
    {
        public Guid AdressUID { get; set; }

        public List<Guid> MandatorUIDs { get; set; }
    }
}
