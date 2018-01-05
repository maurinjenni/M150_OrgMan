using System;
using OrgMan.DomainObjects.Adress;

namespace OrgMan.DomainContracts.Adress
{
    public class UpdateAdressQuery
    {
        public Guid MandatorUID { get; set; }

        public AdressManagementDetailDomainModel AdressManagementDetailDomainModel { get; set; }
    }
}
