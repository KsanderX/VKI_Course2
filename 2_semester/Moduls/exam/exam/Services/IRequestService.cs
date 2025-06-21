using exam.Models;

namespace exam.Services
{
    public interface IRequestService
    {
        public List<User> GetAllUsers();
        public void AddRequest(Request request);
    }
}
