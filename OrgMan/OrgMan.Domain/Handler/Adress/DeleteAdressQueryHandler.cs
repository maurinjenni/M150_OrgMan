using Microsoft.Practices.Unity;
using OrgMan.Data.UnitOfWork;
using OrgMan.DataModel;
using OrgMan.Domain.Handler.HandlerBase;
using OrgMan.DomainContracts.Adress;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace OrgMan.Domain.Handler.Adress
{
    public class DeleteAdressQueryHandler : QueryHandlerBase
    {
        private readonly DeleteAdressQuery _query;
        private readonly OrgManUnitOfWork _uow;

        public DeleteAdressQueryHandler(DeleteAdressQuery query, IUnityContainer unityContainer) : base(unityContainer)
        {
            _query = query;
            _uow = new OrgManUnitOfWork();
        }

        public void Handle()
        {
            try
            {
                IndividualPerson individualPerson = _uow.IndividualPersonRepository.Get(_query.IndividualPersonUID);

                if(individualPerson == null)
                {
                    throw new DataException("No Entity found to UID : " + _query.IndividualPersonUID);
                }
                
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
                else
                {
                    throw new DataException("No MandatorUDIs found for Entity with the UID : " + _query.IndividualPersonUID);
                }

                if (individualPerson.Person.Login != null)
                {
                    if (individualPerson.Person.Login.Sessions != null && individualPerson.Person.Login.Sessions.Any())
                    {
                        DeleteSessions(individualPerson.Person.Login.Sessions.Select(s => s.UID).ToList());
                    }

                    _uow.LoginRepository.Delete(individualPerson.Person.Login.UID);
                }

                if (individualPerson.Person != null && individualPerson.Person.IndividualPerson != null && individualPerson.Person.SystemPerson == null)
                {
                    _uow.PersonRepository.Delete(individualPerson.Person.UID);
                }

                _uow.IndividualPersonRepository.Delete(_query.IndividualPersonUID);

                if (individualPerson.MemberInformationUID != null)
                {
                    if (individualPerson.MemberInformation.MemberInformationToMemberships != null && individualPerson.MemberInformation.MemberInformationToMemberships.Any())
                    {
                        DeleteMemberInformationToMemberships(individualPerson.MemberInformation.MemberInformationToMemberships.Select(m => m.UID).ToList());
                    }

                    DeleteMemberInformation(individualPerson.MemberInformationUID.Value);
                }

                DeleteAdress(individualPerson.AdressUID);
            }
            catch (DataException e)
            {
                throw new Exception("Internal Server Error", e);
            }
            catch(Exception)
            {
                throw new Exception("Internal Server Error");
            }

            try
            {
                _uow.Commit();
            }
            catch (DataException e)
            {
                throw new Exception("Internal Server Error during Saving changes", e);
            }
            catch (Exception)
            {
                throw new Exception("Internal Server Error during Saving changes");
            }
        }

        private void DeletePhones(List<Guid> uids)
        {
            foreach (var uid in uids)
            {
                _uow.PhoneRepository.Delete(uid);
            }
        }

        private void DeleteEmails(List<Guid> uids)
        {
            foreach (var uid in uids)
            {
                _uow.EmailRepository.Delete(uid);
            }
        }

        private void DeletePersonToMandators(List<Guid> uids)
        {
            foreach (var uid in uids)
            {
                _uow.PersonToMandatorRepository.Delete(uid);
            }
        }

        private void DeleteSessions(List<Guid> uids)
        {
            foreach (var uid in uids)
            {
                _uow.SessionRepository.Delete(uid);
            }
        }

        private void DeleteMemberInformationToMemberships(List<Guid> uids)
        {
            foreach (var uid in uids)
            {
                _uow.MemberInformationToMembershipRepository.Delete(uid);
            }
        }

        private void DeleteAdress(Guid uid)
        {
            var adress = _uow.AdressRepository.Get(uid);

            if (adress.IndividualPersons.Count == 0)
            {
                _uow.AdressRepository.Delete(uid);
            }
        }

        private void DeleteMemberInformation(Guid uid)
        {
            var memberinformation = _uow.MemberInformationRepository.Get(uid);

            if(memberinformation.IndividualPersons.Count == 0)
            {
                _uow.MemberInformationRepository.Delete(uid);
            }
        }
    }
}