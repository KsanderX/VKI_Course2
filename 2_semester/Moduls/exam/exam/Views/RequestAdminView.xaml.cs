using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace exam.Views
{
    /// <summary>
    /// Логика взаимодействия для RequestAdminView.xaml
    /// </summary>
    public partial class RequestAdminView : Window
    {
        private IServiceProvider _serviceProvider;
        public RequestAdminView(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void btnAddRequest_Click(object sender, RoutedEventArgs e)
        {
            var addRequestView = _serviceProvider.GetRequiredService<AdminView>();
            addRequestView.Show();
        }
    }
}
