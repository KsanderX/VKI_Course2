using System.Windows;
using exam.Models;
using exam.Services;
using exam.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace exam.Views
{
    public partial class CarAdminView : Window
    {
        private IServiceProvider _serviceProvider;
        private ICarService _service;
        public CarAdminView(IServiceProvider serviceProvider, ICarService service)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _service = service;
            this.DataContext = _serviceProvider.GetRequiredService<CarAdminViewModel>();
        }

        private void btnAddCar_Click(object sender, RoutedEventArgs e)
        {
            var addCarView = _serviceProvider.GetRequiredService<AdminView>();
            this.Close();
            addCarView.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var myCarAdminViewModel = this.DataContext as CarAdminViewModel;
            Car selectedCar = myCarAdminViewModel.SelectedCar;
            if (selectedCar != null)
            {
                myCarAdminViewModel.Cars.Remove(selectedCar);
                _service.RemoveCar(selectedCar);
            }
            else
            {
                MessageBox.Show("Выберите заявку!");
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var myCarAdminViewModel = this.DataContext as CarAdminViewModel;
            Car selectedCar = myCarAdminViewModel.SelectedCar;           
            if (selectedCar != null)
            {
                var editCarViewModel = _serviceProvider.GetRequiredService<EditCarViewModel>();
                editCarViewModel.SelectedCar = selectedCar;
                var editView = _serviceProvider.GetRequiredService<EditCarView>();
                editView.DataContext = editCarViewModel;
                this.Close();
                editView.Show();
            }
            else 
            {
                MessageBox.Show("Выберите заявку!");
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            var exit = _serviceProvider.GetRequiredService<AuthorizateView>();
            this.Close();
            exit.Show();
        }
    }
}
