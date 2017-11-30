using Microsoft.Practices.Unity;

namespace OrgMan.Dependencies
{
    public interface IDependencyRegistration
    {
        void Load(IUnityContainer unityContainer);
    }
}
