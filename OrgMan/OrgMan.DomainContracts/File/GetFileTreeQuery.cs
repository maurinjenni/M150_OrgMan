using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.DomainContracts.File
{
    public class GetFileTreeQuery
    {
        public List<Guid> MandatorUIDs { get; set; }

        public string DirectoryPath { get; set; }
    }
}
