using Microsoft.Practices.Unity;
using OrgMan.DataModel;
using System;

namespace OrgMan.Domain.Handler.HandlerBase
{
    public class QueryHandlerBase
    {
        private IUnityContainer _unityContainer;

        public QueryHandlerBase(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }
    }
}


//IDictionary<Type, Delegate> typeofProcessMap = new Dictionary<Type, Delegate>
//            {
//                {typeof(Person), new Action<Person>(p =>
//                    {
//                        Person person = (Person)(object)obj;
//                        PersonValidator personValidator = new PersonValidator(_unityContainer.Resolve<ILinqExpressionService<Person>>());
//                        personValidator.Validate(person);
//                    })
//                },
//                {typeof(Meeting), new Action<Meeting>(m =>
//                    {
//                        Meeting meeting = (Meeting)(object)obj;
//                        MeetingValidator meetingValidator = new MeetingValidator (_unityContainer.Resolve<ILinqExpressionService<Meeting>>());
//                        meetingValidator.Validate(meeting);
//                    })
//                }
//            };

//typeofProcessMap[typeof(T)].DynamicInvoke(obj);