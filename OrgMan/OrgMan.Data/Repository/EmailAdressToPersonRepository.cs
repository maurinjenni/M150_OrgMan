using OrgMan.Data.Repository.Repositorybase;
using OrgMan.DataContracts.Repository.RepositoryBase;
using OrgMan.DataModel;

namespace OrgMan.Data.Repository
{
    public class EmailAdressToPersonRepository : GenericRepository<Email>, IGenericRepository<Email>
    {
        public EmailAdressToPersonRepository(OrgManEntities context) : base(context)
        {

        }
    }
}
