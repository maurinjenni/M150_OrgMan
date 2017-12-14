//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrgMan.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Person : IEntityUID
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            this.PersonToMandators = new HashSet<PersonToMandator>();
        }
    
        public System.Guid UID { get; set; }
        public System.DateTimeOffset SysInsertTime { get; set; }
        public System.Guid SysInsertAccountUID { get; set; }
        public Nullable<System.DateTimeOffset> SysUpdateTime { get; set; }
        public Nullable<System.Guid> SysUpdateAccountUID { get; set; }
        public System.Guid SalutationUID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    
        public virtual IndividualPerson IndividualPerson { get; set; }
        public virtual Login Login { get; set; }
        public virtual Salutation Salutation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonToMandator> PersonToMandators { get; set; }
        public virtual SystemPerson SystemPerson { get; set; }
    }
}
