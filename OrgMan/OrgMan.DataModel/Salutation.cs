
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
    
public partial class Salutation : IEntityUID
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Salutation()
    {

        this.Account = new HashSet<Account>();

        this.Person = new HashSet<Person>();

    }


    public System.Guid UID { get; set; }

    public System.DateTimeOffset SysInsertTime { get; set; }

    public System.Guid SysInsertAccountUID { get; set; }

    public System.DateTimeOffset SysUpdateTime { get; set; }

    public System.Guid SysUpdateAccountUID { get; set; }

    public string Code { get; set; }

    public string Title { get; set; }

    public Nullable<int> OrderKey { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Account> Account { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Person> Person { get; set; }

}

}
