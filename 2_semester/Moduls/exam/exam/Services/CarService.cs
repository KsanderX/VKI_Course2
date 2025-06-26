using System.Collections.ObjectModel;
using exam.Models;
using Microsoft.EntityFrameworkCore;

namespace exam.Services
{
    public class CarService : ICarService
    {
        private AppDbContext _context;
        public CarService()
        {
            _context = new AppDbContext();
        }

        public void AddCar(Car car)
        {
            _context.Car.Add(car);
            _context.SaveChanges();
        }

        public ObservableCollection<Car> GetAllCars()
        {
            return new (_context.Car.Include(u => u.User).ToList());
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public List<Car> GetCarCurrentUser(User user)
        {
           return _context.Car.Where(u => u.UserId == user.Id).Include(u => u.User).ToList();
        }

        public void RemoveCar(Car car)
        {
            _context.Car.Remove(car);
            _context.SaveChanges();
        }

        public void Save(Car car)
        {
            _context.Car.Update(car);
            _context.SaveChanges();
        }
    }
}
