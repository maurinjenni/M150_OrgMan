﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OrgManEntities : DbContext
    {
        public OrgManEntities()
            : base("name=OrgManEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Adress> Adresses { get; set; }
        public virtual DbSet<CommunicationType> CommunicationTypes { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Email> Emails { get; set; }
        public virtual DbSet<IndividualPerson> IndividualPersons { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Mandator> Mandators { get; set; }
        public virtual DbSet<Meeting> Meetings { get; set; }
        public virtual DbSet<MemberInformation> MemberInformations { get; set; }
        public virtual DbSet<MemberInformationToMembership> MemberInformationToMemberships { get; set; }
        public virtual DbSet<Membership> Memberships { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PersonToMandator> PersonToMandators { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<Salutation> Salutations { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<SystemPerson> SystemPersons { get; set; }
    }
}
