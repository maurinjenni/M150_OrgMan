﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.DomainContracts.File
{
    public class DeleteFileQuery
    {
        public List<Guid> MandatorUIDs { get; set; }

        public List<Guid> FileMandatorUIDs { get; set; }

        public string FilePath { get; set; }

        public string FileSystemDirectoryPath { get; set; }
    }
}
