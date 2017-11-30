using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrgMan.DataModel;
using OrgMan.DataContracts.Repository.RepositoryBase;
using OrgMan.Data.Repository;

namespace OrgMan.Data.UnitOfWork
{
    public class OrgManUnitOfWork
    {
        private readonly OrgManEntities _context;

        public OrgManUnitOfWork(OrgManEntities context)
        {
            _context = context;

            AccountRepository = new AccountRepository(context);
            AccountToMandatorRepository = new AccountToMandatorRepository(context);
            AdressRepository = new AdressRepository(context);
            CommunicationTypeRepository = new CommunicationTypeRepository(context);
            CountryRepository = new CountryRepository(context);
            EmailAdressRepository = new EmailAdressRepository(context);
            EmailAdressToPersonRepository = new EmailAdressToPersonRepository(context);
            LoginRepository = new LoginRepository(context);
            MandatorRepository = new MandatorRepository(context);
            MeetingRepository = new MeetingRepository(context);
            MemberInformationRepository = new MemberInformationRepository(context);
            MemberInformationToMembershipRepository = new MemberInformationToMembershipRepository(context);

            MembershipRepository = new MembershipRepository(context);
            PersonRepository = new PersonRepository(context);
            PhoneRepository = new PhoneRepository(context);
            PhoneToPersonRepository = new PhoneToPersonRepository(context);
            SalutationRepository = new SalutationRepository(context);
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
