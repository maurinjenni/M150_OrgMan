using OrgMan.Data.Repository.Repositorybase;
using OrgMan.DataContracts.Repository.RepositoryBase;
using OrgMan.DataModel;

namespace OrgMan.Data.Repository
{
    public class LoginRepository : GenericRepository<Login>, IGenericRepository<Login>
    {
        public LoginRepository(OrgManEntities context) : base(context)
        {

        }
    }
}
