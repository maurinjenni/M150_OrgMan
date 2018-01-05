using OrgMan.Data.Repository.Repositorybase;
using OrgMan.DataContracts.Repository.RepositoryBase;
using OrgMan.DataModel;

namespace OrgMan.Data.Repository
{
    public class IndividualPersonRepository : GenericRepository<IndividualPerson>, IGenericRepository<IndividualPerson>
    {
        public IndividualPersonRepository(OrgManEntities context) : base(context)
        {

        }
    }
}
