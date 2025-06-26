using exam.Models;
using exam.Services;

namespace exam.ViewModel
{
    public class AdminViewModel
    {
        private readonly IRequestService _requestService;
        public string Name { get; set; }
        public string Description { get; set; }
        public List<User> Users { get; set; }
        public User SelectedUser { get; set; }
        public AdminViewModel(IRequestService request)
        {
            _requestService = request;
            Users = _requestService.GetAllUsers();
        }
    }
}
