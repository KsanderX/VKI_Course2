using exam.Models;
using exam.Services;

namespace exam.ViewModel
{
    public class UserViewModel
    {
        private IAuthService _authService;
        private ICarService _carService;
       public List<Car> Cars { get; set; }
        public UserViewModel(ICarService service, IAuthService authService)
        {
            _carService = service;
            _authService = authService;
            Cars = _carService.GetCarCurrentUser(_authService.CurrentUser);
        }
    }
}