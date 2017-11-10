using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace OrgMan.Dependencies
{
    public static class DependencyManager
    {
        public static void RegisterDependency(IUnityContainer unityContainer, IDependencyRegistration dependencyRegistration)
        {
            dependencyRegistration.Load(unityContainer);
        }
    }
}
