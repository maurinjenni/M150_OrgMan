using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ComponentModel.DataAnnotations;


namespace OrgMan.DataModel
{
    [MetadataType(typeof(CountryMetaData))]
    public partial class Country
    {
        public IEnumerable<Guid> MandatorUIDs
        {
            get { return null; }
            set
            {
                throw new DataException("Cannot set MandatorUIDs on Table Country. The Column does not exists.");
            }
        }
    }

    public class CountryMetaData
    {
        [MaxLength(10)]
        [Required]
        public string Code { get; set; }
        [MaxLength(30)]
        [Required]
        public string Title { get; set; }
    }

    [MetadataType(typeof(LoginMetaData))]
    public partial class Login
    {
        public IEnumerable<Guid> MandatorUIDs
        {
            get
            {
                if (this.Person != null && this.Person.PersonToMandators != null && this.Person.PersonToMandators.Any())
                {
                    return this.Person.PersonToMandators.Select(p => p.MandatorUID);
                }

                throw new DataException("Could not load MandatorUIDs");
            }
            set
            {
                throw new DataException("Cannot set MandatorUIDs on Table Login. The Column does not exists.");
            }
        }
    }

    public class LoginMetaData
    {

    }

    [MetadataType(typeof(MandatorMetaData))]
    public partial class Mandator
    {
        public IEnumerable<Guid> MandatorUIDs
        {
            get
            {
                var uids = new List<Guid>();
                uids.Add(this.UID);

                return uids.AsEnumerable();
            }
            set
            {
                throw new DataException("Cannot set MandatorUIDs on Table Mandator. The Column does not exists.");
            }
        }
    }

    public class MandatorMetaData
    {

    }

    [MetadataType(typeof(MemberinformationMetaData))]
    public partial class MemberInformation
    {
        public IEnumerable<Guid> MandatorUIDs
        {
            get
            {
                if (this.IndividualPersons != null && this.IndividualPersons.Any() && this.IndividualPersons.FirstOrDefault().Person != null && this.IndividualPersons.FirstOrDefault().Person.PersonToMandators != null && this.IndividualPersons.FirstOrDefault().Person.PersonToMandators.Any())
                {
                    return this.IndividualPersons.FirstOrDefault().Person.PersonToMandators.Select(p => p.MandatorUID);
                }

                throw new DataException("Could not load MandatorUIDs");

            }
            set
            {
                throw new DataException("Cannot set MandatorUIDs on Table MemberInformation. The Column does not exists.");
            }
        }
    }

    public class MemberinformationMetaData
    {

    }

    [MetadataType(typeof(MemberInformationToMembershipMetaData))]
    public partial class MemberInformationToMembership
    {
        public IEnumerable<Guid> MandatorUIDs
        {
            get
            {
                if (this.Membership != null)
                {
                    var uids = new List<Guid>();
                    uids.Add(this.Membership.MandatorUID);

                    return uids.AsEnumerable();
                }else
                {
                    if(this.MemberInformation != null && this.MemberInformation.IndividualPersons != null && this.MemberInformation.IndividualPersons.Any() && this.MemberInformation.IndividualPersons.First().MandatorUIDs != null)
                    {
                        return this.MemberInformation.IndividualPersons.First().MandatorUIDs;
                    }
                }

                throw new DataException("Could not load MandatorUIDs");
            }
            set
            {
                throw new DataException("Cannot set MandatorUIDs on Table MemberInformationToMembership. The Column does not exists.");
            }
        }

        public static implicit operator List<object>(MemberInformationToMembership v)
        {
            throw new NotImplementedException();
        }
    }

    public class MemberInformationToMembershipMetaData
    {

    }

    [MetadataType(typeof(SaluatationMetaData))]
    public partial class Salutation
    {
        public IEnumerable<Guid> MandatorUIDs
        {
            get { return null; }
            set
            {
                throw new DataException("Cannot set MandatorUIDs on Table Saluation. The Column does not exists.");
            }
        }
    }

