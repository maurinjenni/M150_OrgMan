using OrgMan.Data.Repository.Repositorybase;
using OrgMan.DataContracts.Repository.RepositoryBase;
using OrgMan.DataModel;

namespace OrgMan.Data.Repository
{
    public class PhoneRepository : GenericRepository<Phone>, IGenericRepository<Phone>
    {
        public PhoneRepository(OrgManEntities context) : base(context)
        {

        }
    }
}
