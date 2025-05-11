using Example.DataBase;

namespace Example.Service
{
    public interface IAuthorizationService
    {
        public bool Authrozation(string login, string password);
        public Client GetCurrentClient();
    }
}
