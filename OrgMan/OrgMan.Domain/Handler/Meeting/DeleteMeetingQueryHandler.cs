using Microsoft.Practices.Unity;
using OrgMan.Data.UnitOfWork;
using OrgMan.Domain.Handler.HandlerBase;
using OrgMan.DomainContracts.Meeting;
using System;
using System.Data;
using System.Linq;

namespace OrgMan.Domain.Handler.Meeting
{
    public class DeleteMeetingQueryHandler : QueryHandlerBase
    {
        private readonly DeleteMeetingQuery _query;
        private readonly OrgManUnitOfWork _uow;

        public DeleteMeetingQueryHandler(DeleteMeetingQuery query, IUnityContainer unityContainer) : base(unityContainer)
        {
            _query = query;
            _uow = new OrgManUnitOfWork();
        }

        public void Handle()
        {
            try
            {
                DataModel.Meeting meeting = _uow.MeetingRepository.Get(_query.MeetingUID);

                if (meeting == null)
                {
                    throw new DataException("No Entity found to UID : " + _query.MeetingUID);
                }

                if (!_query.MandatorUIDs.Intersect(meeting.MandatorUIDs).Any())
                {
                    throw new UnauthorizedAccessException("Meeting from another mandator");
                }

                _uow.MeetingRepository.Delete(_query.MeetingUID);
                _uow.Commit();
            }
            catch (UnauthorizedAccessException)
            {
                throw new Exception("Not Authorized to Delete the Entity");
            }
            catch (DataException e)
            {
                throw new Exception("Internal Server Error during Saving Changes", e);
            }
            catch(Exception)
            {
                throw new Exception("Internal Server Error during Saving Changes");
            }
        }
    }
}
