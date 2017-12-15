using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrgMan.DataModel;

namespace OrgMan.DataContracts.Repository
{
    public interface IAuthenticationRepository
    {
        Guid Login(string username, string password);
    }
}
