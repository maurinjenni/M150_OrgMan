using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrgMan.DataContracts.Repository.RepositoryBase;
using OrgMan.DataModel;

namespace OrgMan.DataContracts.Repository
{
    public interface IIndividualPersonRepository : IGenericRepository<IndividualPerson>
    {
        IEnumerable<IndividualPerson> Get(List<Guid> mandatorUids, string fullTextSeachString);
    } 
}
