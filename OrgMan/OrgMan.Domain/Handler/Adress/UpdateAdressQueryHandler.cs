using System;
using AutoMapper;
using Microsoft.Practices.Unity;
using OrgMan.Data.UnitOfWork;
using OrgMan.Domain.Handler.HandlerBase;
using OrgMan.DomainContracts.Adress;
using OrgMan.DomainObjects.Adress;
using System.Data;

namespace OrgMan.Domain.Handler.Adress
{
    public class UpdateAdressQueryHandler : QueryHandlerBase
    {
        private readonly UpdateAdressQuery _query;

        public UpdateAdressQueryHandler(UpdateAdressQuery query, IUnityContainer unityContainer) : base(unityContainer)
        {
            _query = query;
        }

        public AdressManagementDetailDomainModel Handle()
        {
            try
            {
                OrgManUnitOfWork uow = new OrgManUnitOfWork();

                var individualPerson = Mapper.Map<DataModel.IndividualPerson>(_query.AdressManagementDetailDomainModel);

                uow.IndividualPersonRepository.Update(_query.MandatorUIDs, individualPerson);
                uow.PersonRepository.Update(_query.MandatorUIDs, individualPerson.Person);
                uow.AdressRepository.Update(_query.MandatorUIDs, individualPerson.Adress);

                foreach (var phone in individualPerson.Phones)
                {
                    uow.PhoneRepository.Update(_query.MandatorUIDs, phone);
                }

                foreach (var email in individualPerson.Emails)
                {
                    uow.EmailRepository.Update(_query.MandatorUIDs, email);
                }

                uow.Commit();

                return Mapper.Map<AdressManagementDetailDomainModel>(individualPerson);
            }
            catch(InvalidOperationException e)
            {
                throw new Exception("Internal Server Error thrown during update process", e);
            }
            catch (DataException e)
            {
                throw new Exception("Internal Server Error", e);
            }
            catch (Exception)
            {
                throw new Exception("Internal Server Error");
            }
        }
    }
}
