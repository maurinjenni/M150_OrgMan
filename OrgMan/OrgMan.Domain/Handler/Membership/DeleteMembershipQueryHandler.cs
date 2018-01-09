using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using OrgMan.Data.UnitOfWork;
using OrgMan.Domain.Handler.HandlerBase;
using OrgMan.DomainContracts.Membership;

namespace OrgMan.Domain.Handler.Membership
{
    public class DeleteMembershipQueryHandler : QueryHandlerBase
    {
        private DeleteMembershipQuery _query;

        public DeleteMembershipQueryHandler(DeleteMembershipQuery query, IUnityContainer unityContainer)
            : base(unityContainer)
        {
            _query = query;
        }

        public void Handle()
        {

            OrgManUnitOfWork uow = new OrgManUnitOfWork();

            try
            {
                var membership = uow.MembershipRepository.Get(_query.MembershipUID);

                if (membership == null)
                {
                    throw new DataException("No Entity found to UID : " + _query.MembershipUID);
                }

                if (_query.MandatorUIDs.Intersect(membership.MandatorUIDs).Any())
                {
                    if (membership.MemberInformationToMemberships != null &&
                        membership.MemberInformationToMemberships.Any())
                    {
                        throw new DataException(
                            string.Format(
                                "Could not remove Membership, because it is beeing used by {0} MemberInformationToMemberships",
                                membership.MemberInformationToMemberships.Count));
                    }

                    uow.MembershipRepository.Delete(_query.MembershipUID);
                }
                else
                {
                    throw new UnauthorizedAccessException("Membership from another Mandator");
                }
            }
            catch (DataException e)
            {
                throw new DataException("Internal Server Error during deleting Membership", e);
            }
            catch (UnauthorizedAccessException e)
            {
                throw new DataException("Internal Server Error during deleting Membership", e);
            }
            catch (Exception)
            {
                throw new Exception("Internal Server Error during deleting Membership");
            }

            try
            {
                uow.Commit();
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
    }
}

