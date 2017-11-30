using OrgMan.Data.Repository.Repositorybase;
using OrgMan.DataContracts.Repository.RepositoryBase;
using OrgMan.DataModel;

namespace OrgMan.Data.Repository
{
    public class EmailAdressRepository : GenericRepository<EmailAdress>, IGenericRepository<EmailAdress>
    {
        public EmailAdressRepository(OrgManEntities context) : base(context)
        {

        }
    }
}
