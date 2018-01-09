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
    public class UpdateMembershipQueryHandler : QueryHandlerBase
    {
        private UpdateMembershipQuery _query;

        public UpdateMembershipQueryHandler(UpdateMembershipQuery query, IUnityContainer unityContainer)
            : base(unityContainer)
        {
            _query = query;
        }

        public DataModel.Membership Handle()
        {
            OrgManUnitOfWork uow = new OrgManUnitOfWork();

            try
            {
                var membership = AutoMapper.Mapper.Map<DataModel.Membership>(_query.MembershipDomainModel);

                if (membership == null)
                {
                    throw new DataException("Could not Map AdressManagementDetailDomainModel to IndividualPerson");
                }

                if (_query.MandatorUIDs.Intersect(membership.MandatorUIDs).Any())
                {
                    uow.MembershipRepository.Update(membership);

                    uow.Commit();

                    return membership;
                }
                else
                {
                    throw new UnauthorizedAccessException("Membership from another Mandator");
                }
            }
            catch (DataException e)
            {
                throw new DataException("Internal Server Error during Inserting changes", e);
            }
            catch (UnauthorizedAccessException e)
            {
                throw new UnauthorizedAccessException("Internal Server Error during Inserting changes", e);
            }
            catch (Exception)
            {
                throw new Exception("Internal Server Error during Inserting changes");
            }
        }
    }
}
