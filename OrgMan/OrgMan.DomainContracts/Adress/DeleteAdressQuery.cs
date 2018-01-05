using System;

namespace OrgMan.DomainContracts.Adress
{
    public class DeleteAdressQuery
    {
        public Guid IndividualPersonUID { get; set; }

        public Guid MandatorUID { get; set; }
    }
}