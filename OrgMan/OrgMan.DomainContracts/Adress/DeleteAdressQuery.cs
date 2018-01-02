using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.DomainContracts.Adress
{
    public class DeleteAdressQuery
    {
        public Guid IndividualPersonUID { get; set; }

        public Guid MandatorUID { get; set; }
    }
}