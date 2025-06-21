using System.Windows;
using System.Windows.Controls;
using exam.Services;
using exam.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace exam.Views
{
    /// <summary>
    /// Логика взаимодействия для AuthorizateView.xaml
    /// </summary>
    public partial class AuthorizateView : Window
    {
        private IServiceProvider _serviceProvider;
        private IAuthService _authService;
        public AuthorizateView(IServiceProvider serviceProvider, IAuthService authService)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _authService = authService;
        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            string login = tnLogin.Text;
            string password = tbPass.Text;

            bool resultAuth = _authService.Auth(login, password);
            if (resultAuth)
            {
                if (_authService.CurrentUser.RoleId == 2)
                {
                    var userView = _serviceProvider.GetRequiredService<UserView>();
                    this.Close();
                    userView.ShowDialog();
                }
                else
                {
                    var adminView = _serviceProvider.GetRequiredService<RequestAdminView>();
                    this.Close();
                    adminView.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Не успешно!");
            }
        }

        private void btnOpenRegister_Click(object sender, RoutedEventArgs e)
        {
            var regView = _serviceProvider.GetRequiredService<RegisterView>();
            this.Close();
            regView.ShowDialog();
        }
    }
}
