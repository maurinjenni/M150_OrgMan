using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace OrgMan.DataModel
{
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

                throw new Exception("Could not load MandatorUIDs");
            }
            set
            {
                throw new DataException("Cannot set MandatorUIDs on Table Login. The Column does not exists.");
            }
        }
    }

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

                throw new Exception("Could not load MandatorUIDs");

            }
            set
            {
                throw new DataException("Cannot set MandatorUIDs on Table MemberInformation. The Column does not exists.");
            }
        }
    }

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
                }

                throw new Exception("Could not load MandatorUIDs");
            }
            set
            {
                throw new DataException("Cannot set MandatorUIDs on Table MemberInformationToMembership. The Column does not exists.");
            }
        }
    }

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

                throw new Exception("Could not load MandatorUIDs");
            }
            set
            {
                throw new DataException("Cannot set MandatorUIDs on Table Adress. The Column does not exists.");
            }
        }
    }

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

                throw new Exception("Could not load MandatorUIDs");
            }
            set
            {
                throw new DataException("Cannot set MandatorUIDs on Table Email. The Column does not exists.");
            }
        }
    }

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

                throw new Exception("Could not load MandatorUIDs");
            }
            set
            {
                throw new DataException("Cannot set MandatorUIDs on Table Phone. The Column does not exists.");
            }
        }
    }

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

                throw new Exception("Could not load MandatorUIDs");
            }
            set
            {
                throw new DataException("Cannot set MandatorUIDs on Table SysPerson. The Column does not exists.");
            }
        }
    }

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

                throw new Exception("Could not load MandatorUIDs");
            }
            set
            {
                throw new DataException("Cannot set MandatorUIDs on Table Person. The Column does not exists.");
            }
        }
    }

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

                throw new Exception("Could not load MandatorUIDs");
            }
            set
            {
                throw new DataException("Cannot set MandatorUIDs on Table Session. The Column does not exists.");
            }
        }
    }
    
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
                throw new DataException("Cannot set MandatorUIDs on Table Session. The Column does not exists.");
            }
        }
    }

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
}
