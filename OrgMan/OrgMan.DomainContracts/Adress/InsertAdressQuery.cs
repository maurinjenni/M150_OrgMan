using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrgMan.DomainObjects.Adress;

namespace OrgMan.DomainContracts.Adress
{
    public class InsertAdressQuery
    {
        public Guid MandatorUID { get; set; }

        public AdressManagementDetailDomainModel AdressManagementDetailDomainModel { get; set; }
    }
}
