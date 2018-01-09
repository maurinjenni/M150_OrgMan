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
using OrgMan.DomainObjects.Common;

namespace OrgMan.Domain.Handler.Membership
{
    public class GetMembershipQueryHandler : QueryHandlerBase
    {
        private GetMembershipQuery _query;

        public GetMembershipQueryHandler(GetMembershipQuery query, IUnityContainer unityContainer)
            : base(unityContainer)
        {
            _query = query;
        }

        public MembershipDomainModel Handle()
        {
            OrgManUnitOfWork uow = new OrgManUnitOfWork();

            try
            {
                var membership = uow.MembershipRepository.Get(_query.MembershipUID);

                if (membership == null)
                {
                    throw new DataException("No Entity found to UID : " + _query.MembershipUID);
                }

                if (membership.MandatorUIDs.Intersect(_query.MandatorUIDs).Any())
                {
                    return AutoMapper.Mapper.Map<MembershipDomainModel>(membership);
                }
                else
                {
                    throw new UnauthorizedAccessException("Membership from another Mandator");
                }
            }
            catch (DataException e)
            {
                throw new DataException("Internal Server Error during loading Membership", e);
            }
            catch (UnauthorizedAccessException e)
            {
                throw new UnauthorizedAccessException("Internal Server Error during loading Membership", e);
            }
            catch (Exception)
            {
                throw new Exception("Internal Server Error during Saving changes");
            }
        }
    }
}
