using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OrgMan.DomainContracts;
using OrgMan.DomainContracts.Person;
using OrgMan.Domain.Handler.HandlerBase;
using Microsoft.Practices.Unity;
using OrgMan.DomainObjects;
using OrgMan.Data.UnitOfWork;

namespace OrgMan.Domain.Handler.Person
{
    public class GetPersonQueryHandler : QueryHandlerBase
    {
        private readonly GetPersonQuery _query;

        public GetPersonQueryHandler(GetPersonQuery query, IUnityContainer unityContainer) : base(unityContainer)
        {
            _query = query;
        }

        public PersonDomainModel Handle()
        {
            OrgManUnitOfWork uow = new OrgManUnitOfWork();

            var person = uow.PersonRepository.Get(_query.MandatorUID, _query.PersonUID);

            return Mapper.Map<PersonDomainModel>(person);
        }
    }
}
