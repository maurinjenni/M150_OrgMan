using AutoMapper;
using Microsoft.Practices.Unity;
using OrgMan.Data.UnitOfWork;
using OrgMan.Domain.Handler.HandlerBase;
using OrgMan.DomainContracts.Meeting;
using OrgMan.DomainObjects;
using System.Linq;

namespace OrgMan.Domain.Handler.Meeting
{
    public class GetMeetingQueryHandler : QueryHandlerBase
    {
        private readonly GetMeetingQuery _query;

        public GetMeetingQueryHandler(GetMeetingQuery query, IUnityContainer unityContainer) : base(unityContainer)
        {
            _query = query;
        }

        public MeetingDetailDomainModel Handle()
        {
            OrgManUnitOfWork uow = new OrgManUnitOfWork();

            var meeting = uow.MeetingRepository.Get(_query.MandatorUIDs, _query.MeetingUID);

            if (_query.MandatorUIDs.Intersect(meeting.MandatorUIDs).Any())
            {
                return Mapper.Map<MeetingDetailDomainModel>(meeting);
            }

            return null;
        }
    }
}
