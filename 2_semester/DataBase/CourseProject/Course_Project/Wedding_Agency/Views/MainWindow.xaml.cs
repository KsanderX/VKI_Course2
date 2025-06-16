using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Wedding_Agency.Views;

namespace Wedding_Agency
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private IServiceProvider _serviceProvider;
		public MainWindow(IServiceProvider serviceProvider)
		{
			InitializeComponent();
			_serviceProvider = serviceProvider;
		}
		private void btnContractView_Click(object sender, RoutedEventArgs e)
		{
			var contractView = _serviceProvider.GetService<ContractView>();
			if (contractView != null)
			{
				contractView.Show();
			}
			else
			{
				MessageBox.Show("Не удалось открыть ContractView.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
        private void btnEmployeeView_Click(object sender, RoutedEventArgs e)
        {
            var empWindow = _serviceProvider.GetRequiredService<EmployeeView>();
            empWindow.Show();
        }

        private void btnLoguot_Click(object sender, RoutedEventArgs e)
        {
            var authWindow = _serviceProvider.GetRequiredService<AuthorizationView>();
            authWindow.Show();
            this.Close();
        }
    }
}