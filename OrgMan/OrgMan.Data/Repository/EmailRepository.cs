using OrgMan.Data.Repository.Repositorybase;
using OrgMan.DataContracts.Repository.RepositoryBase;
using OrgMan.DataModel;

namespace OrgMan.Data.Repository
{
    public class EmailRepository : GenericRepository<Email>, IGenericRepository<Email>
    {
        public EmailRepository(OrgManEntities context) : base(context)
        {

        }
    }
}
