using System.Windows;
using exam.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace exam.Views
{
    /// <summary>
    /// Логика взаимодействия для UserView.xaml
    /// </summary>
    public partial class UserView : Window
    {
        private IServiceProvider _serviceProvider;
        public UserView(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            this.DataContext = _serviceProvider.GetRequiredService<UserViewModel>();
        }
    }
}
