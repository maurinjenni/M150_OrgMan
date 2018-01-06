using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.DomainContracts.File
{
    public class DeleteFileQuery
    {
        public List<Guid> MandatorUIDs { get; set; }

        public Guid MeetingUID { get; set; }
    }
}
