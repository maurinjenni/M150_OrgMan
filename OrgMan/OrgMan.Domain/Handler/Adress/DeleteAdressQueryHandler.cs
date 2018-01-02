using AutoMapper;
using Microsoft.Practices.Unity;
using OrgMan.Data.UnitOfWork;
using OrgMan.DataModel;
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
        private OrgManUnitOfWork uow;

        public DeleteAdressQueryHandler(DeleteAdressQuery query, IUnityContainer unityContainer) : base(unityContainer)
        {
            _query = query;
            uow = new OrgManUnitOfWork();
        }

        public void Handle()
        {
            IndividualPerson individualPerson = uow.IndividualPersonRepository.Get(_query.IndividualPersonUID);

            Guid adressUid = individualPerson.AdressUID;

            if (individualPerson.Phones != null && individualPerson.Phones.Any())
            {
                DeletePhones(individualPerson.Phones.Select(p => p.UID).ToList());
            }

            if (individualPerson.Emails != null && individualPerson.Emails.Any())
            {
                DeleteEmails(individualPerson.Emails.Select(p => p.UID).ToList());
            }

            if (individualPerson.Person.PersonToMandators != null && individualPerson.Person.PersonToMandators.Any())
            {
                DeletePersonToMandators(individualPerson.Person.PersonToMandators.Select(p => p.UID).ToList());
            }

            if (individualPerson.Person.Login != null)
            {
                if (individualPerson.Person.Login.Sessions != null && individualPerson.Person.Login.Sessions.Any())
                {
                    DeleteSessions(individualPerson.Person.Login.Sessions.Select(s => s.UID).ToList());
                }

                uow.LoginRepository.Delete(individualPerson.Person.Login.UID);
            }

            if (individualPerson.Person != null && individualPerson.Person.IndividualPerson != null && individualPerson.Person.SystemPerson == null)
            {
                uow.PersonRepository.Delete(individualPerson.Person.UID);
            }

            uow.IndividualPersonRepository.Delete(_query.IndividualPersonUID);

            if (individualPerson.MemberInformationUID != null)
            {
                if (individualPerson.MemberInformation.MemberInformationToMemberships != null && individualPerson.MemberInformation.MemberInformationToMemberships.Any())
                {
                    DeleteMemberInformationToMemberships(individualPerson.MemberInformation.MemberInformationToMemberships.Select(m => m.UID).ToList());
                }

                DeleteMemberInformation(individualPerson.MemberInformationUID.Value);
            }

            DeleteAdress(individualPerson.AdressUID);

            uow.Commit();
        }

        private void DeletePhones(List<Guid> uids)
        {
            foreach (var uid in uids)
            {
                uow.PhoneRepository.Delete(uid);
            }
        }

        private void DeleteEmails(List<Guid> uids)
        {
            foreach (var uid in uids)
            {
                uow.EmailRepository.Delete(uid);
            }
        }

        private void DeletePersonToMandators(List<Guid> uids)
        {
            foreach (var uid in uids)
            {
                uow.PersonToMandatorRepository.Delete(uid);
            }
        }

        private void DeleteSessions(List<Guid> uids)
        {
            foreach (var uid in uids)
            {
                uow.SessionRepository.Delete(uid);
            }
        }

        private void DeleteMemberInformationToMemberships(List<Guid> uids)
        {
            foreach (var uid in uids)
            {
                uow.MemberInformationToMembershipRepository.Delete(uid);
            }
        }

        private void DeleteAdress(Guid uid)
        {
            var adress = uow.AdressRepository.Get(uid);

            if (adress.IndividualPersons.Count == 0)
            {
                uow.AdressRepository.Delete(uid);
            }
        }

        private void DeleteMemberInformation(Guid uid)
        {
            var memberinformation = uow.MemberInformationRepository.Get(uid);

            if(memberinformation.IndividualPersons.Count == 0)
            {
                uow.MemberInformationRepository.Delete(uid);
            }
        }
    }
}