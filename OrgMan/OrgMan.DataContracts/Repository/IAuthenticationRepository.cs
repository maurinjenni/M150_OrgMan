using System;

namespace OrgMan.DataContracts.Repository
{
    public interface IAuthenticationRepository
    {
        Guid Login(string username, string password);
    }
}
