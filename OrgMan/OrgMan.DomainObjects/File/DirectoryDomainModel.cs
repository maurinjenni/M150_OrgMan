using OrgMan.DomainObjects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.DomainObjects.File
{
    public class DirectoryDomainModel
    {
        public MandatorDomainModel Mandator { get; set; }

        public List<FileDomainModel> Entries { get; set; }
    }
}
