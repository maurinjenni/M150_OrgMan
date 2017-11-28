using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.DataModel
{
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
}
