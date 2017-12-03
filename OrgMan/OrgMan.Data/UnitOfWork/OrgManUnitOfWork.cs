using System.Data.Entity.Infrastructure;
using System.Linq;
using OrgMan.DataModel;
using OrgMan.DataContracts.Repository.RepositoryBase;
using OrgMan.Data.Repository;

namespace OrgMan.Data.UnitOfWork
{
    public class OrgManUnitOfWork
    {
        private readonly OrgManEntities _context;

        public OrgManUnitOfWork(OrgManEntities context =  null)
        {
            _context = context ?? new OrgManEntities();

            AccountRepository = new AccountRepository(_context);
            AccountToMandatorRepository = new AccountToMandatorRepository(_context);
            AdressRepository = new AdressRepository(_context);
            CommunicationTypeRepository = new CommunicationTypeRepository(_context);
            CountryRepository = new CountryRepository(_context);
            EmailAdressRepository = new EmailAdressRepository(_context);
            EmailAdressToPersonRepository = new EmailAdressToPersonRepository(_context);
            LoginRepository = new LoginRepository(_context);
            MandatorRepository = new MandatorRepository(_context);
            MeetingRepository = new MeetingRepository(_context);
            MemberInformationRepository = new MemberInformationRepository(_context);
            MemberInformationToMembershipRepository = new MemberInformationToMembershipRepository(_context);

            MembershipRepository = new MembershipRepository(_context);
            PersonRepository = new PersonRepository(_context);
            PhoneRepository = new PhoneRepository(_context);
            PhoneToPersonRepository = new PhoneToPersonRepository(_context);
            SalutationRepository = new SalutationRepository(_context);
        }

        public IGenericRepository<Account> AccountRepository { get; set; }

        public IGenericRepository<AccountToMandator> AccountToMandatorRepository { get; set; }

        public IGenericRepository<Adress> AdressRepository { get; set; }

        public IGenericRepository<CommunicationType> CommunicationTypeRepository { get; set; }

        public IGenericRepository<Country> CountryRepository { get; set; }

        public IGenericRepository<EmailAdress> EmailAdressRepository { get; set; }

        public IGenericRepository<EmailAdressToPerson> EmailAdressToPersonRepository { get; set; }

        public IGenericRepository<Login> LoginRepository { get; set; }

        public IGenericRepository<Mandator> MandatorRepository { get; set; }

        public IGenericRepository<Meeting> MeetingRepository { get; set; }

        public IGenericRepository<MemberInformation> MemberInformationRepository { get; set; }

        public IGenericRepository<MemberInformationToMembership> MemberInformationToMembershipRepository { get; set; }

        public IGenericRepository<Membership> MembershipRepository { get; set; }

        public IGenericRepository<Person> PersonRepository { get; set; }

        public IGenericRepository<Phone> PhoneRepository { get; set; }

        public IGenericRepository<PhoneToPerson> PhoneToPersonRepository { get; set; }

        public IGenericRepository<Salutation> SalutationRepository{ get; set; }

        public void Commit()
        {
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
