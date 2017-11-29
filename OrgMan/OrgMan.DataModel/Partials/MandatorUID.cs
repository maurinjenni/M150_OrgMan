using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.DataModel
{
    public partial class Account
    {
        public Guid MandatorUID
        {
            get { return Guid.Empty; }
            set
            {
                throw new DataException("Cannot set MandatorUID on Table Account. The Column does not exists.");
            }
        }
    }

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

    public partial class EmailAdressToPerson
    {
        public Guid MandatorUID
        {
            get { return this.Person.MandatorUID; }
            set
            {
                throw new DataException("Cannot set MandatorUID on Table EmailAdressToPerson. The Column does not exists.");
            }
        }
    }

    public partial class Login
    {
        public Guid MandatorUID
        {
            get { return this.Account.Person.FirstOrDefault().MandatorUID; }
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
            get { return this.Person.FirstOrDefault().MandatorUID; }
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
            get { return this.MemberInformation.Person.FirstOrDefault().MandatorUID; }
            set
            {
                throw new DataException("Cannot set MandatorUID on Table MemberInformationToMembership. The Column does not exists.");
            }
        }
    }

    public partial class PhoneToPerson
    {
        public Guid MandatorUID
        {
            get { return this.Person.MandatorUID; }
            set
            {
                throw new DataException("Cannot set MandatorUID on Table PhoneToPerson. The Column does not exists.");
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
            get { return this.Person.FirstOrDefault().MandatorUID; }
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
                throw new DataException("Cannot set MandatorUID on Table Adress. The Column does not exists.");
            }
        }
    }

    public partial class EmailAdress
    {
        public Guid MandatorUID
        {
            get { return this.MandatorUID; }
            set
            {
                throw new DataException("Cannot set MandatorUID on Table Adress. The Column does not exists.");
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
                throw new DataException("Cannot set MandatorUID on Table Adress. The Column does not exists.");
            }
        }
    }
}
