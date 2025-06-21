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
        private IRequestService _requestService;
        public AdminView(IServiceProvider service, IRequestService request)
        {
            InitializeComponent();
            _service = service;
            _requestService = request;
            this.DataContext = _service.GetRequiredService<AdminViewModel>();
        }

        private void btnAddRequest_Click(object sender, RoutedEventArgs e)
        {
            var myAdminViewModel = this.DataContext as AdminViewModel;

            string name = myAdminViewModel.Name;
            string description = myAdminViewModel.Description;
            User user = myAdminViewModel.SelectedUser;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description) || user == null)
            {
                MessageBox.Show("Заполните поля!");
            }
            else
            {
                Request request = new Request()
                {
                    Name = name,
                    Description = description,
                    UserId = user.Id,
                    Status = RequestStatus.InProgress,
                    CreatedAt = DateTime.Now
                };
                _requestService.AddRequest(request);
                MessageBox.Show("Заявка добавлена!");
                var questsView = _service.GetRequiredService<RequestAdminView>();
                this.Close();
                questsView.ShowDialog();
            }
        }
    }
}
