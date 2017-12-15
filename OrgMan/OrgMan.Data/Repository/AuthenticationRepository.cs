using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using OrgMan.DataContracts.Repository;
using OrgMan.DataModel;

namespace OrgMan.Data.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private OrgManEntities _context;

        public AuthenticationRepository(OrgManEntities context = null)
        {
            _context = context ?? new OrgManEntities();
        }

        public Guid Login(string username, string password)
        {

            if (!_context.Logins.Any() || _context.Logins.FirstOrDefault(l => l.Username == username) == null)
            {
                throw new Exception("Invalid Userinformation");
            }

            Login logindata = _context.Logins.FirstOrDefault(l => l.Username == username);
            
            byte[] saltBytes = Encoding.UTF8.GetBytes(logindata.Salt);

            var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 1000);

            string pwdString = Convert.ToBase64String(pbkdf2.GetBytes(256));
            if (logindata.PasswordHash == pwdString)
            {
                return logindata.PersonUID;
            }

            throw new Exception("Invalid Userinformation");
        }
    }
}