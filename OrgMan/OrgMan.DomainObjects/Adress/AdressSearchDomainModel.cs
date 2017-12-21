using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.DomainObjects.Adress
{
    public class AdressSearchDomainModel
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public string PostCode { get; set; }

        public string City { get; set; }

        public bool IsMember { get; set; }
    }
}
