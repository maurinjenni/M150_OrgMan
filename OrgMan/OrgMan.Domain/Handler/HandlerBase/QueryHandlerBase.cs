using Microsoft.Practices.Unity;

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
