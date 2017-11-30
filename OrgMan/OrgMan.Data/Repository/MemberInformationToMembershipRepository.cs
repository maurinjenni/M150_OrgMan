using OrgMan.Data.Repository.Repositorybase;
using OrgMan.DataContracts.Repository.RepositoryBase;
using OrgMan.DataModel;

namespace OrgMan.Data.Repository
{
    public class MemberInformationToMembershipRepository : GenericRepository<MemberInformationToMembership>, IGenericRepository<MemberInformationToMembership>
    {
        public MemberInformationToMembershipRepository(OrgManEntities context) : base(context)
        {

        }
    }
}
