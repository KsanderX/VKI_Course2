using System.Windows;
using Examination.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Examination
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            ServiceCollection services = new();

            services.AddTransient<MainWindow>();
            services.AddTransient<AutorizeView>();
            services.AddTransient<RegisterView>();

            _serviceProvider = services.BuildServiceProvider();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            var win = _serviceProvider.GetRequiredService<MainWindow>();
            win.Show();
        }
    }

}
