using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.DomainContracts.Authentication
{
    public class LoginQuery
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
