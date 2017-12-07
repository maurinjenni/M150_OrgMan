using AutoMapper;
using Microsoft.Practices.Unity;
using OrgMan.Data.UnitOfWork;
using OrgMan.Domain.Handler.HandlerBase;
using OrgMan.DomainContracts.Adress;

namespace OrgMan.Domain.Handler.Adress
{
    public class InsertAdressQueryHandler : QueryHandlerBase
    {
        private InsertAdressQuery _query;

        public InsertAdressQueryHandler(InsertAdressQuery query, IUnityContainer unityContainer) : base(unityContainer)
        {
            _query = query;
        }

        public void Handle()
        {
            OrgManUnitOfWork uow = new OrgManUnitOfWork();

            uow.AdressRepository.Update(_query.MandatorUID, Mapper.Map<DataModel.Adress>(_query.Adress));
        }
    }
}
