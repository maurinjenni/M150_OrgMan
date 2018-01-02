using AutoMapper;
using Microsoft.Practices.Unity;
using OrgMan.Data.UnitOfWork;
using OrgMan.Domain.Handler.HandlerBase;
using OrgMan.DomainContracts.Meeting;
using OrgMan.DomainObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.Domain.Handler.Meeting
{
    public class UpdateMeetingQueryHandler : QueryHandlerBase
    {
        private UpdateMeetingQuery _query;

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

                uow.MeetingRepository.Update(meeting);

                uow.Commit();

                return Mapper.Map<MeetingDetailDomainModel>(meeting);
            }
            catch (InvalidOperationException e)
            {
                throw new Exception("Internal Server Error thrown during update process");
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
