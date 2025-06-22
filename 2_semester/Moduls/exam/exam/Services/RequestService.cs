using System.Collections.ObjectModel;
using exam.Models;
using Microsoft.EntityFrameworkCore;

namespace exam.Services
{
    public class RequestService : IRequestService
    {
        private AppDbContext _context;
        public RequestService()
        {
            _context = new AppDbContext();
        }

        public void AddRequest(Request request)
        {
            _context.Requests.Add(request);
            _context.SaveChanges();
        }

        public ObservableCollection<Request> GetAllRequests()
        {
            return new (_context.Requests.Include(u => u.User).ToList());
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public List<Request> GetRequestCurrentUser(User user)
        {
           return _context.Requests.Where(u => u.UserId == user.Id).Include(u => u.User).ToList();
        }

        public void RemoveRequest(Request request)
        {
            _context.Requests.Remove(request);
            _context.SaveChanges();
        }

        public void Save(Request request)
        {
            _context.Requests.Update(request);
            _context.SaveChanges();
        }
    }
}
