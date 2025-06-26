using exam.Models;
using exam.Services;

namespace exam.ViewModel
{
    public class AdminViewModel
    {
        private readonly ICarService _carService;
        public string VIN {  get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public List<User> Users { get; set; }
        public User SelectedUser { get; set; }
        public AdminViewModel(ICarService cars)
        {
            _carService = cars;
            Users = _carService.GetAllUsers();
        }
    }
}
