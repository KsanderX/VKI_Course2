using exam.Models;

namespace exam.Services
{
    public interface IAuthService
    {
        public bool Auth(string login, string password);
        public void Register(string name, string login, string password);
        bool LoginExists(string login);
        public User CurrentUser { get; set; }
    }
}
