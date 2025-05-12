using Example.DataBase;

namespace Example.Service
{
    public interface IAuthorizationService
    {
        public bool Authorization(string login, string password);
        public Client GetCurrentClient();
    }
}
