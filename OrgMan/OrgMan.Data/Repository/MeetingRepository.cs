using OrgMan.Data.Repository.Repositorybase;
using OrgMan.DataContracts.Repository.RepositoryBase;
using OrgMan.DataModel;

namespace OrgMan.Data.Repository
{
    public class MeetingRepository : GenericRepository<Meeting>, IGenericRepository<Meeting>
    {
        public MeetingRepository(OrgManEntities context) : base(context)
        {

        }
    }
}
