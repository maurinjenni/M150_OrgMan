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

                uow.IndividualPersonRepository.Update(individualPerson);
                uow.PersonRepository.Update(individualPerson.Person);
                uow.AdressRepository.Update(individualPerson.Adress);

                foreach (var phone in individualPerson.Phones)
                {
                    uow.PhoneRepository.Update(phone);
                }

                foreach (var email in individualPerson.Emails)
                {
                    uow.EmailRepository.Update(email);
                }

                uow.Commit();

                return Mapper.Map<AdressManagementDetailDomainModel>(individualPerson);
            }
            catch(InvalidOperationException)
            {
                throw new Exception("Internal Server Error thrown during update process");
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
