using System.Data.Entity.Infrastructure;
using System.Linq;
using OrgMan.DataModel;
using OrgMan.DataContracts.Repository.RepositoryBase;
using OrgMan.Data.Repository;
using OrgMan.Data.Repository.Repositorybase;
using OrgMan.DataContracts.Repository;
using System.Data.Entity.Core.Objects;
using System.Collections.Generic;
using System;

namespace OrgMan.Data.UnitOfWork
{
    public class OrgManUnitOfWork
    {
        private readonly OrgManEntities _context;

        public OrgManUnitOfWork(OrgManEntities context =  null)
        {
            _context = context ?? new OrgManEntities();
            AdressRepository = new AdressRepository(_context);
            CommunicationTypeRepository = new CommunicationTypeRepository(_context);
            CountryRepository = new CountryRepository(_context);
            LoginRepository = new LoginRepository(_context);
            MandatorRepository = new MandatorRepository(_context);
            PersonToMandatorRepository = new GenericRepository<PersonToMandator>(_context);
            MeetingRepository = new MeetingRepository(_context);
            MemberInformationRepository = new MemberInformationRepository(_context);
            MemberInformationToMembershipRepository = new MemberInformationToMembershipRepository(_context);
            MembershipRepository = new MembershipRepository(_context);
            PhoneRepository = new PhoneRepository(_context);
            EmailRepository = new EmailRepository(_context);
            SalutationRepository = new SalutationRepository(_context);
            IndividualPersonRepository = new GenericRepository<IndividualPerson>(_context);
            SystemPersonRepository = new GenericRepository<SystemPerson>(_context);
            PersonRepository = new GenericRepository<Person>(_context);
            AuthenticationRepository = new AuthenticationRepository(_context);
            SessionRepository = new GenericRepository<Session>(_context);
        }


        public IGenericRepository<Adress> AdressRepository { get; set; }

        public IGenericRepository<CommunicationType> CommunicationTypeRepository { get; set; }

        public IGenericRepository<Country> CountryRepository { get; set; }

        public IGenericRepository<Email> EmailRepository { get; set; }

        public IGenericRepository<Login> LoginRepository { get; set; }

        public IGenericRepository<Mandator> MandatorRepository { get; set; }

        public IGenericRepository<Meeting> MeetingRepository { get; set; }

        public IGenericRepository<MemberInformation> MemberInformationRepository { get; set; }

        public IGenericRepository<MemberInformationToMembership> MemberInformationToMembershipRepository { get; set; }

        public IGenericRepository<Membership> MembershipRepository { get; set; }

        public IGenericRepository<Person> PersonRepository { get; set; }

        public IGenericRepository<Phone> PhoneRepository { get; set; }

        public IGenericRepository<Salutation> SalutationRepository{ get; set; }

        public IGenericRepository<IndividualPerson> IndividualPersonRepository { get; set; }

        public IGenericRepository<SystemPerson> SystemPersonRepository { get; set; }

        public IAuthenticationRepository AuthenticationRepository { get; set; }

        public IGenericRepository<Session> SessionRepository { get; set; }

        public IGenericRepository<PersonToMandator> PersonToMandatorRepository { get; set; }

        public void Commit()
        {
            ObjectContext context = ((IObjectContextAdapter)_context).ObjectContext;

            IEnumerable<ObjectStateEntry> objectStateEntries = context.ObjectStateManager.GetObjectStateEntries(System.Data.Entity.EntityState.Added | System.Data.Entity.EntityState.Modified);

            foreach (var entry in objectStateEntries)
            {
                var entityBase = entry.Entity as IEntityUID;

                if(entry.State == System.Data.Entity.EntityState.Added)
                {
                    entityBase.SysInsertAccountUID = Guid.NewGuid();
                    entityBase.SysInsertTime = DateTimeOffset.Now;
                } else if(entry.State == System.Data.Entity.EntityState.Modified)
                {
                    entityBase.SysUpdateAccountUID = Guid.NewGuid();
                    entityBase.SysUpdateTime = DateTimeOffset.Now;
                }
            }

            bool saveFailed;
            do
            {
                saveFailed = false;

                try
                {
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;

                    var entry = ex.Entries.Single();
                    entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                }

            } while (saveFailed);
        }
    }
}
