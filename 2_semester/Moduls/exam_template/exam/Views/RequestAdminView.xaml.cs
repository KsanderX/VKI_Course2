using System.Windows;
using exam.Models;
using exam.Services;
using exam.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace exam.Views
{
    /// <summary>
    /// Логика взаимодействия для RequestAdminView.xaml
    /// </summary>
    public partial class RequestAdminView : Window
    {
        private IServiceProvider _serviceProvider;
        private IRequestService _service;
        public RequestAdminView(IServiceProvider serviceProvider, IRequestService service)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _service = service;
            this.DataContext = _serviceProvider.GetRequiredService<RequestAdminViewModel>();
        }

        private void btnAddRequest_Click(object sender, RoutedEventArgs e)
        {
            var addRequestView = _serviceProvider.GetRequiredService<AdminView>();
            this.Close();
            addRequestView.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var myRequestAdminViewModel = this.DataContext as RequestAdminViewModel;
            Request selectedRequest = myRequestAdminViewModel.SelectedRequest;
            if (selectedRequest != null)
            {
                myRequestAdminViewModel.Requests.Remove(selectedRequest);
                _service.RemoveRequest(selectedRequest);
            }
            else
            {
                MessageBox.Show("Выберите заявку!");
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var myRequestAdminViewModel = this.DataContext as RequestAdminViewModel;
            Request selectedRequest = myRequestAdminViewModel.SelectedRequest;           
            if (selectedRequest != null)
            {
                var editRequstViewModel = _serviceProvider.GetRequiredService<EditRequestViewModel>();
                editRequstViewModel.SelectedRequest = selectedRequest;
                var editView = _serviceProvider.GetRequiredService<EditRequestView>();
                editView.DataContext = editRequstViewModel;
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
