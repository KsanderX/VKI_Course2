using System;
using System.Windows;
using exam.Models;
using exam.Services;
using exam.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace exam.Views
{
    /// <summary>
    /// Логика взаимодействия для EditRequestView.xaml
    /// </summary>
    public partial class EditRequestView : Window
    {
        private readonly IServiceProvider _serviceProvider;
        private IRequestService _service;
        public EditRequestView(IServiceProvider serviceProvider, IRequestService service)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _service = service;
            cbStatus.ItemsSource = Enum.GetValues(typeof (RequestStatus));
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var myViewModel = DataContext as EditRequestViewModel;
            if (myViewModel.SelectedRequest.Name.Length < 3 || myViewModel.SelectedRequest.Description.Length < 2) 
            {
                MessageBox.Show("Длина должна быть больше 3");
            }
            else
            {
                _service.Save(myViewModel.SelectedRequest);
                MessageBox.Show("Успешное сохранение");
                var requestView = _serviceProvider.GetRequiredService<RequestAdminView>();
                this.Close();
                requestView.ShowDialog();
            }
        }
        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            var myViewModel = DataContext as EditRequestViewModel;
            myViewModel.SelectedRequest.UserId = null;
            MessageBox.Show("Пользователь удален!");
            _service.Save(myViewModel.SelectedRequest);
            var requestView = _serviceProvider.GetRequiredService<RequestAdminView>();
            this.Close();
            requestView.ShowDialog();
        }
    }
}
