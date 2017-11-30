using OrgMan.Data.Repository.Repositorybase;
using OrgMan.DataContracts.Repository.RepositoryBase;
using OrgMan.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.Data.Repository
{
    public class LoginRepository : GenericRepository<Login>, IGenericRepository<Login>
    {
        public LoginRepository(OrgManEntities context) : base(context)
        {

        }
    }
}