    public class SaluatationMetaData
    {

    }

    [MetadataType(typeof(AdressMetaData))]
    public partial class Adress
    {
        public IEnumerable<Guid> MandatorUIDs
        {
            get
            {
                if (this.IndividualPersons != null && this.IndividualPersons.Any() && this.IndividualPersons.FirstOrDefault().Person != null && this.IndividualPersons.FirstOrDefault().Person.PersonToMandators != null && this.IndividualPersons.FirstOrDefault().Person.PersonToMandators.Any())
                {
                    return this.IndividualPersons.FirstOrDefault().Person.PersonToMandators.Select(p => p.MandatorUID);
                }

                throw new DataException("Could not load MandatorUIDs");
            }
            set
            {
                throw new DataException("Cannot set MandatorUIDs on Table Adress. The Column does not exists.");
            }
        }
    }

    public class AdressMetaData
    {
        [MaxLength(50)]
        [Required]
        public string Street { get; set; }

        [MaxLength(10)]
        [Required]
        public string HouseNumber { get; set; }

        [MaxLength(100)]
        [Required]
        public string Additional { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(10)]
        [Required]
        public string PostCode { get; set; }
    }

    [MetadataType(typeof(CommunicationTypeMetaData))]
    public partial class CommunicationType
    {
        public IEnumerable<Guid> MandatorUIDs
        {
            get { return null; }
            set
            {
                throw new DataException("Cannot set MandatorUIDs on Table CommunicationType. The Column does not exists.");
            }
        }
    }

    public class CommunicationTypeMetaData
    {

    }

    [MetadataType(typeof(EmailMetaData))]
    public partial class Email
    {
        public IEnumerable<Guid> MandatorUIDs
        {
            get
            {
                if (this.IndividualPerson != null && this.IndividualPerson.Person != null && this.IndividualPerson.Person.PersonToMandators != null && this.IndividualPerson.Person.PersonToMandators.Any())
                {
                    return this.IndividualPerson.Person.PersonToMandators.Select(p => p.MandatorUID);
                }

                throw new DataException("Could not load MandatorUIDs");
            }
            set
            {
                throw new DataException("Cannot set MandatorUIDs on Table Email. The Column does not exists.");
            }
        }
    }

    public class EmailMetaData
    {
        [MaxLength(100)]
        [MinLength(5)]
        [Required]
        public string EmailAdress { get; set; }

        [Required]
        public bool IsMain { get; set; }
    }

    [MetadataType(typeof(PhoneMetaData))]
    public partial class Phone
    {
        public IEnumerable<Guid> MandatorUIDs
        {
            get
            {
                if (this.IndividualPerson != null && this.IndividualPerson.Person != null && this.IndividualPerson.Person.PersonToMandators != null && this.IndividualPerson.Person.PersonToMandators.Any())
                {
                    return this.IndividualPerson.Person.PersonToMandators.Select(p => p.MandatorUID);
                }

                throw new DataException("Could not load MandatorUIDs");
            }
            set
            {
                throw new DataException("Cannot set MandatorUIDs on Table Phone. The Column does not exists.");
            }
        }
    }

    public class PhoneMetaData
    {
        [MaxLength(20)]
        [MinLength(5)]
        [Required]
        public string Phone { get; set; }

        [Required]
        public bool IsMain { get; set; }
    }

    [MetadataType(typeof(IndividualPersonMetaData))]
    public partial class IndividualPerson
    {
        public IEnumerable<Guid> MandatorUIDs
        {
            get
            {
                if(this.Person != null && this.Person.PersonToMandators != null && this.Person.PersonToMandators.Any())
                {
                    return this.Person.PersonToMandators.Select(p => p.MandatorUID);
                }

                return null;
            }
            set
            {
                throw new DataException("Cannot set MandatorUIDs on Table IndividualPerson. The Column does not exists.");
            }
        }
    }

    public class IndividualPersonMetaData
    {
        [MaxLength(100)]
        [Required]
        public string Company { get; set; }

