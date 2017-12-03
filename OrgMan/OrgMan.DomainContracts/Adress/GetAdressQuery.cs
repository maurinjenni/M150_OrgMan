using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.DomainContracts.Adress
{
    public class GetAdressQuery
    {
        public Guid AdressUID { get; set; }

        public Guid MandatorUID { get; set; }
    }
}
