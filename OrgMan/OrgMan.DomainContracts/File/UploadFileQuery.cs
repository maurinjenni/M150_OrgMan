using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace OrgMan.DomainContracts.File
{
    public class UploadFileQuery
    {
        public List<Guid> MandatorUIDs { get; set; }

        public List<Guid> FileMandatorUIDs { get; set; }

        public HttpPostedFile File { get; set; }

        public string FileSystemDirectoryPath { get; set; }
    }
}
