
using Lab6.Models;
using Lab6.Service;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IService _service;
        public MainWindow(IService service)
        {
            InitializeComponent();
            _service = service;
            this.DataContext = new RequestViewModel();

        }

        private void AddRequest_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (RequestViewModel)this.DataContext; // получаю свою ViewModel

            if (viewModel.Request.MasterId == 0 || viewModel.Request.CarTypeId == 0)
            {
                MessageBox.Show("Заполните комбо боксы");
            }
            else if (string.IsNullOrWhiteSpace(viewModel.Request.ClientFullName))
            {
                MessageBox.Show("Поле 'ФИО клиента' не может быть пустым.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if(string.IsNullOrWhiteSpace(viewModel.Request.ClientPhoneNumber))
            {
                MessageBox.Show("Поле 'Телефон клиента' не может быть пустым.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if(string.IsNullOrWhiteSpace(viewModel.Request.CarModel))
            {
                MessageBox.Show("Поле 'Модель автомобиля' не может быть пустым.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if(string.IsNullOrWhiteSpace(viewModel.Request.ProblemDescription))
            {
                MessageBox.Show("Поле 'Описание проблемы' не может быть пустым.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                var newRequest = new Request
                {
                    ClientFullName = viewModel.Request.ClientFullName,
                    ClientPhoneNumber = viewModel.Request.ClientPhoneNumber,
                    CarModel = viewModel.Request.CarModel,
                    ProblemDescription = viewModel.Request.ProblemDescription,
                    MasterId = viewModel.Request.MasterId,
                    RequestStatusId = viewModel.Request.RequestStatusId,
                    CarTypeId = viewModel.Request.CarTypeId,
                    MasterComment = "",
                    Date = DateTime.Now,
                };

                _service.AddRequest(newRequest);
                MessageBox.Show("Создана новая заявка");
            }

         

        }

        private void btnOpenRequestWindow(object sender, RoutedEventArgs e)
        {
          var openRequestsWindow = new RequestsWindow(_service);
          openRequestsWindow.ShowDialog();
        }
    }

       
    }
