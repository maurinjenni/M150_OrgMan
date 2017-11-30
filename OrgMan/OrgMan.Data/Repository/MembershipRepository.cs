using OrgMan.Data.Repository.Repositorybase;
using OrgMan.DataContracts.Repository.RepositoryBase;
using OrgMan.DataModel;

namespace OrgMan.Data.Repository
{
    public class MembershipRepository : GenericRepository<Membership>, IGenericRepository<Membership>
    {
        public MembershipRepository(OrgManEntities context) : base(context)
        {

        }
    }
}
