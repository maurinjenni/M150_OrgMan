using System;
using System.Collections.Generic;
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
    public class GetAllMembershipsQueryHandler : QueryHandlerBase
    {
        public GetAllMembershipsQuery _query;

        public GetAllMembershipsQueryHandler(GetAllMembershipsQuery query, IUnityContainer unityContainer)
            : base(unityContainer)
        {
            _query = query;
        }

        public List<MembershipDomainModel> Handle()
        {
            OrgManUnitOfWork uow = new OrgManUnitOfWork();

            return AutoMapper.Mapper.Map<List<MembershipDomainModel>>(uow.MembershipRepository.Get(_query.MandatorUIDs,null,null,null,null));
        }
    }
}
