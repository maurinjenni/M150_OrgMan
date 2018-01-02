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

            AutoMapper.Mapper.CreateMap<Adress, AdressDomainModel>();
            AutoMapper.Mapper.CreateMap<AdressDomainModel,Adress>();

            AutoMapper.Mapper.CreateMap<IndividualPerson, AdressManagementDetailDomainModel>();
            AutoMapper.Mapper.CreateMap<AdressManagementDetailDomainModel, IndividualPerson>();

            AutoMapper.Mapper.CreateMap<IndividualPerson, IndividualPersonDomainModel>();
            AutoMapper.Mapper.CreateMap<IndividualPersonDomainModel, IndividualPerson>();

            AutoMapper.Mapper.CreateMap<Person, PersonDomainModel>();
            AutoMapper.Mapper.CreateMap<PersonDomainModel, Person>();

            AutoMapper.Mapper.CreateMap<Email, EmailDomainModel>();
            AutoMapper.Mapper.CreateMap<EmailDomainModel, Email>();

            AutoMapper.Mapper.CreateMap<Phone, PhoneDomainModel>();
            AutoMapper.Mapper.CreateMap<PhoneDomainModel, Phone>();

            AutoMapper.Mapper.CreateMap<MemberInformation, MemberInformationDomainModel>();
            AutoMapper.Mapper.CreateMap<MemberInformationDomainModel, MemberInformation>();

            AutoMapper.Mapper.CreateMap<MemberInformationToMembership, MemberInformationToMembershipDomainModel>();
            AutoMapper.Mapper.CreateMap<MemberInformationToMembershipDomainModel, MemberInformationToMembership>();

            AutoMapper.Mapper.CreateMap<Membership, MembershipDomainModel>();
            AutoMapper.Mapper.CreateMap<MembershipDomainModel, Membership>();

            AutoMapper.Mapper.CreateMap<Adress, AdressManagementDetailDomainModel>();
            AutoMapper.Mapper.CreateMap<AdressManagementDetailDomainModel, Adress>()
                .ForMember(dest => dest.IndividualPersons, opt => opt.MapFrom(src => src));

            AutoMapper.Mapper.CreateMap<Session, SessionDomainModel>()
                .ForMember(dest => dest.MandatorUIDs, opt => opt.MapFrom(src => src.Login.Person.PersonToMandators.Select(ptm => ptm.MandatorUID)));
            AutoMapper.Mapper.CreateMap<SessionDomainModel, Session>();
        }
    }
}
