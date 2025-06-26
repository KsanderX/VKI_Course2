using Examination.Models;

namespace Examination.Services
{
    public interface IAuthService
    {
        public bool Auth(string login, string password);
        public void Register(string surname, string name, string phoneNumber, string login, string password);
        bool LoginExists(string login);
        public User CurrentUser { get; set; }
    }
}
