using Microsoft.Practices.Unity;
using OrgMan.Data.UnitOfWork;
using OrgMan.Domain.Handler.HandlerBase;
using OrgMan.DomainContracts.Meeting;
using System;
using System.Data;
using System.Linq;

namespace OrgMan.Domain.Handler.Meeting
{
    public class InsertMeetingQueryHandler : QueryHandlerBase
    {
        private readonly InsertMeetingQuery _query;
        private readonly OrgManUnitOfWork _uow;

        public InsertMeetingQueryHandler(InsertMeetingQuery query, IUnityContainer unityContainer) : base(unityContainer)
        {
            _query = query;
            _uow = new OrgManUnitOfWork();
        }

        public Guid Handle()
        {
            try
            {
                DataModel.Meeting meeting = AutoMapper.Mapper.Map<DataModel.Meeting>(_query.MeetingDetailDomainModel);

                if(meeting == null)
                {
                    throw new DataException("Could not Map MeetingDetailDomainModel to Meeting");
                }

                if (_query.MandatorUIDs.Intersect(meeting.MandatorUIDs).Any())
                {
                    Guid meetingUid = Guid.NewGuid();
                    meeting.UID = meetingUid;

                    _uow.MeetingRepository.Insert(meeting);
                    _uow.Commit();

                    return meeting.UID;
                }

                throw new UnauthorizedAccessException("Meeting from another mandator");
            }
            catch (UnauthorizedAccessException)
            {
                throw new Exception("Not Authorized to Create the Entity");
            }
            catch (InvalidOperationException)
            {
                throw new Exception("Internal Server Error thrown during create process");
            }
            catch (DataException e)
            {
                throw new Exception("Internal Server Error", e);
            }
            catch (Exception)
            {
                throw new Exception("Internal Server Error");
            }
        }
    }
}
