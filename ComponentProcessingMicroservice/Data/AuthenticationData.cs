using ComponentProcessingMicroservice.DBContexts;
using ComponentProcessingMicroservice.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComponentProcessingMicroservice.Data
{
    public class AuthenticationData : IAuthentication
    {
        public DBContext _userContext;
        public AuthenticationData()
        {
            _userContext = new DBContext();
        }
        public bool ValidateUser(string email, string password)
        {
            try
            {
                var user = _userContext.Users.Where(c => c.Email == email && c.Password == password).FirstOrDefault();
                if (user == null)
                {

                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
