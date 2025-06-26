using System.Collections.ObjectModel;
using exam.Models;
using exam.Services;

namespace exam.ViewModel
{
    public class CarAdminViewModel 
    {
        private ICarService _carService;
        public ObservableCollection<Car> Cars { get; set; }       
        public Car SelectedCar { get; set; }    
        
        public CarAdminViewModel(ICarService service)
        {
            _carService = service;
            Cars = _carService.GetAllCars();
        }

        public void UpdateCollection()
        {
            Cars = _carService.GetAllCars();
        }
    }
}