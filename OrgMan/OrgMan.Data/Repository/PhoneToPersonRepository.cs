using OrgMan.Data.Repository.Repositorybase;
using OrgMan.DataContracts.Repository.RepositoryBase;
using OrgMan.DataModel;

namespace OrgMan.Data.Repository
{ 
    public class PhoneToPersonRepository : GenericRepository<PhoneToPerson>, IGenericRepository<PhoneToPerson>
    {
        public PhoneToPersonRepository(OrgManEntities context) : base(context)
        {

        }
    }
}

