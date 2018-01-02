using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Practices.Unity;
using OrgMan.Common.DynamicSearchService;
using OrgMan.Data.UnitOfWork;
using OrgMan.Domain.Handler.HandlerBase;
using OrgMan.DomainContracts.Adress;
using OrgMan.DomainObjects.Adress;

namespace OrgMan.Domain.Handler.Adress
{
    public class UpdateAdressQueryHandler : QueryHandlerBase
    {
        private UpdateAdressQuery _query;

        public UpdateAdressQueryHandler(UpdateAdressQuery query, IUnityContainer unityContainer) : base(unityContainer)
        {
            _query = query;
        }

        public AdressManagementDetailDomainModel Handle()
        {
            OrgManUnitOfWork uow = new OrgManUnitOfWork();

            var individualPerson = Mapper.Map<DataModel.IndividualPerson>(_query.AdressManagementDetailDomainModel);

            //individualPerson.SysUpdateAccountUID = Guid.NewGuid();
            //individualPerson.SysUpdateTime = DateTimeOffset.Now;

            //individualPerson.Person.SysUpdateAccountUID = Guid.NewGuid();
            //individualPerson.Person.SysUpdateTime = DateTimeOffset.Now;

            if(individualPerson.MemberInformation != null)
            {
                //individualPerson.MemberInformation.SysUpdateAccountUID = Guid.NewGuid();
                //individualPerson.MemberInformation.SysUpdateTime = DateTimeOffset.Now;
            }

            if(individualPerson.Adress != null)
            {
                //individualPerson.Adress.SysUpdateAccountUID = Guid.NewGuid();
                //individualPerson.Adress.SysUpdateTime = DateTimeOffset.Now;
            }

            foreach (var phone in individualPerson.Phones)
            {
                //phone.SysUpdateAccountUID = Guid.NewGuid();
                //phone.SysUpdateTime = DateTimeOffset.Now;
            }

            foreach (var email in individualPerson.Emails)
            {
                //email.SysUpdateAccountUID = Guid.NewGuid();
                //email.SysUpdateTime = DateTimeOffset.Now;
            }


            uow.IndividualPersonRepository.Update(individualPerson);
            uow.PersonRepository.Update(individualPerson.Person);
            uow.AdressRepository.Update(individualPerson.Adress);

            foreach (var phone in individualPerson.Phones)
            {
                uow.PhoneRepository.Update(phone);
                //phone.SysUpdateAccountUID = Guid.NewGuid();
                //phone.SysUpdateTime = DateTimeOffset.Now;
            }

            foreach (var email in individualPerson.Emails)
            {
                uow.EmailRepository.Update(email);
                //email.SysUpdateAccountUID = Guid.NewGuid();
                //email.SysUpdateTime = DateTimeOffset.Now;
            }

            uow.Commit();

            return Mapper.Map<AdressManagementDetailDomainModel>(individualPerson);
        }
    }
}
