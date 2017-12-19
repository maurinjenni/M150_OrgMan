using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrgMan.Data.Repository.Repositorybase;
using OrgMan.DataContracts.Repository.RepositoryBase;
using OrgMan.DataModel;

namespace OrgMan.Data.Repository
{
    public class SessionRepository : GenericRepository<Session>, IGenericRepository<Session>
    {
        public SessionRepository(OrgManEntities context) : base(context)
        {
            
        }
    }
}
