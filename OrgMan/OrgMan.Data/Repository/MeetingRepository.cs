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
    public class MeetingRepository : GenericRepository<Meeting>, IGenericRepository<Meeting>
    {
        public MeetingRepository(OrgManEntities context) : base(context)
        {

        }
    }
}
