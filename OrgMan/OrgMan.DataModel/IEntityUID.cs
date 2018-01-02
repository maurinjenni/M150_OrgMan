using System;
using System.Collections.Generic;

namespace OrgMan.DataModel
{
    public interface IEntityUID
    {
        Guid UID { get; set; }

        Guid SysInsertAccountUID { get; set; }

        DateTimeOffset SysInsertTime { get; set; }

        Nullable<Guid> SysUpdateAccountUID { get; set; }

        Nullable<DateTimeOffset> SysUpdateTime { get; set; }

        IEnumerable<Guid> MandatorUIDs { get; set; }
    }
}
