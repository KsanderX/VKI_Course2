using exam.Models;
using exam.Services;

namespace exam.ViewModel
{
    public class EditCarViewModel
    {
        private ICarService _carService;
        public Car SelectedCar { get; set; }
        public List<User> Users { get; set; }

        public EditCarViewModel(ICarService car)
        {
            _carService = car;
            Users = _carService.GetAllUsers();
        }
    }
}
