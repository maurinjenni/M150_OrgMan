using OrgMan.Data.Repository.Repositorybase;
using OrgMan.DataContracts.Repository.RepositoryBase;
using OrgMan.DataModel;

namespace OrgMan.Data.Repository
{
    public class SalutationRepository : GenericRepository<Salutation>, IGenericRepository<Salutation>
    {
        public SalutationRepository(OrgManEntities context) : base(context)
        {

        }
    }
}
