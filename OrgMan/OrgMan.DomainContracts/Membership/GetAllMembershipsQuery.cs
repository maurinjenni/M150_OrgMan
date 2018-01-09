using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.DomainContracts.Membership
{
    public class GetAllMembershipsQuery
    {
        public List<Guid> MandatorUIDs { get; set; }
    }
}
