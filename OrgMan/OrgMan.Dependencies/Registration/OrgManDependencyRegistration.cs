using Microsoft.Practices.Unity;
using OrgMan.Common.DynamicValidationService;
using OrgMan.Common.DynamicValidationService.Validators;
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
            /*LinqExpressionService*/
            unityContainer.RegisterType<ILinqExpressionService<Person>, LinqExpressionService<Person>>();
        }
    }
}
