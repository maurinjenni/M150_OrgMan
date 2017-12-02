using System;
using OrgMan.DataModel;
using OrgMan.DomainObjects;

namespace OrgMan.Mappings
{
    public static class DomainModelMapping
    {
        public static void CreateMappings()
        {
            AutoMapper.Mapper.CreateMap<Person, PersonDomainModel>();
        }
    }
}
