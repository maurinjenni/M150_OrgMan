using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.DataModel
{
    public partial class Salutation
    {
        public Guid MandatorUID
        {
            get { return Guid.Empty; }
            set
            {
                throw new DataException("Cannot set MandatorUID on Table Saluation. The Column does not exists.");
            }
        }
    }
}
