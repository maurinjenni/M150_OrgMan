using OrgMan.DomainObjects.Picture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.DomainContracts.Picture
{
    public class InsertPictureQuery
    {
        public List<Guid> MandatorUIDs { get; set; }

        public string PictureDirectoryPath { get; set; }

        public PictureDomainModel Picture { get; set; }
    }
}
