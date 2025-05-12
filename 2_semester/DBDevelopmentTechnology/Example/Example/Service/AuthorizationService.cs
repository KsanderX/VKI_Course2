using Example.DataBase;

namespace Example.Service
{

    public class AuthorizationService : IAuthorizationService
    {
        private ProductsContext _context;
        private Client _currentClient;
        public AuthorizationService()
        {
            _context = new ProductsContext();
        }
        public bool Authorization(string login, string password)
        {
            Client client = _context.Clients.Where(c => c.Login == login && c.Password == password).FirstOrDefault(); // возвращает одного клиента FirstOrDefault()

            if (client != null)
            {
                _currentClient = client;
                return true;
            }
            else
            {
                return false;
            }
        }

        public Client GetCurrentClient()
        {
            return _currentClient;
        }
    }
}
