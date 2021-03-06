﻿using System;

namespace OrgMan.DomainObjects.Common
{
    public class AdressDomainModel
    {
        public Guid UID { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public string Additional { get; set; }

        public string PostCode { get; set; }

        public string City { get; set; }

        public Guid CountryUID { get; set; }
    }
}