using System.Windows;
using exam.Models;
using exam.Services;
using exam.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace exam.Views
{
    public partial class EditCarView : Window
    {
        private readonly IServiceProvider _serviceProvider;
        private ICarService _service;
        public EditCarView(IServiceProvider serviceProvider, ICarService service)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _service = service;
            cbStatus.ItemsSource = Enum.GetValues(typeof (CarStatus));
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var myViewModel = DataContext as EditCarViewModel;
            if (myViewModel.SelectedCar.Name.Length < 3 || myViewModel.SelectedCar.Description.Length < 2) 
            {
                MessageBox.Show("Длина должна быть больше 3");
            }
            else
            {
                _service.Save(myViewModel.SelectedCar);
                MessageBox.Show("Успешное сохранение");
                var carView = _serviceProvider.GetRequiredService<CarAdminView>();
                this.Close();
                carView.ShowDialog();
            }
        }
        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            var myViewModel = DataContext as EditCarViewModel;
            myViewModel.SelectedCar.UserId = null;
            MessageBox.Show("Пользователь удален!");
            _service.Save(myViewModel.SelectedCar);
            var carView = _serviceProvider.GetRequiredService<CarAdminView>();
            this.Close();
            carView.ShowDialog();
        }
    }
}
