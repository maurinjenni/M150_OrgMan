﻿using Microsoft.Practices.Unity;

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
