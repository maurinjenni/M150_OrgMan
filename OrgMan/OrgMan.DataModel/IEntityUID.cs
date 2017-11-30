using System;

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
