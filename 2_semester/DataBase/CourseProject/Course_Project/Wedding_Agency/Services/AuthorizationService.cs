using Wedding_Agency.Models;

namespace Wedding_Agency.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        public WeddingAgencyContext _context;
        private AgencyEmployee _employee;
        public AuthorizationService()
        {
            _context = new WeddingAgencyContext();
            _employee = null!; 
        }
        public bool Authorization(string login, string password)
        {
            AgencyEmployee? employee = _context.AgencyEmployees
                .Where(l => l.Login == login && l.Password == password).FirstOrDefault();
            if(employee != null)
            {
                _employee = employee;
                return true; 
            }
            else
            {
                _employee = null!; 
                return false; 
            }
        }
    }
}
