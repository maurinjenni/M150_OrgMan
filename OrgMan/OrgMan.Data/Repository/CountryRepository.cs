using OrgMan.Data.Repository.Repositorybase;
using OrgMan.DataContracts.Repository.RepositoryBase;
using OrgMan.DataModel;

namespace OrgMan.Data.Repository
{
    public class CountryRepository : GenericRepository<Country>, IGenericRepository<Country>
    {
        public CountryRepository(OrgManEntities context) : base(context)
        {

        }
    }
}
