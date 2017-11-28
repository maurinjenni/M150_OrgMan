using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.DataModel
{
    public interface IEntityUID
    {
        Guid UID { get; set; }

        Guid SysInsertAccountUID { get; set; }

        DateTimeOffset SysInsertTime { get; set; }

        Guid MandatorUID { get; set; }
    }
}
