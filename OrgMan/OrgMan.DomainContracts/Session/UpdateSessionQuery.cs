using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrgMan.DomainObjects.Session;

namespace OrgMan.DomainContracts.Session
{
    public class UpdateSessionQuery
    {
        public SessionDomainModel Session { get; set; }
    }
}
