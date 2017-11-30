using OrgMan.Data.Repository.Repositorybase;
using OrgMan.DataContracts.Repository.RepositoryBase;
using OrgMan.DataModel;

namespace OrgMan.Data.Repository
{
    public class AccountToMandatorRepository : GenericRepository<AccountToMandator>, IGenericRepository<AccountToMandator>
    {
        public AccountToMandatorRepository(OrgManEntities context) : base(context)
        {

        }
    }
}
