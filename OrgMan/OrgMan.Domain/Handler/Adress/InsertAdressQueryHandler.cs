using AutoMapper;
using Microsoft.Practices.Unity;
using OrgMan.Data.UnitOfWork;
using OrgMan.Domain.Handler.HandlerBase;
using OrgMan.DomainContracts.Adress;
using System;
using OrgMan.DataModel;
using System.Data;

namespace OrgMan.Domain.Handler.Adress
{
    public class InsertAdressQueryHandler : QueryHandlerBase
    {
        private readonly InsertAdressQuery _query;
        private readonly OrgManUnitOfWork _uow;

        public InsertAdressQueryHandler(InsertAdressQuery query, IUnityContainer unityContainer) : base(unityContainer)
        {
            _query = query;
            _uow = new OrgManUnitOfWork();
        }

        public Guid Handle()
        {
            try
            {
                IndividualPerson individualPerson = Mapper.Map<IndividualPerson>(_query.AdressManagementDetailDomainModel);

                if(individualPerson == null)
                {
                    throw new DataException("Could not Map AdressManagementDetailDomainModel to IndividualPerson");
                }

                Guid individualPersonUid = Guid.NewGuid();
                Guid adressUid = Guid.NewGuid();
                Guid memberinformationUid = Guid.NewGuid();

                individualPerson.UID = individualPersonUid;

                individualPerson.Person.UID = individualPersonUid;
                individualPerson.AdressUID = adressUid;

                if (individualPerson.MemberInformation != null)
                {
                    individualPerson.MemberInformation.UID = memberinformationUid;
                }

                if (individualPerson.Adress != null)
                {
                    individualPerson.Adress.UID = adressUid;
                }

                foreach (var phone in individualPerson.Phones)
                {
                    phone.IndividualPersonUID = individualPersonUid;
                    phone.UID = Guid.NewGuid();
                }

                foreach (var email in individualPerson.Emails)
                {
                    email.IndividualPersonUID = individualPersonUid;
                    email.UID = Guid.NewGuid();
                }

                _uow.IndividualPersonRepository.Insert(_query.MandatorUIDs, individualPerson);

                _uow.Commit();

                return individualPerson.UID;
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
