using System.Windows;
using exam.Models;
using exam.Services;
using exam.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace exam.Views
{
    /// <summary>
    /// Логика взаимодействия для AdminView.xaml
    /// </summary>
    public partial class AdminView : Window
    {
        private IServiceProvider _service;
        private ICarService _carService;
        public AdminView(IServiceProvider service, ICarService carService)
        {
            InitializeComponent();
            _service = service;
            _carService = carService;
            this.DataContext = _service.GetRequiredService<AdminViewModel>();
        }

        private void btnAddCar_Click(object sender, RoutedEventArgs e)
        {
            var myAdminViewModel = this.DataContext as AdminViewModel;

            string vin = myAdminViewModel.VIN;
            string name = myAdminViewModel.Name;
            string type = myAdminViewModel.Type;
            string description = myAdminViewModel.Description;
            User user = myAdminViewModel.SelectedUser;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description) || user == null)
            {
                MessageBox.Show("Заполните поля!");
            }
            else
            {
                Car car = new Car()
                {
                    VIN = vin,
                    Name = name,
                    Type = type,
                    Description = description,
                    UserId = user.Id,
                    Status = CarStatus.InStock                    
                };
                _carService.AddCar(car);
                MessageBox.Show("Заявка добавлена!");
                var questsView = _service.GetRequiredService<CarAdminView>();
                this.Close();
                questsView.ShowDialog();
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            var back = _service.GetRequiredService<CarAdminView>();
            this.Close();
            back.ShowDialog();
        }
    }
}
