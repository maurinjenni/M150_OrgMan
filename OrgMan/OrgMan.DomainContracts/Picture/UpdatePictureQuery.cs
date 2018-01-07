using OrgMan.DomainObjects.Picture;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OrgMan.DomainContracts.Picture
{
    public class UpdatePictureQuery
    {
        public List<Guid> MandatorUIDs { get; set; }

        public string PictureDirectoryPath { get; set; }

        public PictureDomainModel Picture { get; set; }
    }
}