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
    public class DeleteMeetingQueryHandler : QueryHandlerBase
    {
        private DeleteMeetingQuery _query;
        private OrgManUnitOfWork _uow;

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

                _uow.MeetingRepository.Delete(_query.MeetingUID);
                _uow.Commit();
            }
            catch (DataException e)
            {
                throw new Exception("Internal Server Error during Saving Changes", e);
            }
            catch(Exception e)
            {
                throw new Exception("Internal Server Error during Saving Changes");
            }
        }
    }
}
