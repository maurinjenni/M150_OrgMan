using OrgMan.Data.Repository.Repositorybase;
using OrgMan.DataContracts.Repository.RepositoryBase;
using OrgMan.DataModel;

namespace OrgMan.Data.Repository
{ 
    public class SystemPersonRepository : GenericRepository<SystemPerson>, IGenericRepository<SystemPerson>
    {
        public SystemPersonRepository(OrgManEntities context) : base(context)
        {

        }
    }
}
