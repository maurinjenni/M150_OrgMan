using System;
using System.Data;
using System.Linq;

namespace OrgMan.DataModel
{
    public partial class Country
    {
        public Guid MandatorUID
        {
            get { return Guid.Empty; }
            set
            {
                throw new DataException("Cannot set MandatorUID on Table Country. The Column does not exists.");
            }
        }
    }

    public partial class Login
    {
        public Guid MandatorUID
        {
            get { return this.Person.PersonToMandators.First().MandatorUID; }
            set
            {
                throw new DataException("Cannot set MandatorUID on Table Login. The Column does not exists.");
            }
        }
    }

    public partial class Mandator
    {
        public Guid MandatorUID
        {
            get { return this.UID; }
            set
            {
                throw new DataException("Cannot set MandatorUID on Table Mandator. The Column does not exists.");
            }
        }
    }

    public partial class MemberInformation
    {
        public Guid MandatorUID
        {
            get { return this.IndividualPersons.FirstOrDefault().Person.PersonToMandators.First().MandatorUID; }
            set
            {
                throw new DataException("Cannot set MandatorUID on Table MemberInformation. The Column does not exists.");
            }
        }
    }

    public partial class MemberInformationToMembership
    {
        public Guid MandatorUID
        {
            get
            {
                return
                    this.MemberInformation.IndividualPersons.FirstOrDefault()
                        .Person.PersonToMandators.FirstOrDefault()
                        .MandatorUID;
            }
            set
            {
                throw new DataException("Cannot set MandatorUID on Table MemberInformationToMembership. The Column does not exists.");
            }
        }
    }

    public partial class Salutation
    {
        public Guid MandatorUID
        {
            get { return this.MandatorUID; }
            set
            {
                throw new DataException("Cannot set MandatorUID on Table Saluation. The Column does not exists.");
            }
        }
    }

    public partial class Adress
    {
        public Guid MandatorUID
        {
            get { return this.IndividualPersons.FirstOrDefault().Person.PersonToMandators.FirstOrDefault().MandatorUID; }
            set
            {
                throw new DataException("Cannot set MandatorUID on Table Adress. The Column does not exists.");
            }
        }
    }

    public partial class CommunicationType
    {
        public Guid MandatorUID
        {
            get { return this.MandatorUID; }
            set
            {
                throw new DataException("Cannot set MandatorUID on Table CommunicationType. The Column does not exists.");
            }
        }
    }

    public partial class Email
    {
        public Guid MandatorUID
        {
            get { return this.MandatorUID; }
            set
            {
                throw new DataException("Cannot set MandatorUID on Table Email. The Column does not exists.");
            }
        }
    }

    public partial class Phone
    {
        public Guid MandatorUID
        {
            get { return this.MandatorUID; }
            set
            {
                throw new DataException("Cannot set MandatorUID on Table Phone. The Column does not exists.");
            }
        }
    }

    public partial class IndividualPerson
    {
        public Guid MandatorUID
        {
            get { return this.Person.PersonToMandators.First().MandatorUID; }
            set
            {
                throw new DataException("Cannot set MandatorUID on Table IndividualPerson. The Column does not exists.");
            }
        }
    }

    public partial class SystemPerson
    {
        public Guid MandatorUID
        {
            get { return this.Person.PersonToMandators.First().MandatorUID; }
            set
            {
                throw new DataException("Cannot set MandatorUID on Table SysPerson. The Column does not exists.");
            }
        }
    }

    public partial class Person
    {
        public Guid MandatorUID
        {
            get { return this.PersonToMandators.First().MandatorUID; }
            set
            {
                throw new DataException("Cannot set MandatorUID on Table Person. The Column does not exists.");
            }
        }
    }

    public partial class Session
    {
        public Guid MandatorUID
        {
            get { return this.Login.Person.PersonToMandators.First().MandatorUID; }
            set
            {
                throw new DataException("Cannot set MandatorUID on Table Session. The Column does not exists.");
            }
        }
    }
}
