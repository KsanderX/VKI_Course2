using exam.Models;
using exam.Services;

namespace exam.ViewModel
{
    public class UserViewModel
    {
        private IAuthService _authService;
        private IRequestService _requestService;
       public List<Request> Requests { get; set; }
        public UserViewModel(IRequestService service, IAuthService authService)
        {
            _requestService = service;
            _authService = authService;
            Requests = _requestService.GetRequestCurrentUser(_authService.CurrentUser);
        }
    }
}