using OrgMan.Data.Repository.Repositorybase;
using OrgMan.DataContracts.Repository.RepositoryBase;
using OrgMan.DataModel;

namespace OrgMan.Data.Repository
{
    public class AccountRepository : GenericRepository<Account>, IGenericRepository<Account>
    {
        public AccountRepository(OrgManEntities context) : base(context)
        {

        }
    }
}
