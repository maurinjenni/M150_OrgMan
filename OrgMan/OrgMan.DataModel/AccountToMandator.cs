//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrgMan.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class AccountToMandator : IEntityUID
    {
        public System.Guid UID { get; set; }
        public System.DateTimeOffset SysInsertTime { get; set; }
        public System.Guid SysInsertAccountUID { get; set; }
        public Nullable<System.DateTimeOffset> SysUpdateTime { get; set; }
        public Nullable<System.Guid> SysUpdateAccountUID { get; set; }
        public System.Guid MandatorUID { get; set; }
        public System.Guid AccountUID { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual Mandator Mandator { get; set; }
    }
}
