using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.DataModel
{
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
}
