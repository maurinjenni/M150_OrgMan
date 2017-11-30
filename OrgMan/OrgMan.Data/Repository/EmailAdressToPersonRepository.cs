using OrgMan.Data.Repository.Repositorybase;
using OrgMan.DataContracts.Repository.RepositoryBase;
using OrgMan.DataModel;

namespace OrgMan.Data.Repository
{
    public class EmailAdressToPersonRepository : GenericRepository<EmailAdressToPerson>, IGenericRepository<EmailAdressToPerson>
    {
        public EmailAdressToPersonRepository(OrgManEntities context) : base(context)
        {

        }
    }
}
