using System.Collections.ObjectModel;
using exam.Models;

namespace exam.Services
{
    public interface ICarService
    {
        public List<User> GetAllUsers();
        public void AddCar(Car car);
        public ObservableCollection<Car> GetAllCars();
        public void RemoveCar(Car car);
        public void Save(Car car);
        public List<Car> GetCarCurrentUser(User user);
    }
}
