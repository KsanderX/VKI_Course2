using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wedding_Agency.Services
{
    public interface IAuthorizationService
    {
        public bool Authorization(string login, string password);
    }
}
