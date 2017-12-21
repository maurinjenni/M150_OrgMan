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
    
    public partial class Mandator : IEntityUID
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mandator()
        {
            this.Meetings = new HashSet<Meeting>();
            this.PersonToMandators = new HashSet<PersonToMandator>();
        }
    
        public System.Guid UID { get; set; }
        public System.DateTimeOffset SysInsertTime { get; set; }
        public System.Guid SysInsertAccountUID { get; set; }
        public Nullable<System.DateTimeOffset> SysUpdateTime { get; set; }
        public Nullable<System.Guid> SysUpdateAccountUID { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Meeting> Meetings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonToMandator> PersonToMandators { get; set; }
    }
}
