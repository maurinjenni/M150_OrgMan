using AutoMapper;
using Microsoft.Practices.Unity;
using OrgMan.Data.UnitOfWork;
using OrgMan.Domain.Handler.HandlerBase;
using OrgMan.DomainContracts.Meeting;
using OrgMan.DomainObjects;
using System;
using System.Data;
using System.Linq;

namespace OrgMan.Domain.Handler.Meeting
{
    public class UpdateMeetingQueryHandler : QueryHandlerBase
    {
        private readonly UpdateMeetingQuery _query;

        public UpdateMeetingQueryHandler(UpdateMeetingQuery query, IUnityContainer unityContainer) : base(unityContainer)
        {
            _query = query;
        }

        public MeetingDetailDomainModel Handle()
        {
            try
            {
                OrgManUnitOfWork uow = new OrgManUnitOfWork();

                var meeting = Mapper.Map<DataModel.Meeting>(_query.MeetingDetailDomainModel);

                if (_query.MandatorUIDs.Intersect(meeting.MandatorUIDs).Any())
                {
                    uow.MeetingRepository.Update(meeting);

                    uow.Commit();

                    return Mapper.Map<MeetingDetailDomainModel>(meeting);
                }

                throw new UnauthorizedAccessException("Meeting from another mandator");
            }
            catch (UnauthorizedAccessException)
            {
                throw new UnauthorizedAccessException("Not Authorized to Update the Entity");
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("Internal Server Error thrown during update process");
            }
            catch (DataException e)
            {
                throw new DataException("Internal Server Error", e);
            }
            catch (Exception)
            {
                throw new Exception("Internal Server Error");
            }
        }
    }
}