        [MaxLength(2000)]
        public bool Comment { get; set; }
    }

    [MetadataType(typeof(SystemPersonMetaData))]
    public partial class SystemPerson
    {
        public IEnumerable<Guid> MandatorUIDs
        {
            get
            {
                if (this.Person != null && this.Person.PersonToMandators != null && this.Person.PersonToMandators.Any())
                {
                    return this.Person.PersonToMandators.Select(p => p.MandatorUID);
                }

                throw new DataException("Could not load MandatorUIDs");
            }
            set
            {
                throw new DataException("Cannot set MandatorUIDs on Table SysPerson. The Column does not exists.");
            }
        }
    }

    public class SystemPersonMetaData
    {

    }

    [MetadataType(typeof(PersonMetaData))]
    public partial class Person
    {
        public IEnumerable<Guid> MandatorUIDs
        {
            get
            {
                if (this.PersonToMandators != null && this.PersonToMandators.Any())
                {
                    return this.PersonToMandators.Select(p => p.MandatorUID);
                }

                throw new DataException("Could not load MandatorUIDs");
            }
            set
            {
                throw new DataException("Cannot set MandatorUIDs on Table Person. The Column does not exists.");
            }
        }
    }

    public class PersonMetaData
    {
        [MaxLength(50)]
        [Required]
        public string Firstname { get; set; }

        [MaxLength(50)]
        [Required]
        public string lastname { get; set; }
    }

    [MetadataType(typeof(SessionMetaData))]
    public partial class Session
    {
        public IEnumerable<Guid> MandatorUIDs
        {
            get
            {
                if(this.Login != null && this.Login.Person != null && this.Login.Person.PersonToMandators != null && this.Login.Person.PersonToMandators.Any())
                {
                    return this.Login.Person.PersonToMandators.Select(p => p.MandatorUID);
                }

                throw new DataException("Could not load MandatorUIDs");
            }
            set
            {
                throw new DataException("Cannot set MandatorUIDs on Table Session. The Column does not exists.");
            }
        }
    }

    public class SessionMetaData
    {

    }

    [MetadataType(typeof(MembershipMetaData))]
    public partial class Membership
    {
        public IEnumerable<Guid> MandatorUIDs
        {
            get
            {
                var uids = new List<Guid>();
                uids.Add(this.MandatorUID);

                return uids.AsEnumerable();
            }
            set
            {
                this.MandatorUID = value.First();
                //throw new DataException("Cannot set MandatorUIDs on Table Membership. The Column does not exists.");
            }
        }
    }

    public class MembershipMetaData
    {
        [MaxLength(10)]
        [Required]
        public string Code { get; set; }
        [MaxLength(30)]
        [Required]
        public string Title { get; set; }
    }

    [MetadataType(typeof(PersonToMandatorMetaData))]
    public partial class PersonToMandator
    {
        public IEnumerable<Guid> MandatorUIDs
        {
            get
            {
                var uids = new List<Guid>();
                uids.Add(this.MandatorUID);

                return uids.AsEnumerable();
            }
            set
            {
                throw new DataException("Cannot set MandatorUIDs on Table Session. The Column does not exists.");
            }
        }
    }

    public class PersonToMandatorMetaData
    {

    }

    [MetadataType(typeof(MeetingMetaData))]
    public partial class Meeting
    {
        public IEnumerable<Guid> MandatorUIDs
        {
            get
            {
                var uids = new List<Guid>();
                uids.Add(this.MandatorUID);

                return uids.AsEnumerable();
            }
            set
            {
                throw new DataException("Cannot set MandatorUIDs on Table Session. The Column does not exists.");
            }
        }
    }

    public class MeetingMetaData
    {
        [MaxLength(50)]
        [Required]
        public string Title { get; set; }

        [MaxLength(50)]
        [Required]
        public string Location { get; set; }

        [MaxLength(500)]
        [Required]
        public string Description { get; set; }
    }
}
