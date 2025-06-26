using System.Windows;
using Examination.Models;

namespace Examination.Services
{
    public class AuthService : IAuthService
    {
        private AppDbContext _context;
        public User CurrentUser { get; set; }
        public AuthService()
        {
            _context = new AppDbContext();
        }
        public bool Auth(string login, string password)
        {
            User user = _context.Users.Where(u => u.Login == login && u.Password == password).FirstOrDefault();
            if (user != null)
            {
                CurrentUser = user;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Register(string surname, string name, string phoneNumber, string login, string password)
        {
            User user = _context.Users.Where(u => u.Login == login).FirstOrDefault();
            if (user != null)
            {
                MessageBox.Show("Пользователь с таким логином уже существует");
            }
            else
            {
                User newUser = new User()
                {
                    Login = login,
                    Password = password,
                    Name = name,
                    Surname = surname,
                    Phone = phoneNumber,
                    RoleId = 2
                };
                _context.Users.Add(newUser);
                _context.SaveChanges();
            }
        }

        public bool LoginExists(string login)
        {
            return _context.Users.Any(l => l.Login == login);
        }
    }
}
