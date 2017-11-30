using OrgMan.Data.Repository.Repositorybase;
using OrgMan.DataContracts.Repository.RepositoryBase;
using OrgMan.DataModel;

namespace OrgMan.Data.Repository
{
    public class CommunicationTypeRepository : GenericRepository<CommunicationType>, IGenericRepository<CommunicationType>
    {
        public CommunicationTypeRepository(OrgManEntities context) : base(context)
        {

        }
    }
}
