using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.DataModel
{
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
}
