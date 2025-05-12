using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tkachev_KR.DataBase;

namespace Tkachev_KR.Services
{
    public  interface IAuthorization
    {
        public bool Authorization(string email, string password);
        public Customer GetCurrentCustomer();
    }
}
