using OrgMan.Data.Repository.Repositorybase;
using OrgMan.DataContracts.Repository.RepositoryBase;
using OrgMan.DataModel;

namespace OrgMan.Data.Repository
{
    public class MandatorRepository : GenericRepository<Mandator>, IGenericRepository<Mandator>
    {
        public MandatorRepository(OrgManEntities context) : base(context)
        {

        }
    }
}
