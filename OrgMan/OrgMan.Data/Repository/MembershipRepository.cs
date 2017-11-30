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
    public class MembershipRepository : GenericRepository<Membership>, IGenericRepository<Membership>
    {
        public MembershipRepository(OrgManEntities context) : base(context)
        {

        }
    }
}
