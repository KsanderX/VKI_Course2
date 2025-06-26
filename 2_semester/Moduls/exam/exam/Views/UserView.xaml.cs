using System.Windows;
using exam.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace exam.Views
{
    public partial class UserView : Window
    {
        private IServiceProvider _serviceProvider;
        public UserView(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            this.DataContext = _serviceProvider.GetRequiredService<UserViewModel>();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            var exit = _serviceProvider.GetRequiredService<AuthorizateView>();
            this.Close();
            exit.Show();
        }
    }
}
