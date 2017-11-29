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
    
    public partial class PhoneToPerson : IEntityUID
    {
        public System.Guid UID { get; set; }
        public System.DateTimeOffset SysInsertTime { get; set; }
        public System.Guid SysInsertAccountUID { get; set; }
        public System.DateTimeOffset SysUpdateTime { get; set; }
        public System.Guid SysUpdateAccountUID { get; set; }
        public System.Guid PhoneUID { get; set; }
        public System.Guid PersonUID { get; set; }
        public System.Guid CommunicationTypeUID { get; set; }
        public bool MainPhoneNumber { get; set; }
    
        public virtual CommunicationType CommunicationType { get; set; }
        public virtual Person Person { get; set; }
        public virtual Phone Phone { get; set; }
    }
}
