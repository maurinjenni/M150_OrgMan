using System;
using System.Collections.Generic;
using System.Linq;
using Fissoft.EntityFramework.Fts;
using OrgMan.Data.Repository.Repositorybase;
using OrgMan.DataContracts.Repository;
using OrgMan.DataContracts.Repository.RepositoryBase;
using OrgMan.DataModel;

namespace OrgMan.Data.Repository
{
    public class IndividualPersonRepository : GenericRepository<IndividualPerson>, IIndividualPersonRepository
    {
        public IndividualPersonRepository(OrgManEntities context) : base(context)
        {
            DbInterceptors.Init();
        }

        public IEnumerable<IndividualPerson> Get(List<Guid> mandatorUids, string fullTextSeachString)
        {
            /*Search comparison with LIKE*/
            var individualPersons = Context.IndividualPersons.Where(i => string.IsNullOrEmpty(fullTextSeachString) || (i.Person.Firstname + i.Person.Lastname).Contains(fullTextSeachString)).ToList();

            return individualPersons.Where(i => i.MandatorUIDs != null && i.MandatorUIDs.Intersect(mandatorUids).Any());
        }
    }
}
