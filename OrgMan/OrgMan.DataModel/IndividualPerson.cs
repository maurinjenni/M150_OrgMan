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
    
    public partial class IndividualPerson : IEntityUID
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IndividualPerson()
        {
            this.Emails = new HashSet<Email>();
            this.Phones = new HashSet<Phone>();
        }
    
        public System.Guid UID { get; set; }
        public System.DateTimeOffset SysInsertTime { get; set; }
        public System.Guid SysInsertAccountUID { get; set; }
        public Nullable<System.DateTimeOffset> SysUpdateTime { get; set; }
        public Nullable<System.Guid> SysUpdateAccountUID { get; set; }
        public System.Guid AdressUID { get; set; }
        public Nullable<System.Guid> MemberInformationUID { get; set; }
        public string Company { get; set; }
        public Nullable<System.DateTime> Birthdate { get; set; }
        public string Comment { get; set; }
        public string PictureLink { get; set; }
    
        public virtual Adress Adress { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Email> Emails { get; set; }
        public virtual MemberInformation MemberInformation { get; set; }
        public virtual Person Person { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phone> Phones { get; set; }
    }
}
