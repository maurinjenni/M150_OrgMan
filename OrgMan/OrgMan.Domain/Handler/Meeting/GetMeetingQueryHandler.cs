using AutoMapper;
using Microsoft.Practices.Unity;
using OrgMan.Data.UnitOfWork;
using OrgMan.Domain.Handler.HandlerBase;
using OrgMan.DomainContracts.Meeting;
using OrgMan.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.Domain.Handler.Meeting
{
    public class GetMeetingQueryHandler : QueryHandlerBase
    {
        private GetMeetingQuery _query;

        public GetMeetingQueryHandler(GetMeetingQuery query, IUnityContainer unityContainer) : base(unityContainer)
        {
            _query = query;
        }

        public MeetingDetailDomainModel Handle()
        {
            OrgManUnitOfWork uow = new OrgManUnitOfWork();

            var meeting = uow.MeetingRepository.Get(_query.MeetingUID);

            if (_query.MandatorUIDs.Intersect(meeting.MandatorUIDs).Any())
            {
                return Mapper.Map<MeetingDetailDomainModel>(meeting);
            }

            return null;
        }
    }
}
