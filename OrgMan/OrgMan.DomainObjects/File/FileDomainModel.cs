using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OrgMan.DomainObjects.File
{
    public class FileDomainModel
    {
        public string Name { get; set; }

        public List<FileDomainModel> Entries { get;set;}
    }
}