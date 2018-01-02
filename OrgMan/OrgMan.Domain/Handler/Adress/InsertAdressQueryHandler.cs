using AutoMapper;
using Microsoft.Practices.Unity;
using OrgMan.Data.UnitOfWork;
using OrgMan.Domain.Handler.HandlerBase;
using OrgMan.DomainContracts.Adress;
using System;
using OrgMan.DataModel;

namespace OrgMan.Domain.Handler.Adress
{
    public class InsertAdressQueryHandler : QueryHandlerBase
    {
        private InsertAdressQuery _query;

        public InsertAdressQueryHandler(InsertAdressQuery query, IUnityContainer unityContainer) : base(unityContainer)
        {
            _query = query;
        }

        public Guid Handle()
        {
            OrgManUnitOfWork uow = new OrgManUnitOfWork();

            IndividualPerson individualPerson = Mapper.Map<DataModel.IndividualPerson>(_query.AdressManagementDetailDomainModel);

            Guid individualPersonUid = Guid.NewGuid();
            Guid adressUid = Guid.NewGuid();
            Guid memberinformationUid = Guid.NewGuid();

            //individualPerson.SysInsertAccountUID = Guid.NewGuid();
            //individualPerson.SysInsertTime = DateTimeOffset.Now;
            individualPerson.UID = individualPersonUid;

            //individualPerson.Person.SysInsertAccountUID = Guid.NewGuid();
            //individualPerson.Person.SysInsertTime = DateTimeOffset.Now;
            individualPerson.Person.UID = individualPersonUid;
            individualPerson.AdressUID = adressUid;

            if (individualPerson.MemberInformation != null)
            {
                //    individualPerson.MemberInformation.SysInsertAccountUID = Guid.NewGuid();
                //    individualPerson.MemberInformation.SysInsertTime = DateTimeOffset.Now;
                individualPerson.MemberInformation.UID = memberinformationUid;
            }

            if(individualPerson.Adress != null)
            {
                //    individualPerson.Adress.SysInsertAccountUID = Guid.NewGuid();
                //    individualPerson.Adress.SysInsertTime = DateTimeOffset.Now;
                individualPerson.Adress.UID = adressUid;
            }

            foreach (var phone in individualPerson.Phones)
            {
                //phone.SysInsertAccountUID = Guid.NewGuid();
                //phone.SysInsertTime = DateTimeOffset.Now;
                phone.IndividualPersonUID = individualPersonUid;
                phone.UID = Guid.NewGuid();
            }

            foreach (var email in individualPerson.Emails)
            {
                //email.SysInsertAccountUID = Guid.NewGuid();
                //email.SysInsertTime = DateTimeOffset.Now;
                email.IndividualPersonUID = individualPersonUid;
                email.UID = Guid.NewGuid();
            }

            uow.IndividualPersonRepository.Insert(individualPerson);
            uow.Commit();

            return individualPerson.UID;
        }
    }
}
