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
    
    public partial class MemberInformationToMembership
    {
        public System.Guid UID { get; set; }
        public System.DateTimeOffset SysInsertTime { get; set; }
        public System.Guid SysInsertAccountUID { get; set; }
        public System.DateTimeOffset SysUpdateTime { get; set; }
        public System.Guid SysUpdateAccountUID { get; set; }
        public System.Guid MemberInformationUID { get; set; }
        public System.Guid MembershipUID { get; set; }
    
        public virtual MemberInformation MemberInformation { get; set; }
        public virtual Membership Membership { get; set; }
    }
}
