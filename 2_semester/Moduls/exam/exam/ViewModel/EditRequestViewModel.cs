using exam.Models;
using exam.Services;

namespace exam.ViewModel
{
    public class EditRequestViewModel
    {
        private IRequestService _requestService;
        public Request SelectedRequest { get; set; }
        public List<User> Users { get; set; }

        public EditRequestViewModel(IRequestService request)
        {
            _requestService = request;
            Users = _requestService.GetAllUsers();
        }
    }
}
