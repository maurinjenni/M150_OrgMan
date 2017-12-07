using AutoMapper;
using Microsoft.Practices.Unity;
using OrgMan.Data.UnitOfWork;
using OrgMan.Domain.Handler.HandlerBase;
using OrgMan.DomainContracts.Adress;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OrgMan.Domain.Handler.Adress
{
    public class DeleteAdressQueryHandler : QueryHandlerBase
    {
        private DeleteAdressQuery _query;

        public DeleteAdressQueryHandler(DeleteAdressQuery query, IUnityContainer unityContainer) : base(unityContainer)
        {
            _query = query;
        }

        public void Handle()
        {
            OrgManUnitOfWork uow = new OrgManUnitOfWork();

            uow.AdressRepository.Delete(_query.MandatorUID, _query.AdressUID);
        }
    }
}