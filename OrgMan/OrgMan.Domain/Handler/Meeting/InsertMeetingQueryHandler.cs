using Microsoft.Practices.Unity;
using OrgMan.Data.UnitOfWork;
using OrgMan.Domain.Handler.HandlerBase;
using OrgMan.DomainContracts.Meeting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.Domain.Handler.Meeting
{
    public class InsertMeetingQueryHandler : QueryHandlerBase
    {
        private InsertMeetingQuery _query;
        private OrgManUnitOfWork _uow;

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

                Guid meetingUid = Guid.NewGuid();
                meeting.UID = meetingUid;

                _uow.MeetingRepository.Insert(meeting);
                _uow.Commit();

                return meeting.UID;
            }

            catch (DataException e)
            {
                throw new Exception("Internal Server Error", e);
            }
            catch (Exception e)
            {
                throw new Exception("Internal Server Error");
            }
        }
    }
}
