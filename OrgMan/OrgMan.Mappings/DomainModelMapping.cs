using System;
using OrgMan.DataModel;
using OrgMan.DomainObjects;
using OrgMan.DomainObjects.Adress;

namespace OrgMan.Mappings
{
    public static class DomainModelMapping
    {
        public static void CreateMappings()
        {
            AutoMapper.Mapper.CreateMap<Person, PersonDomainModel>();


            AutoMapper.Mapper.CreateMap<Adress, AdressSearchDomainModel>();
            AutoMapper.Mapper.CreateMap<Adress, AdressDetailDomainModel>();
        }
    }
}
