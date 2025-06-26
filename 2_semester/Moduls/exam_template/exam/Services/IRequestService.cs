using System.Collections.ObjectModel;
using exam.Models;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace exam.Services
{
    public interface IRequestService
    {
        public List<User> GetAllUsers();
        public void AddRequest(Request request);
        public ObservableCollection<Request> GetAllRequests();
        public void RemoveRequest(Request request);
        public void Save(Request request);
        public List<Request> GetRequestCurrentUser(User user);
    }
}
