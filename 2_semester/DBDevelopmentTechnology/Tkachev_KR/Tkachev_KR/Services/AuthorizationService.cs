using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tkachev_KR.DataBase;

namespace Tkachev_KR.Services
{
    public class AuthorizationService : IAuthorization
    {
        private TkachevContext _context;
        private Customer _customer;
        public AuthorizationService()
        {
            _context = new TkachevContext();
            _customer = null!;
        }
        public bool Authorization(string email, string password)
        {
            Customer? customer = _context.Customers
                .Where(c => c.Email == email && c.Pasword == password)
                .FirstOrDefault();

            if (customer != null)
            {
                _customer = customer;
                return true;
            }
            else
            {
                return false;
            }
        }

        public Customer GetCurrentCustomer()
        {
           return _customer;
        }
    }
}
