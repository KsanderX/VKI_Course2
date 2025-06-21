using exam.Models;

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

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
    }
}
