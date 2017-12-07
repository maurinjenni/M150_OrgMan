using Microsoft.Practices.Unity;
using OrgMan.Common.LinqExpressionService;
using OrgMan.DataModel;
namespace OrgMan.Dependencies.Registration
{
    public class OrgManDependencyRegistration : IDependencyRegistration
    {

        public OrgManDependencyRegistration()
        {
        }

        public void Load(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<LinqExpressionService<Person>>(new InjectionConstructor());

            unityContainer.RegisterType<ILinqExpressionService<Person>, LinqExpressionService<Person>>(new InjectionConstructor());
            /*LinqExpressionService*/
            //unityContainer.RegisterType<ILinqExpressionService<Person>, LinqExpressionService<Person>>();
        }
    }
}
