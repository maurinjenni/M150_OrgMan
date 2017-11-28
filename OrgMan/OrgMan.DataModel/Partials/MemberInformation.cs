using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.DataModel
{
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
}
