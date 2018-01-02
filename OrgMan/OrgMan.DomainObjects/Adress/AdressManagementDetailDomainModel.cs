using OrgMan.DomainObjects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.DomainObjects.Adress
{
    public class AdressManagementDetailDomainModel
    {
        //public IndividualPersonDomainModel IndividualPerson { get; set; }

        public Guid UID { get; set; }

        public string Company { get; set; }

        public DateTime BirthDate { get; set; }

        public string Comment { get; set; }

        public string Picture { get; set; }

        public PersonDomainModel Person { get; set; }

        public AdressDomainModel Adress {get;set;}

        public List<PhoneDomainModel> Phones { get; set; }

        public List<EmailDomainModel> Emails { get; set; }
    }
}
