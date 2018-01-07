using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OrgMan.DomainObjects.Picture
{
    public class PictureDomainModel
    {
        public Guid IndividualPersonUID { get; set; }

        public byte[] Picture { get; set; }
    }
}