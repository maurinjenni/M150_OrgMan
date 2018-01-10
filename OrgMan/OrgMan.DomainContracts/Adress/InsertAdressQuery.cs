using System;
using OrgMan.DomainObjects.Adress;
using System.Collections.Generic;

namespace OrgMan.DomainContracts.Adress
{
    public class InsertAdressQuery
    {
        public List<Guid> MandatorUIDs { get; set; }

        public AdressManagementDetailDomainModel AdressManagementDetailDomainModel { get; set; }
    }
}
