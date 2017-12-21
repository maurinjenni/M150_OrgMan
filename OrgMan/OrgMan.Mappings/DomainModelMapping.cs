using System;
using System.Linq;
using OrgMan.DataModel;
using OrgMan.DomainObjects;
using OrgMan.DomainObjects.Adress;
using OrgMan.DomainObjects.Session;
using OrgMan.DomainObjects.Common;

namespace OrgMan.Mappings
{
    public static class DomainModelMapping
    {
        public static void CreateMappings()
        {

            AutoMapper.Mapper.CreateMap<IndividualPerson, AdressManagementSearchDomainModel>()
                .ForMember(dest => dest.UID, opt => opt.MapFrom(src => src.Person.UID))
                .ForMember(dest => dest.Firstname, opt => opt.MapFrom(src => src.Person != null ? src.Person.Firstname : null ))
                .ForMember(dest => dest.Lastname, opt => opt.MapFrom(src => src.Person != null? src.Person.Lastname : null))
                .ForMember(dest => dest.IsMember, opt => opt.MapFrom(src => src.MemberInformation != null))
                .ForMember(dest => dest.PostCode, opt => opt.MapFrom(src => src.Adress != null ? src.Adress.PostCode : null))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Adress != null ? src.Adress.City : null))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Adress != null ? src.Adress.Street : null))
                .ForMember(dest => dest.HouseNumber, opt => opt.MapFrom(src => src.Adress != null ? src.Adress.HouseNumber: null));

            //AutoMapper.Mapper.CreateMap<IndividualPerson, IndividualPersonDomainModel>();
            AutoMapper.Mapper.CreateMap<Adress, AdressDomainModel>();
            AutoMapper.Mapper.CreateMap<Person, PersonDomainModel>();
            AutoMapper.Mapper.CreateMap<IndividualPerson, IndividualPersonDomainModel>();
            AutoMapper.Mapper.CreateMap<IndividualPerson, AdressManagementDetailDomainModel>()
                .ForMember(dest => dest.IndividualPerson, opt => opt.MapFrom(src => src)); ;
            AutoMapper.Mapper.CreateMap<Email, EmailDomainModel>();
            AutoMapper.Mapper.CreateMap<Phone, PhoneDomainModel>();

                //.ForMember(dest => dest.IndividualPerson)
                //.ForMember(dest => dest.IndividualPerson.UID, opt => opt.MapFrom(src => src.UID))
                //.ForMember(dest => dest.IndividualPerson.BirthDate, opt => opt.MapFrom(src => src.Person.IndividualPerson.Birthdate))
                //.ForMember(dest => dest.IndividualPerson.Comment, opt => opt.MapFrom(src => src.Person.IndividualPerson.Comment))
                //.ForMember(dest => dest.IndividualPerson.Company, opt => opt.MapFrom(src => src.Person.IndividualPerson.Company));
                //.ForMember(dest => dest.IndividualPerson.Person.UID, opt => opt.MapFrom(src => src.Person.UID))
                //.ForMember(dest => dest.IndividualPerson.Person.Firstname, opt => opt.MapFrom(src => src.Person.Firstname))
                //.ForMember(dest => dest.IndividualPerson.Person.Lastname, opt => opt.MapFrom(src => src.Person.Lastname))
                //.ForMember(dest => dest.IndividualPerson.Person.SalutationUID, opt => opt.MapFrom(src => src.Person.SalutationUID))
                //.ForMember(dest => dest.Adress, opt => opt.MapFrom(src => src.Person.IndividualPerson.Adress))




            AutoMapper.Mapper.CreateMap<Adress, AdressManagementDetailDomainModel>();

            AutoMapper.Mapper.CreateMap<Session, SessionDomainModel>()
                .ForMember(dest => dest.MandatorUIDs, opt => opt.MapFrom(src => src.Login.Person.PersonToMandators.Select(ptm => ptm.MandatorUID)));
                
            AutoMapper.Mapper.CreateMap<SessionDomainModel, Session>();
        }
    }
}
