using OrgMan.Data.Repository.Repositorybase;
using OrgMan.DataContracts.Repository.RepositoryBase;
using OrgMan.DataModel;

namespace OrgMan.Data.Repository
{
    public class MemberInformationRepository : GenericRepository<MemberInformation>, IGenericRepository<MemberInformation>
    {
        public MemberInformationRepository(OrgManEntities context) : base(context)
        {

        }
    }
}
