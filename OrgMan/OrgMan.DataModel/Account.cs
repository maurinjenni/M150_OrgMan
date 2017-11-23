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
    
    public partial class Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            this.AccountToMandator = new HashSet<AccountToMandator>();
            this.Login = new HashSet<Login>();
            this.Person = new HashSet<Person>();
        }
    
        public System.Guid UID { get; set; }
        public System.DateTimeOffset SysInsertTime { get; set; }
        public System.Guid SysInsertAccountUID { get; set; }
        public System.DateTimeOffset SysUpdateTime { get; set; }
        public System.Guid SysUpdateAccountUID { get; set; }
        public Nullable<System.Guid> SalutationUID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string EmailAdress { get; set; }
        public string MobileNumber { get; set; }
        public bool Verified { get; set; }
        public string PictureReference { get; set; }
    
        public virtual Salutation Salutation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccountToMandator> AccountToMandator { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Login> Login { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person> Person { get; set; }
    }
}
