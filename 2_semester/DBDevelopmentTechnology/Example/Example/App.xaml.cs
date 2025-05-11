using System.Windows;
using Example.Service;
using Example.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace Example
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider serviceProvider;
        public App()
        {
            var services = new ServiceCollection();
            services.AddScoped<IAuthorizationService, AuthorizationService>();
            services.AddScoped<IIndentService, IndentService>();
            services.AddTransient<MainWindow>();
            services.AddTransient<AccountWindow>();
            services.AddTransient<IndentViewModel>();
            serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var window = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();
        }
    }

}
