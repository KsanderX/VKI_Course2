using System.Windows;
using Example.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Example
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IAuthorizationService _authorizationService;
        private IServiceProvider _serviceProvider;
        public MainWindow(IAuthorizationService authorizationService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _authorizationService = authorizationService;
        }
        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            string login = tbLogin.Text;
            string password = tbPassword.Text;
            bool resultAuthorization = _authorizationService.Authorization(login, password);
            if (resultAuthorization)
            {
                AccountWindow accountWindow = _serviceProvider.GetRequiredService<AccountWindow>();
                accountWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Такого логина или пароля не найдено");
            }
        }
    }
}