using OrgMan.Data.Repository.Repositorybase;
using OrgMan.DataContracts.Repository.RepositoryBase;
using OrgMan.DataModel;

namespace OrgMan.Data.Repository
{
    public class PersonRepository : GenericRepository<Person>, IGenericRepository<Person>
    {
        public PersonRepository(OrgManEntities context) : base(context)
        {

        }
    }
}
