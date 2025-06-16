using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Wedding_Agency.Services;

namespace Wedding_Agency.Views
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationView.xaml
    /// </summary>
    public partial class AuthorizationView : Window
    {
        private IAuthorizationService _authorizationService;
        private IServiceProvider _serviceProvider;
        public AuthorizationView(IServiceProvider service, IAuthorizationService authorizationService)
        {
            InitializeComponent();
            _serviceProvider = service;
            _authorizationService = authorizationService;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = tbLogin.Text;
            string password = tbPassword.Password;

            bool isAuthorized = _authorizationService.Authorization(login, password);

            if (isAuthorized)
            {
                MainWindow mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
                MessageBox.Show("Авторизация прошла успешно", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close(); 
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
