using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.DomainContracts.Adress
{
    public class FullTextSearchAdressQuery
    {
        public List<Guid> MandatorUids { get; set; }

        public string SeachText { get; set; }
    }
}
