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
            var text = FullTextSearchModelUtil.Contains(fullTextSeachString);

            return Context.IndividualPersons.Where(i =>
                (i.Company != null && i.Company.Contains(text)) ||
                (i.Person != null && i.Person.Firstname.Contains(text)) ||
                (i.Person != null && i.Person.Lastname.Contains(text)) ||
                (i.Person != null && i.Person.Salutation.Title.Contains(text)) ||
                (i.Adress != null && i.Adress.City.Contains(text)) ||
                (i.Adress != null && i.Adress.Street.Contains(text)) ||
                (i.Adress != null && i.Adress.HouseNumber.Contains(text)) ||
                (i.Adress != null && i.Adress.Country != null && i.Adress.Country.Title.Contains(text))).ToList();
        }
    }
}
