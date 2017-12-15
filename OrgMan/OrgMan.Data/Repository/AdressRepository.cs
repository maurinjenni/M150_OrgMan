using System;
using OrgMan.Data.Repository.Repositorybase;
using OrgMan.DataContracts.Repository.RepositoryBase;
using OrgMan.DataModel;

namespace OrgMan.Data.Repository
{
    public class AdressRepository : GenericRepository<Adress>, IGenericRepository<Adress>
    {
        public AdressRepository(OrgManEntities context) : base(context)
        {

        }
    }
}
