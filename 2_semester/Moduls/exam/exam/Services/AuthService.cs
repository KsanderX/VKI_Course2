using System.Windows;
using exam.Models;
using Microsoft.EntityFrameworkCore;

namespace exam.Services
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

        public void Register(string name, string login, string password)
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
                    Name = name,
                    Login = login,
                    Password = password,
                    RoleId = 2
                };
                _context.Users.Add(newUser);
                _context.SaveChanges();
            }                 
        }
    }
}