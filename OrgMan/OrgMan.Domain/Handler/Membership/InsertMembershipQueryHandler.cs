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
    public class InsertMembershipQueryHandler : QueryHandlerBase
    {
        private InsertMembershipQuery _query;

        public InsertMembershipQueryHandler(InsertMembershipQuery query, IUnityContainer unityContainer)
            : base(unityContainer)
        {
            _query = query;
        }

        public Guid Handle()
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
                    membership.UID = Guid.NewGuid();

                    uow.MembershipRepository.Insert(membership);

                    uow.Commit();

                    return membership.UID;
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
