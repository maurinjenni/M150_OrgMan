using System;
using AutoMapper;
using Microsoft.Practices.Unity;
using OrgMan.Data.UnitOfWork;
using OrgMan.Domain.Handler.HandlerBase;
using OrgMan.DomainContracts.Adress;
using OrgMan.DomainObjects.Adress;
using System.Data;
using OrgMan.DomainObjects.Common;
using System.Collections.Generic;
using OrgMan.DataModel;

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

                Guid newMemberInformationUID = Guid.Empty;

                if (_query.AdressManagementDetailDomainModel.MemberInformation != null && _query.AdressManagementDetailDomainModel.MemberInformation.UID == null || _query.AdressManagementDetailDomainModel.MemberInformation.UID == Guid.Empty)
                {
                    newMemberInformationUID = Guid.NewGuid();
                    _query.AdressManagementDetailDomainModel.MemberInformation.UID = newMemberInformationUID;
                }

                if(_query.AdressManagementDetailDomainModel.MemberInformation != null && _query.AdressManagementDetailDomainModel.MemberInformation.MemberInformationToMemberships != null)
                {
                    foreach (var memberInformationToMembership in _query.AdressManagementDetailDomainModel.MemberInformation.MemberInformationToMemberships)
                    {
                        if (memberInformationToMembership.UID == null || memberInformationToMembership.UID == Guid.Empty)
                        {
                            Guid newUid = Guid.NewGuid();
                            memberInformationToMembership.UID = newUid;
                        }

                        if(memberInformationToMembership.Membership == null)
                        {
                            memberInformationToMembership.Membership = Mapper.Map<MembershipDomainModel>(uow.MembershipRepository.Get(_query.MandatorUIDs, memberInformationToMembership.MembershipUID));
                        }
                    }
                }
                
                if(_query.AdressManagementDetailDomainModel.Phones != null)
                {
                    foreach (var phone in _query.AdressManagementDetailDomainModel.Phones)
                    {
                        if (phone.UID == null || phone.UID == Guid.Empty)
                        {
                            phone.UID = Guid.NewGuid();
                            phone.IndividualPersonUID = _query.AdressManagementDetailDomainModel.UID;
                        }
                    }
                }

                if(_query.AdressManagementDetailDomainModel.Person.PersonToMandators != null)
                {
                    foreach (var personToMandator in _query.AdressManagementDetailDomainModel.Person.PersonToMandators)
                    {
                        personToMandator.PersonUID = _query.AdressManagementDetailDomainModel.Person.UID;
                        personToMandator.UID = Guid.NewGuid();
                    }
                }

                if (_query.AdressManagementDetailDomainModel.Emails != null)
                {
                    foreach (var email in _query.AdressManagementDetailDomainModel.Emails)
                    {
                        if (email.UID == null || email.UID == Guid.Empty)
                        {
                            email.UID = Guid.NewGuid();
                            email.IndividualPersonUID = _query.AdressManagementDetailDomainModel.UID;
                        }
                    }
                }

                var individualPerson = Mapper.Map<DataModel.IndividualPerson>(_query.AdressManagementDetailDomainModel);

                uow.IndividualPersonRepository.Update(_query.MandatorUIDs, individualPerson);
                uow.MemberInformationRepository.Update(_query.MandatorUIDs,individualPerson.MemberInformation);
                uow.PersonRepository.Update(_query.MandatorUIDs, individualPerson.Person);
                uow.AdressRepository.Update(_query.MandatorUIDs, individualPerson.Adress);

                if(individualPerson.Phones != null)
                {
                    foreach (var phone in individualPerson.Phones)
                    {
                        uow.PhoneRepository.Update(_query.MandatorUIDs, phone);
                    }
                }

                if(individualPerson.Emails != null)
                {
                    foreach (var email in individualPerson.Emails)
                    {
                        uow.EmailRepository.Update(_query.MandatorUIDs, email);
                    }
                }

                uow.Commit();

                foreach (var membership in individualPerson.MemberInformation.MemberInformationToMemberships)
                {
                    var membershipTest = uow.MemberInformationToMembershipRepository.Get(membership.UID);

                    if(membershipTest == null)
                    {
                        uow.MemberInformationToMembershipRepository.Insert(membership);
                    }else
                    {
                        uow.MemberInformationToMembershipRepository.Update(membership);
                    }
                }

                uow.Commit();
                
                return Mapper.Map<AdressManagementDetailDomainModel>(uow.IndividualPersonRepository.Get(_query.AdressManagementDetailDomainModel.UID));
            }
            catch(InvalidOperationException e)
            {
                throw new Exception("Internal Server Error thrown during update process", e);
            }
            catch (DataException e)
            {
                throw new Exception("Internal Server Error", e);
            }
            catch (Exception e)
            {
                
                throw new Exception("Internal Server Error", e);
            }
        }
    }
}
