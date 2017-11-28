using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.DataModel
{
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
}
