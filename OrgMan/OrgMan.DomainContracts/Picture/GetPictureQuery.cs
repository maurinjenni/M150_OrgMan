using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.DomainContracts.Picture
{
    public class GetPictureQuery
    {
        public List<Guid> MandatorUIDs { get; set; }

        public Guid IndividualPersonUID { get; set; }

        public string PictureDirectoryPath { get; set; }
    }
}
