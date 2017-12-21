using System;
using System.Linq;
using OrgMan.DataModel;
using OrgMan.DomainObjects;
using OrgMan.DomainObjects.Adress;
using OrgMan.DomainObjects.Session;

namespace OrgMan.Mappings
{
    public static class DomainModelMapping
    {
        public static void CreateMappings()
        {
            AutoMapper.Mapper.CreateMap<Person, PersonDomainModel>();

            AutoMapper.Mapper.CreateMap<IndividualPerson, AdressSearchDomainModel>()
                .ForMember(dest => dest.Firstname, opt => opt.MapFrom(src => src.Person != null ? src.Person.Firstname : null ))
                .ForMember(dest => dest.Lastname, opt => opt.MapFrom(src => src.Person != null? src.Person.Lastname : null))
                .ForMember(dest => dest.IsMember, opt => opt.MapFrom(src => src.MemberInformation != null))
                .ForMember(dest => dest.PostCode, opt => opt.MapFrom(src => src.Adress != null ? src.Adress.PostCode : null))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Adress != null ? src.Adress.City : null))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Adress != null ? src.Adress.Street : null))
                .ForMember(dest => dest.HouseNumber, opt => opt.MapFrom(src => src.Adress != null ? src.Adress.HouseNumber: null));


            AutoMapper.Mapper.CreateMap<Adress, AdressDetailDomainModel>();

            AutoMapper.Mapper.CreateMap<Session, SessionDomainModel>()
                .ForMember(dest => dest.MandatorUIDs, opt => opt.MapFrom(src => src.Login.Person.PersonToMandators.Select(ptm => ptm.MandatorUID)));
                
            AutoMapper.Mapper.CreateMap<SessionDomainModel, Session>();
        }
    }
}
