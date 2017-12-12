using System;
using System.Linq;
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


            AutoMapper.Mapper.CreateMap<Adress, AdressSearchDomainModel>()
                .ForMember(dest => dest.StreetAdress, opt => opt.MapFrom(src => src.Street + ' ' + src.HouseNumber))
                .ForMember(dest => dest.Firstname, opt => opt.MapFrom(src => src.Person.First().Firstname))
                .ForMember(dest => dest.Lastname, opt => opt.MapFrom(src => src.Person.First().Lastname));

            AutoMapper.Mapper.CreateMap<Adress, AdressDetailDomainModel>();
        }
    }
}
