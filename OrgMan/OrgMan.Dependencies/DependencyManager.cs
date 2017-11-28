using System.Collections.Generic;
using Microsoft.Practices.Unity;

namespace OrgMan.Dependencies
{
    public static class DependencyManager
    {
        public static void RegisterDependency(IUnityContainer unityContainer, List<IDependencyRegistration> dependencyRegistrations)
        {
            foreach (var dependencyRegistration in dependencyRegistrations)
            {
                dependencyRegistration.Load(unityContainer);
            }
        }
    }
}
