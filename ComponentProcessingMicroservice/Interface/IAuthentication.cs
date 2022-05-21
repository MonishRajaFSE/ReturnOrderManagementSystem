using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComponentProcessingMicroservice.Interface
{
    public interface IAuthentication
    {
        public bool ValidateUser(string email, string password);
    }
}
