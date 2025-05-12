using System.Text;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Tkachev_KR.Services;
using Tkachev_KR.Windows;

namespace Tkachev_KR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IAuthorization _authorization;
        private IServiceProvider _serviceProvider;
        public MainWindow(IAuthorization authorization, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _authorization = authorization;
        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            string email = tbLogin.Text;
            string password = tbPassword.Text; 
            bool resultAuthorization = _authorization.Authorization(email, password);
            if (resultAuthorization) 
            {
                OrderWindow orderWindow = _serviceProvider.GetRequiredService<OrderWindow>();
                orderWindow.Show();
            }
            else
            {
                MessageBox.Show("Такого логина или пароля не найдено");
            }


        }
    }
}