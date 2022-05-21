using ComponentProcessingMicroservice.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComponentProcessingMicroservice.Services
{
    public class LoginService
    {
        private readonly IAuthentication _iAuthentication;
        public LoginService(IAuthentication iAuthentication)
        {
            _iAuthentication = iAuthentication;
        }

        public bool ValidateUser(string email, string password)
        {
            try
            {
                return _iAuthentication.ValidateUser(email, password);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
